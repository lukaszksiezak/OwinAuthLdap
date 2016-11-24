using Microsoft.VisualStudio.TestTools.UnitTesting;
using OwinAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinAuth.Tests
    {
    [TestClass()]
    public class ActiveDirectoryAuthMiddlewareTests
        {
        [TestMethod()]
        public void ActiveDirectoryLoginTest()
            {
            Func<IDictionary<string, object>, Task> next = null;
            ActiveDirectoryAuthMiddleware mockActiveDirectoryAuth = new ActiveDirectoryAuthMiddleware(next);

            Assert.IsTrue(mockActiveDirectoryAuth.ActiveDirectoryLogin("guest1", "guest1password"));
            }
        }
    }