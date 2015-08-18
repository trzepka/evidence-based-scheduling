using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    public class PredictSubOptions
    {
        [Option("exclude-unestimated")]
        public bool ExcludeUnestimated { get; set; }

    }
}
