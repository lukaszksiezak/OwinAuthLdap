﻿using System.Security;

namespace WebAppMain.Models
    {
    public class User
        {
        public string UserName { get; set; }
        public string UserPassword { get; set; }    //ToDo: change it to SecureString 
        }
    }