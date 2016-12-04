using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainWebAppWithOwinLogin.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }    //ToDo: change it to SecureString 
    }
}