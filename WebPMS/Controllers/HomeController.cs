
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebPMS.Models;


namespace WebPMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ValidateUser(User obj)
        {

            User LoggedUser = BuildUser.ViewUser(obj.ID);

            if(LoggedUser == null)
            {
                //UserDosentExsist
                // return
                return View("Login");
            }
            
            if (obj.Password != TDES.DecryptString(LoggedUser.Password)) {

                // Passwords are not correct
                return View("Login");
            }

            SessionManager.setCurrentUser(LoggedUser);
            SessionManager.setIsLoggedIn(true);

            return RedirectToAction("Home", "Property");
          
        }

        public ActionResult Logout()
        {
            SessionManager.clearSession();
            return View("Login");
        }

    }
}