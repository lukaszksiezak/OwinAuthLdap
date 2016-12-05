using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainWebAppWithOwinLogin.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.User loginModel)
        {
            if (!ModelState.IsValid)        //Checks if input fields have the correct format
            {
                return View(loginModel);    //Returns the view with the input values so that the user doesn't have to retype again
            }     
      
            return View(loginModel);
        }

    }
}