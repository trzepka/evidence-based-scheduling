using Microsoft.Owin.Extensions;
using Topshelf;
using TopShelf.Owin;

namespace EvidenceBasedScheduling
{
    class Program
    {
        public static void Main()
        {
            HostFactory.Run(x =>
            {
                x.Service<SchedulingService>(
                    s =>
                    {
                        s.ConstructUsing(() => new SchedulingService());
                        s.WhenStarted((service, control) => service.Start(control));
                        s.WhenStopped((service, control) => service.Stop(control));

                        s.OwinEndpoint(app =>
                        {
                            app.Domain = "localhost";
                            app.Port = 9970;
                            app.ConfigureAppBuilder(appBuilder => new Startup().Configuration(appBuilder));
                        });
                    }

                    );
                x.RunAsNetworkService();

                x.SetDescription("Evidence Based Scheduling Service");
                x.SetDisplayName("Evidence Based Scheduling Service");
                x.SetServiceName("EBS-Service");
            });
        }
    }
}
