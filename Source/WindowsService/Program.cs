using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
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

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
#if DEBUG
            //          app.UseErrorPage();
#endif
            //            app.UseWebApi(ConfigureWebApi());

            ConfigureStaticFiles(app);


            //        app.UseStageMarker(PipelineStage.MapHandler);
        }

        private static void ConfigureStaticFiles(IAppBuilder app)
        {
            app.UseFileServer(new FileServerOptions
            {
                RequestPath = PathString.Empty,
                FileSystem = new PhysicalFileSystem(@".\Web\StaticPages")
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                RequestPath = new PathString("/css"),
                FileSystem = new PhysicalFileSystem(@".\Web\Content\css"),
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                RequestPath = new PathString("/js"),
                FileSystem = new PhysicalFileSystem(@".\Web\Content\js"),
            });
        }

        private static HttpConfiguration ConfigureWebApi()
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("Default", "api/{controller}/{action}");

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
#if DEBUG
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
#endif
            return config;
        }
    }

}
