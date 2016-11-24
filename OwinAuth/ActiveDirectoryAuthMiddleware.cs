using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.Protocols;
using System.Net;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace OwinAuth
    {
    using Microsoft.Owin;
    using System.Security;
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class ActiveDirectoryAuthMiddleware
        {
        AppFunc _next;

        public ActiveDirectoryAuthMiddleware(AppFunc next)
            {
            _next = next;
            }

        public async Task Invoke(IDictionary<string,Object> environment)
            {
            IOwinContext context = new OwinContext(environment);

            var dumbUserName = "x";
            var dumbUserPass = "xx";
            if (ActiveDirectoryLogin(dumbUserName, dumbUserPass)) 
                {
                // _next is only invoked if authentication succeeds:
                context.Response.StatusCode = 200;
                context.Response.ReasonPhrase = "OK";
                await _next.Invoke(environment);
                }
            else 
                {
                context.Response.StatusCode = 401;
                context.Response.ReasonPhrase = "Not Authorized";

                await context.Response.WriteAsync(string.Format("<h1>Error {0}-{1}",
                    context.Response.StatusCode,
                    context.Response.ReasonPhrase));
                }
            }

        private bool ActiveDirectoryLogin(string userLogin, string userPassword)
            {
            try {
                LdapConnection lcon = new LdapConnection(new LdapDirectoryIdentifier((string)null, false, false));
                NetworkCredential nc = new NetworkCredential(userLogin, userPassword, Environment.UserDomainName);
                lcon.Credential = nc;
                lcon.AuthType = AuthType.Negotiate;
                lcon.Bind(nc); // user has authenticated 

                return true;
                }
            catch (LdapException) { //auth failed.
                return false;
                }
            }
        }
    }
