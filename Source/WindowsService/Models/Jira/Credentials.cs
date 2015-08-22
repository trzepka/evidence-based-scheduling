namespace EvidenceBasedScheduling.Models.Jira
{
    public class Credentials
    {
        public const string KEY_NAME = "jira_credentials";

        public string User { get; set; }
        public string Password { get; set; }
    }
}