using System;
using System.Collections.Generic;
using System.IO;
using EvidenceBasedScheduling.Communication.Api;
using Newtonsoft.Json;
using RestSharp;

namespace ConsoleClient
{
    public class PredictCommand : ICommand
    {
        private readonly PredictSubOptions _options;

        public PredictCommand(object options)
        {
            _options = options as PredictSubOptions;
            if (options == null)
            {
                throw new ArgumentException("options");
            }
        }

        public void Execute()
        {
            string filename = "settings.json";
            Settings settings = File.Exists(filename)
                ? JsonConvert.DeserializeObject<Settings>(File.ReadAllText(filename))
                : new Settings();
            var client = new RestClient(settings.ServiceUrl);
            var request = new RestRequest("/api/tasks/PredictUsersSchedules", Method.GET);
            request.Parameters.Add(new Parameter
            {
                Name = "historicalTasksQuery",
                Value = _options.HistoricalTasksQuery,
                Type = ParameterType.GetOrPost
            });
            request.Parameters.Add(new Parameter
            {
                Name = "currentTasksQuery",
                Value = _options.CurrentTasksQuery,
                Type = ParameterType.GetOrPost
            });
            IRestResponse<List<UserSchedulePrediction>> response = client.Execute<List<UserSchedulePrediction>>(request);
            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                foreach (UserSchedulePrediction data in response.Data)
                {
                    if (data.HasHistory)
                    {
                        Console.WriteLine("user: {0}, min: {1}, median: {2}, max: {3}", data.User.Name, data.Stats.Min,
                            data.Stats.Median, data.Stats.Max);
                    }
                }
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }
        }
    }
}