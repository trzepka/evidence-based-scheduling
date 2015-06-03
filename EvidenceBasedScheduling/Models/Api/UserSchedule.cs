namespace EvidenceBasedScheduling.Models.Api
{
    public class UserSchedule
    {
        public DistributionStatistics<int> Stats { get; set; }
        public Assignee User { get; set; }
    }
}