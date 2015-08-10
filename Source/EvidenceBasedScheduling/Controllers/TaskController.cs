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
using EvidenceBasedScheduling.Communication.Api;

namespace EvidenceBasedScheduling.Controllers
{
    [RoutePrefix("api/tasks")]
    [Route("{action=index}")]
    public class TaskController : ApiController
    {
        private const string UNASSIGNED = "Unassigned";
        private const int DEFAULT_PESSIMISTIC_LENGTH_SECONDS = 2 * 8 * 60 * 60;//2 days = 16h

        [HttpGet]
        public IEnumerable<Task> Index()
        {
            var taskProvider = new TasksProvider();
            return taskProvider.CurrentTasks;
        }

        [HttpGet]
        public IEnumerable<UserSchedulePrediction> PredictUsersSchedules()
        {

            var taskProvider = new TasksProvider();
            var tasksByUser = taskProvider.CurrentTasks.GroupBy(u => u.Assignee == null ? UNASSIGNED : u.Assignee.Name)
                .ToDictionary(g => g.Key, g => g.Select(e => e));
            var velocitiesByUser = taskProvider.HistoricalTasks
                .Where(t => t.Assignee != null && tasksByUser.ContainsKey(t.Assignee.Name))
                .GroupBy(t => t.Assignee.Name)
                .ToDictionary(g => g.Key, g => g.Select(e => e.EstimateSeconds * 1.0 / e.TimeSpentSeconds));
            var result = new List<UserSchedulePrediction>();
            var startDate = DateTime.Now.Date;
            var random = new Random();
            foreach (var usersTasks in tasksByUser)
            {
                var hasHistory = false;
                double[] velocities = null;
                if (!velocitiesByUser.ContainsKey(usersTasks.Key))
                {
                    velocities = new double[] { 0.8, 1, 1.2, 1.2, 1.4, 1.4, 2.0 };
                    hasHistory = false;
                }
                else
                {
                    velocities = velocitiesByUser[usersTasks.Key].ToArray();
                    hasHistory = true;
                }
                var possibleFinishDates = new List<TimeSpan>();
                var possibleFinishDatesPessimistic = new List<TimeSpan>();
                for (int i = 0; i < 100; i++)
                {
                    var sumOfTasksWithEstimate = usersTasks.Value
                        .Where(t => t.EstimateSeconds != 0)
                        .Sum(task => GetRandomizedActualForTask(task.EstimateSeconds, velocities, random));
                    var sumOfTasksWithoutEstimate =
                        usersTasks.Value
                        .Where(t => t.EstimateSeconds == 0)
                        .Sum(task => GetRandomizedActualForTask(DEFAULT_PESSIMISTIC_LENGTH_SECONDS, velocities, random));
                    possibleFinishDates.Add(TimeSpan.FromSeconds(sumOfTasksWithEstimate));
                    possibleFinishDatesPessimistic.Add(TimeSpan.FromSeconds(sumOfTasksWithoutEstimate));
                }
                result.Add(new UserSchedulePrediction
                {
                    User = new Assignee { Name = usersTasks.Key },
                    Stats = CalculateDaysDistribution(possibleFinishDates),
                    UnestimatedTasksStats = CalculateDaysDistribution(possibleFinishDatesPessimistic),
                    HasHistory = hasHistory
                });
            }

            return result;
        }

        private DistributionStatistics<int> CalculateDaysDistribution(IEnumerable<TimeSpan> timeSpans)
        {
            var result = new DistributionStatistics<int>();
            var totalCount = timeSpans.Count();
            //1d = 8h, so 24h = 3d, that's why it needs to be multiplied by 3
            var dayWeights = timeSpans.GroupBy(t => (int)Math.Ceiling(t.TotalDays * 3)).ToDictionary(g => g.Key, g => ((double)g.Count()) / totalCount);
            var orderedDays = dayWeights.Keys.OrderBy(d => d);
            result.Min = orderedDays.First();
            result.Max = orderedDays.Last();
            double probabilitySum = 0;
            foreach (var day in orderedDays)
            {
                probabilitySum += dayWeights[day];
                if (probabilitySum >= 0.25 && result.Quartile1 == null) result.Quartile1 = day;
                if (probabilitySum >= 0.5 && result.Median == null) result.Median = day;
                if (probabilitySum >= 0.75 && result.Quartile3 == null) result.Quartile3 = day;
            }
            return result;
        }

        private static double GetRandomizedActualForTask(double actual, double[] velocities, Random random)
        {
            return actual / (velocities[random.Next(0, velocities.Length)]);
        }
    }
}