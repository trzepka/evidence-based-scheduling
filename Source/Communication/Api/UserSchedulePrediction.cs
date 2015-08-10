namespace EvidenceBasedScheduling.Communication.Api
{
    public class UserSchedulePrediction
    {
        public DistributionStatistics<int> Stats { get; set; }
        public DistributionStatistics<int> UnestimatedTasksStats { get; set; }
        public Assignee User { get; set; }
        public bool HasHistory { get; set; }
    }
}