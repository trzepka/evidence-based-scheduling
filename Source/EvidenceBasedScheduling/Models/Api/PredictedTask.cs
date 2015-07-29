using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvidenceBasedScheduling.Models.Api
{
    public class PredictedTask : Task
    {
        public PredictedTask() { }
        public PredictedTask(Task initialTask):base(initialTask)
        {
        }

        public DistributionStatistics<int> PredictedActualHours { get; set; }
        public int EstimatedHours { get { return EstimateSeconds / 60 / 60; } }
    }
}