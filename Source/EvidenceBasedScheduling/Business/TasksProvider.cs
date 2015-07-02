using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Caching;
using System.Web;
using EvidenceBasedScheduling.Models.Api;
using EvidenceBasedScheduling.Models.Jira;
using Newtonsoft.Json;
using RestSharp;

namespace EvidenceBasedScheduling.Business
{
    public class TasksProvider
    {
        private Credentials credentials;
        public IEnumerable<Task> CurrentTasks { get; private set; }
        public IEnumerable<Task> HistoricalTasks { get; private set; }

        public TasksProvider()
        {
            credentials = JsonConvert.DeserializeObject<Credentials>(
                File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                    "credentials.json")));

            Func<JiraIssue, Task> jiraTaskToTaskTransformer = t =>
                new Task
                {
                    Key = t.Key,
                    EstimateSeconds = t.Fields.Timetracking.OriginalEstimateSeconds,
                    TimeSpentSeconds = t.Fields.Timetracking.TimeSpentSeconds,
                    Assignee = t.Fields.Assignee == null ? null :
                        new Assignee
                        {
                            Name = t.Fields.Assignee.DisplayName,
                            EmailAddress = t.Fields.Assignee.EmailAddress
                        }
                };
            HistoricalTasks =
                QueryForTasks("status=Done")
                    .Select(
                        jiraTaskToTaskTransformer);
            CurrentTasks = QueryForTasks("status=\"To Do\"")
                .Select(
                    jiraTaskToTaskTransformer);
        }

        private IEnumerable<JiraIssue> QueryForTasks(string jql)
        {
            var client = new RestClient("http://jira-localhost:8083")
            {
                Authenticator = new HttpBasicAuthenticator(credentials.User, credentials.Password)
            };

            Func<int, string> buildResourceFunc = (startAt) =>
                String.Format("rest/api/2/search?jql={0}&fields=timetracking,assignee,creator&startAt={1}",
                    HttpUtility.UrlEncode(jql), startAt);
            var request = new RestRequest(buildResourceFunc(0), Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            var issuesFound = new List<JiraIssue>();
            bool done;
            int totalDownloaded = 0;
            do
            {
                var response = client.Execute<JiraSearchResult>(request);
                var responseOk = response.ResponseStatus == ResponseStatus.Completed &&
                                 response.StatusCode == HttpStatusCode.OK;
                if (responseOk)
                {
                    if (response.Data != null && response.Data.Issues != null)
                    {
                        issuesFound.AddRange(response.Data.Issues);
                    }
                    totalDownloaded += response.Data.MaxResults;
                    done = responseOk && response.Data.Total <= totalDownloaded;
                    request.Resource = buildResourceFunc(totalDownloaded - 1);
                }
                else
                {
                    throw response.ErrorException;
                }
            } while (!done);
            return issuesFound;
        }
    }
}