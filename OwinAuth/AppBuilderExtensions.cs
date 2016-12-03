using Owin;

namespace OwinAuthentication
{
    public static class AppBuilderExtensions
        {
            public static void UseActiveDirectoryAuthMiddleware(this IAppBuilder app)
            {
            app.Use<ActiveDirectoryAuthMiddleware>();
            }
        }
    }
