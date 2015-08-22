using System;
using CommandLine;

namespace ConsoleClient
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string invokedVerb;
            object invokedVerbInstance = null;

            var options = new Options();
            if (!Parser.Default.ParseArguments(args, options,
                (verb, subOptions) =>
                {
                    // if parsing succeeds the verb name and correct instance
                    // will be passed to onVerbCommand delegate (string,object)
                    invokedVerb = verb;
                    invokedVerbInstance = subOptions;
                }))
            {
                Environment.Exit(Parser.DefaultExitCodeFail);
            }
            ICommand command = new CommandFactory().CreateCommand(invokedVerbInstance);
            command.Execute();
        }
    }
}