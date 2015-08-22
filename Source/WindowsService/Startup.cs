using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;

namespace EvidenceBasedScheduling
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
#if DEBUG
            app.UseErrorPage();
#endif
            app.UseWebApi(ConfigureWebApi());

            ConfigureStaticFiles(app);
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