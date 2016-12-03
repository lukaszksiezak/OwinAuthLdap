using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web;
using System.IO;
using Microsoft.Owin.Extensions;
using System.Web.Mvc;
using System.Web.Routing;
using OwinAuthentication;

[assembly: OwinStartup(typeof(WebAppMain.Startup))]

namespace WebAppMain
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseActiveDirectoryAuthMiddleware();

            app.Use((context, next) => {
                PrintCurrentIntegratedPipelineStage(context, "1st middleware");
                return next.Invoke();
            });
            app.Use((context, next) => {
                PrintCurrentIntegratedPipelineStage(context, "2nd MW");
                return next.Invoke();
            });
            app.Run(context => {
                PrintCurrentIntegratedPipelineStage(context, "3rd MW");
                AreaRegistration.RegisterAllAreas();
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                return null;
            });
        }
        private void PrintCurrentIntegratedPipelineStage(IOwinContext context, string msg)
        {
            var currentIntegratedpipelineStage = HttpContext.Current.CurrentNotification;
            context.Get<TextWriter>("host.TraceOutput").WriteLine("Current IIS event: " + currentIntegratedpipelineStage + " Msg: " + msg);
        }
    }
}
