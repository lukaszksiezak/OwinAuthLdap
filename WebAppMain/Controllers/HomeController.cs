using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMain.Models;

namespace WebAppMain.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User loginModel)
        {
            if (!ModelState.IsValid)        //Checks if input fields have the correct format
            {
                return View(loginModel);    //Returns the view with the input values so that the user doesn't have to retype again
            }

            return View(loginModel);
        }
    }
}