
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
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
      

        [HttpGet]
        public ActionResult GetTodaysTasks()
        {
            int noOfDays = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            WebPMS.Models.Tasks AllTasks = BuildTask.ViewTasksByUser(SessionManager.getCurrentUser().ID, noOfDays, true);
            WebPMS.Models.Tasks TasksToRemind = new Tasks();
            foreach (WebPMS.Models.Task T in AllTasks)
            {
                if (T.ReminderDate == null) continue;
                if (T.ReminderDate.Value.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy")){
                    if(T.CompletedDate == null )
                    TasksToRemind.Add(T);
                }
            }

            var json = new JavaScriptSerializer().Serialize(TasksToRemind);
            return Json(TasksToRemind,JsonRequestBehavior.AllowGet);

        }
        public ActionResult Logout()
        {
            SessionManager.clearSession();
            return View("Login");
        }

    }
}