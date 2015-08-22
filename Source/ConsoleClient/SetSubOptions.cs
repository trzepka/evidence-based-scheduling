using CommandLine;

namespace ConsoleClient
{
    public class SetSubOptions
    {
        [Option('s', "service-url")]
        public string ServiceUrl { get; set; }
    }
}