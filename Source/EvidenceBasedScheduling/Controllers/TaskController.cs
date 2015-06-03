using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EvidenceBasedScheduling.Business;
using EvidenceBasedScheduling.Models.Api;

namespace EvidenceBasedScheduling.Controllers
{
    [RoutePrefix("api/tasks")]
    [Route("{action=index}")]
    public class TaskController : ApiController
    {
        [HttpGet]
        public IEnumerable<Task> Index()
        {
            var taskProvider = new TasksProvider();
            return taskProvider.CurrentTasks.Union(taskProvider.CurrentTasks);
        }

        [HttpGet]
        public IEnumerable<UserSchedule> UserSchedules()
        {
            var taskProvider = new TasksProvider();
            var velocitiesByUser = taskProvider.HistoricalTasks.GroupBy(t => t.Assignee.Name)
                .ToDictionary(g => g.Key, g => g.Select(e => e.EstimateSeconds * 1.0 / e.TimeSpentSeconds));
            var tasksByUser = taskProvider.CurrentTasks.GroupBy(u => u.Assignee.Name)
                .ToDictionary(g => g.Key, g => g.Select(e => e));
            var result = new List<UserSchedule>();
            var startDate = DateTime.Now.Date;
            var random = new Random();
            foreach (var user in velocitiesByUser)
            {

                var velocities = user.Value.ToArray();
                if (!tasksByUser.ContainsKey(user.Key))
                {
                    result.Add(new UserSchedule { User = new Assignee { Name = user.Key }, Stats = new DistributionStatistics<int>() });
                }
                var possibleFinishDates = new List<TimeSpan>();
                for (int i = 0; i < 1000; i++)
                {
                    var sumOfTasks =
                        tasksByUser[user.Key].Sum(d => GetRandomizedActualForTask(d, velocities, random));
                    possibleFinishDates.Add(TimeSpan.FromSeconds(sumOfTasks));
                }
                result.Add(new UserSchedule
                {
                    User = new Assignee { Name = user.Key },
                    Stats = CalculateDaysDistribution(possibleFinishDates, startDate)
                });
            }

            return result;
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
                SetDistributionMarker(probabilitySum, 0.25, result.Quartile1, () => result.Quartile1 = day);
                SetDistributionMarker(probabilitySum, 0.5, result.Median, () => result.Median = day);
                SetDistributionMarker(probabilitySum, 0.75, result.Quartile3, () => result.Quartile3 = day);
            }
            return result;
        }

        private void SetDistributionMarker<T>(double probabilitySum, double threshold, T markerValue, Action markerSetter)
        {
            if (probabilitySum >= threshold && markerValue == null)
            {
                markerSetter();
            }
        }


        private static double GetRandomizedActualForTask(Task d, double[] velocities, Random random)
        {
            return d.EstimateSeconds / (velocities[random.Next(0, velocities.Length)]);
        }
    }
}