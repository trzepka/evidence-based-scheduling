using System.Web.Http;
using EvidenceBasedScheduling;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Extensions;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.StaticFiles;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;

[assembly: OwinStartup(typeof (Startup))]

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
            ConfigureAuth(app);
            app.Use((context, next) =>
            {
                //TODO:reconsider when auth is correctly done
                var response = new {username = "test-user", role = new {title = "user", bitMask = 2}};
                context.Response.Cookies.Append("user",
                    JsonConvert.SerializeObject(response));
                return next.Invoke();
            });

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
        }

        private static HttpConfiguration ConfigureWebApi()
        {
            var config = new HttpConfiguration();
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(DefaultAuthenticationTypes.ApplicationCookie));
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

        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/")
            });
        }
    }
}