using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinAuth
    {
    public static class AppBuilderExtensions
        {
            public static void UseActiveDirectoryAuthMiddleware(this IAppBuilder app)
            {
            app.Use<ActiveDirectoryAuthMiddleware>();
            }
        }
    }
