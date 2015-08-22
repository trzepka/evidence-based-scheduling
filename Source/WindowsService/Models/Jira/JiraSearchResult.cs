using System.Collections.Generic;

namespace EvidenceBasedScheduling.Models.Jira
{
    public class JiraSearchResult
    {
        public int StartAt { get; set; }
        public int MaxResults { get; set; }
        public int Total { get; set; }
        public List<JiraIssue> Issues { get; set; }
    }
}