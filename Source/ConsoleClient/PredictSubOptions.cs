using CommandLine;

namespace ConsoleClient
{
    public class PredictSubOptions
    {
        [Option("exclude-unestimated")]
        public bool ExcludeUnestimated { get; set; }

        [Option('h', "--historical-tasks-query")]
        public string HistoricalTasksQuery { get; set; }

        [Option('c', "--current-tasks-query")]
        public string CurrentTasksQuery { get; set; }
    }
}