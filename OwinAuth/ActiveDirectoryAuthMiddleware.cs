﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.DirectoryServices.Protocols;
using System.Net;

namespace OwinAuthentication
    {
    using Microsoft.Owin;
    using System.IO;
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class ActiveDirectoryAuthMiddleware
        {        
        AppFunc _next;
        private string userName;
        private string userPass;    //todo change to secure string

        public ActiveDirectoryAuthMiddleware(AppFunc next, string _userName, string _userPassword)
            {
            _next = next;
            userName = _userName;
            userPass = _userPassword;
            }

        public async Task Invoke(IDictionary<string,Object> environment)
            {
            IOwinContext context = new OwinContext(environment);
            context.Get<TextWriter>("host.TraceOutput").WriteLine("Currently in ActiveDirectory authentication middleware");

            var debug = true;
            if (ActiveDirectoryLogin("x", "x", debug)) 
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

        public bool ActiveDirectoryLogin(string userLogin, string userPassword, bool debug=false)
            {
            if (debug == true) return true; //to cleanup 

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
