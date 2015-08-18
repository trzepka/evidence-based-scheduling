using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    public class Options
    {
        [VerbOption("predict")]
        public PredictSubOptions PredictVerb { get; set; }

        [VerbOption("set")]
        public SetSubOptions SetVerb { get; set; }

        [HelpVerbOption]
        public string GetUsage(string verb)
        {
            return HelpText.AutoBuild(this, verb);
        }
    }
}
