using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using Microsoft.Owin;
using System.Web.Http;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;

using Microsoft.Owin.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

[assembly: OwinStartup(typeof(EvidenceBasedScheduling.Startup))]

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

            app.UseStageMarker(PipelineStage.MapHandler);
        }

        private static void ConfigureStaticFiles(IAppBuilder app)
        {
            app.UseFileServer(new FileServerOptions
            {
                RequestPath = PathString.Empty,
                FileSystem = new PhysicalFileSystem(@".\StaticPages")
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                RequestPath = new PathString("/css"),
                FileSystem = new PhysicalFileSystem(@".\Content\css"),
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                RequestPath = new PathString("/js"),
                FileSystem = new PhysicalFileSystem(@".\Content\js"),
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                RequestPath = new PathString("/lib"),
                FileSystem = new PhysicalFileSystem(@".\Content\bower_components"),
            });
        }

        private static HttpConfiguration ConfigureWebApi()
        {
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("Default", "api/{controller}/{action}");

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
#if DEBUG
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
#endif
            return config;
        }
    }
}