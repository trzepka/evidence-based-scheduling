using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string invokedVerb;
            object invokedVerbInstance;

            var options = new Options();
            if (!CommandLine.Parser.Default.ParseArguments(args, options,
              (verb, subOptions) =>
              {
                  // if parsing succeeds the verb name and correct instance
                  // will be passed to onVerbCommand delegate (string,object)
                  invokedVerb = verb;
                  invokedVerbInstance = subOptions;
              }))
            {
                Environment.Exit(CommandLine.Parser.DefaultExitCodeFail);
            }


        }
    }

    public abstract class CommonOptions
    {
        [Option("service-url")]
        public string ServiceUrl { get; set; }
    }


    public class Options
    {
        [VerbOption("predict")]
        public PredictSubOptions PredictVerb { get; set; }

        [HelpVerbOption]
        public string GetUsage(string verb)
        {
            return HelpText.AutoBuild(this, verb);
        }
    }

    public class PredictSubOptions : CommonOptions
    {
        [Option("exclude-unestimated")]
        public bool ExcludeUnestimated { get; set; }

    }
}
