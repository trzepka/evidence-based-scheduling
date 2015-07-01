using EvidenceBasedScheduling.Controllers;

namespace EvidenceBasedScheduling.Models.Jira
{
    public class JiraIssue
    {
        public string Key { get; set; }
        public Fields Fields { get; set; }
    }
}