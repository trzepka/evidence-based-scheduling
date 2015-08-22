using System;
using Topshelf;

namespace EvidenceBasedScheduling
{
    public class SchedulingService: ServiceControl
    {
        public bool Start(HostControl hostControl)
        {
            Console.WriteLine("started");
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            Console.WriteLine("stopped");
            return true;
        }
    }
}