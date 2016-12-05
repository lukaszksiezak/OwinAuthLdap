using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using MainWebAppWithOwinLogin.Models;
using OwinAuthentication;
using System.Web;
using System.IO;
using System.Net.Http;

[assembly: OwinStartup(typeof(MainWebAppWithOwinLogin.App_Start.Startup))]

namespace MainWebAppWithOwinLogin.App_Start
{
    public class Startup
    {
        private User User = new User();

        public void Configuration(IAppBuilder app)
        {
            User.UserName = "lolname";
            User.UserPassword = "lolpass";

            app.Use((context, next) => {
                PrintCurrentIntegratedPipelineStage(context, "1st middleware");

                context.Response.Redirect("Auth/Location");
                                
                return next.Invoke();
            });
            app.Use((context, next) => {
                PrintCurrentIntegratedPipelineStage(context, "1stlololo middleware");

                HttpClient client = new HttpClient();
                client.BaseAddress = HttpContext.Current.Request.Url;
                var response = client.GetAsync(client.BaseAddress + "Auth/Login").Result;

                return next.Invoke();
            });

            app.UseActiveDirectoryAuthMiddleware(User.UserName, User.UserPassword);

            app.Use((context, next) => {
                PrintCurrentIntegratedPipelineStage(context, "1st middleware");
                return next.Invoke();
            });
            app.Use((context, next) => {
                PrintCurrentIntegratedPipelineStage(context, "2nd MW");
                return next.Invoke();
            });
            //app.Run(context => {
            //    PrintCurrentIntegratedPipelineStage(context, "3rd MW");
            //    //AreaRegistration.RegisterAllAreas();
            //   // RouteConfig.RegisterRoutes(RouteTable.Routes);

            //    return new Task(() => context.Response.Redirect("/home/login"));
            //});
        }
        private void PrintCurrentIntegratedPipelineStage(IOwinContext context, string msg)
        {
            var currentIntegratedpipelineStage = HttpContext.Current.CurrentNotification;
            context.Get<TextWriter>("host.TraceOutput").WriteLine("Current IIS event: " + currentIntegratedpipelineStage + " Msg: " + msg);
        }
    }
}
