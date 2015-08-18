using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    public class SetCommand : ICommand
    {
        private SetSubOptions _options;

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
            var filename = "settings.json";
            var settings = File.Exists(filename) ? JsonConvert.DeserializeObject<Settings>(File.ReadAllText(filename)) : new Settings();
            settings.ServiceUrl = _options.ServiceUrl;
            File.WriteAllText(filename, JsonConvert.SerializeObject(settings, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }

    }

}
