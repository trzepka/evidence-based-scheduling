using CommandLine;
using CommandLine.Text;

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