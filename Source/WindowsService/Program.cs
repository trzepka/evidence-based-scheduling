using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace EvidenceBasedScheduling
{
    class Program
    {
        public static void Main()
        {
            HostFactory.Run(x =>                                 
            {
                x.Service<SchedulingService>();
                x.RunAsLocalSystem();

                x.SetDescription("Evidence Based Scheduling Service");
                x.SetDisplayName("Evidence Based Scheduling Service");
                x.SetServiceName("EBS-Service");
            });   
        }
    }
}
