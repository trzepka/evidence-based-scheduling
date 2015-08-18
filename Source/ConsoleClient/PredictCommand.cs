using EvidenceBasedScheduling.Communication.Api;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{

    public class PredictCommand : ICommand
    {
        private PredictSubOptions _options;

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
            var filename = "settings.json";
            var settings = File.Exists(filename) ? JsonConvert.DeserializeObject<Settings>(File.ReadAllText(filename)) : new Settings();
            var client = new RestClient(settings.ServiceUrl);
            var request = new RestRequest("/api/tasks/PredictUsersSchedules", Method.GET);
            var response = client.Execute<List<UserSchedulePrediction>>(request);
            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                foreach (var data in response.Data)
                {
                    Console.WriteLine("user: {0}, min: {1}, median: {2}, max: {3}", data.User.Name, data.Stats.Min, data.Stats.Median, data.Stats.Max);
                }
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }
        }
    }
}
