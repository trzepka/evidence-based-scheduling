namespace EvidenceBasedScheduling.Models.Jira
{
    public class Timetracking
    {
        public string OriginalEstimate { get; set; }
        public string RemainingEstimate { get; set; }
        public string TimeSpent { get; set; }
        public int OriginalEstimateSeconds { get; set; }
        public int RemainingEstimateSeconds { get; set; }
        public int TimeSpentSeconds { get; set; }
    }
}