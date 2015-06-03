namespace EvidenceBasedScheduling.Models.Api
{
    public class Task
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Assignee Assignee { get; set; }
        public int TimeSpentSeconds { get; set; }
        public int EstimateSeconds { get; set; }
    }
}