using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPMS.Models;

namespace WebPMS.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult DueSoon()
        {
            return View();
        }
        public ActionResult DueLater()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult gvDueSoon()
        {
            

            int noOfDays = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            var model = BuildTask.ViewTasksByUser(SessionManager.getCurrentUser().ID, noOfDays, true);
            return PartialView("_gvDueSoon", model);
        }

        [ValidateInput(false)]
        public ActionResult gvDueLater()
        {
            int noOfDays = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            var model = BuildTask.ViewTasksByUser(SessionManager.getCurrentUser().ID, noOfDays, false);
            return PartialView("_gvDueLater", model);
        }

        public ActionResult TasksPartial(string Type, int ID, bool complete = false, int PropertyID = 0, string returnURL = "")
        {
            Task t = new Task();
            string mode = "Add";
            if (ID > 0)
            {
                t = BuildTask.ViewTask(ID);
                mode = "Edit";
                if (complete)
                {
                    if (!string.IsNullOrEmpty(t.CompletedDate.ToString()))
                    {
                        t.CompletedDate = null;
                    }
                    else
                    {
                        t.CompletedDate = DateTime.Now;
                    }
                }
            }
            if(PropertyID != 0)
            {
                t.LinkedReference = PropertyID.ToString();
            }
            t.Type = Type;
            var model = new TasksViewModel
            {
                Users = getUserList(),
                Task = t,
                returnURL = returnURL,
                mode = mode                        
                              
            }; 
            return PartialView(model);
        }

        public ActionResult SaveTask(TasksViewModel TasksViewModel)
        {
            if (TasksViewModel.Task != null)
            {
                if (TasksViewModel.Task.ID == 0) //insert
                {
                    if (DB.UpdateData(Constants.StoredProcedures.Insert.uspInsertTask, DB.StoredProcedures.uspInsertTask(TasksViewModel.Task, SessionManager.getCurrentUser().ID)) == 1)
                    {
                        ViewBag.showPopup = "true";
                        ViewBag.Confirmation = "Task for " + TasksViewModel.Task.UserID + " Added!";

                    }

                }
                else
                {
                    if (DB.UpdateData(Constants.StoredProcedures.Update.uspUpdateTask, DB.StoredProcedures.uspUpdateTask(TasksViewModel.Task, SessionManager.getCurrentUser().ID)) == 1)
                    {
                        ViewBag.showPopup = "true";
                        ViewBag.Confirmation = "Task for " + TasksViewModel.Task.UserID  + " Updated!";

                    }

                }
            }

            if (String.IsNullOrEmpty(TasksViewModel.returnURL))
            {
                return View("DueSoon");
            }
            return Redirect(TasksViewModel.returnURL);
            
        }

        private IEnumerable<SelectListItem> getUserList()
        {
             Users allUsers = BuildUser.ViewUsers(null);
            var user = allUsers.Select(x =>
                                new SelectListItem
                                {
                                    Value = x.ID.ToString(),
                                    Text = x.Forename +  " " + x.Surname 
                                });

            return new SelectList(user, "Value", "Text");
        }


    }
}