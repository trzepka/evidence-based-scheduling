using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    public class SetSubOptions
    {
        [Option('s', "service-url")]
        public string ServiceUrl { get; set; }
    }
}
