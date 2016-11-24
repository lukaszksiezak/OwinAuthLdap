using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using Microsoft.Owin.Hosting;
using Microsoft.Owin;

namespace OwinAuth
    {
    class KatanaConsole
        {
        static void Main(string[] args)
            {
            WebApp.Start<Startup>("http://localhost:8080");
            Console.WriteLine("Server started. Press any key to quit");
            Console.ReadLine();
            }
        }
    }
