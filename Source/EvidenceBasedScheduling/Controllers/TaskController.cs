using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EvidenceBasedScheduling.Business;
using EvidenceBasedScheduling.Models.Api;
using EvidenceBasedScheduling.Models.Jira;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Contrib;
using RestSharp.Extensions;

namespace EvidenceBasedScheduling.Controllers
{
    [RoutePrefix("api/tasks")]
    [Route("{action=index}")]
    public class TaskController : ApiController
    {
        private const string UNASSIGNED = "Unassigned";
        private const int DEFAULT_PESSIMISTIC_LENGTH_SECONDS = 2 * 24 * 60 * 60;//2 days

        [HttpGet]
        public IEnumerable<Task> Index()
        {
            var taskProvider = new TasksProvider();
            return taskProvider.CurrentTasks;
        }

        [HttpGet]
        public IEnumerable<UserSchedule> UserSchedules()
        {

            var taskProvider = new TasksProvider();
            var tasksByUser = taskProvider.CurrentTasks.GroupBy(u => u.Assignee == null ? UNASSIGNED : u.Assignee.Name)
                .ToDictionary(g => g.Key, g => g.Select(e => e));
            var velocitiesByUser = taskProvider.HistoricalTasks
                .Where(t => t.Assignee != null && tasksByUser.ContainsKey(t.Assignee.Name))
                .GroupBy(t => t.Assignee.Name)
                .ToDictionary(g => g.Key, g => g.Select(e => e.EstimateSeconds * 1.0 / e.TimeSpentSeconds));
            var result = new List<UserSchedule>();
            var startDate = DateTime.Now.Date;
            var random = new Random();
            foreach (var usersTasks in tasksByUser)
            {
                if (!velocitiesByUser.ContainsKey(usersTasks.Key))
                {
                    result.Add(CreatePessimisticSchedule(usersTasks.Value, usersTasks.Key, startDate));
                    continue;
                }
                var velocities = velocitiesByUser[usersTasks.Key].ToArray();
                var possibleFinishDates = new List<TimeSpan>();
                for (int i = 0; i < 100; i++)
                {
                    var sumOfTasks =
                        usersTasks.Value.Sum(task => GetRandomizedActualForTask(task, velocities, random));
                    possibleFinishDates.Add(TimeSpan.FromSeconds(sumOfTasks));
                }
                result.Add(new UserSchedule
                {
                    User = new Assignee { Name = usersTasks.Key },
                    Stats = CalculateDaysDistribution(possibleFinishDates, startDate)
                });
            }

            return result;
        }

        private UserSchedule CreatePessimisticSchedule(IEnumerable<Task> tasks, string username, DateTime startDate)
        {
            return new UserSchedule
            {
                User = new Assignee { Name = username },
                Stats = CalculateDaysDistribution(new[] { 
                  TimeSpan.FromSeconds(DEFAULT_PESSIMISTIC_LENGTH_SECONDS),
                  TimeSpan.FromSeconds(DEFAULT_PESSIMISTIC_LENGTH_SECONDS / 2),
                  TimeSpan.FromSeconds(DEFAULT_PESSIMISTIC_LENGTH_SECONDS * 2),
                }, startDate),
                IsPessimistic = true
            };
        }

        private DistributionStatistics<int> CalculateDaysDistribution(IEnumerable<TimeSpan> timeSpans, DateTime startDate)
        {
            var result = new DistributionStatistics<int>();
            var totalCount = timeSpans.Count();
            var dayWeights = timeSpans.GroupBy(t => (int)Math.Ceiling(t.TotalDays * 3)).ToDictionary(g => g.Key, g => ((double)g.Count()) / totalCount);
            var orderedDays = dayWeights.Keys.OrderBy(d => d);
            result.Min = orderedDays.First();
            result.Max = orderedDays.Last();
            double probabilitySum = 0;
            foreach (var day in orderedDays)
            {
                probabilitySum += dayWeights[day];
                if(probabilitySum >= 0.25 && result.Quartile1 == null) result.Quartile1 = day;
                if (probabilitySum >= 0.5 && result.Median == null) result.Median = day;
                if (probabilitySum >= 0.75 && result.Quartile3 == null) result.Quartile3 = day;
            }
            return result;
        }

        private static double GetRandomizedActualForTask(Task d, double[] velocities, Random random)
        {
            var estimate = d.EstimateSeconds == 0 ? DEFAULT_PESSIMISTIC_LENGTH_SECONDS : d.EstimateSeconds;
            return estimate / (velocities[random.Next(0, velocities.Length)]);
        }
    }
}