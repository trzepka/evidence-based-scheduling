using System;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleClient
{
    public class SetCommand : ICommand
    {
        private readonly SetSubOptions _options;

        public SetCommand(object options)
        {
            _options = options as SetSubOptions;
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
            settings.ServiceUrl = _options.ServiceUrl;
            File.WriteAllText(filename,
                JsonConvert.SerializeObject(settings, Formatting.Indented,
                    new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}));
        }
    }
}