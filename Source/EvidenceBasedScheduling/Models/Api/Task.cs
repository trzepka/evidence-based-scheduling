using EvidenceBasedScheduling.Communication.Api;

namespace EvidenceBasedScheduling.Models.Api
{
    public class Task
    {
        public Task()
        {
        }

        public Task(Task otherTask)
        {
            Key = otherTask.Key;
            Name = otherTask.Name;
            Description = otherTask.Description;
            Assignee = otherTask.Assignee;
            TimeSpentSeconds = otherTask.TimeSpentSeconds;
            EstimateSeconds = otherTask.EstimateSeconds;
        }

        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Assignee Assignee { get; set; }
        public int TimeSpentSeconds { get; set; }
        public int EstimateSeconds { get; set; }
    }
}