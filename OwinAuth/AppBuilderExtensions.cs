using Owin;

namespace OwinAuthentication
{
    public static class AppBuilderExtensions
        {
        public static void UseActiveDirectoryAuthMiddleware(this IAppBuilder app, string UserName, string UserPassword) //ToDo: change password to SecureString 
        {
            app.Use<ActiveDirectoryAuthMiddleware>(UserName, UserPassword);
            }
        }
    }
