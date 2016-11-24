using Owin;

namespace OwinAuth
    {
    internal class Startup
        {
        public void Configuration(IAppBuilder app)
            {
            app.UseActiveDirectoryAuthMiddleware();
            //TODO: add to app extension method which adds class responsible for active directory authentication
            //TODO: add to app extension method which adds class responsible for database authorization
            //TODO: add to app extension method which adds class responsible for redirecting to some resource.
            }
        }
    }