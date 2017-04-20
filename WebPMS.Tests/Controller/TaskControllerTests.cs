using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebPMS.Models;
using WebPMS.Controllers;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Web;
using System.IO;
using System.Web.SessionState;
using System.Reflection;

namespace WebPMS.Tests
{
    [TestClass]
   public class TaskControllerTests
    {
     
        [TestMethod]
        public void DueSoon()
        {
            var controller = new TaskController();
            var result = controller.DueSoon() as ViewResult;
            Assert.AreEqual("DueSoon", result.ViewName);            
        }
        [TestMethod]
        public void DueLater()
        {
    
            var controller = new TaskController();
            var result = controller.DueLater() as ViewResult;
            Assert.AreEqual("DueLater", result.ViewName);
        }

        [TestMethod]
        public void gvDueSoon()
        {
            User obj = new User();
            obj.ID = "asad";
            obj.Password = "ASAD";
       
            var httpRequest = new HttpRequest("", "http://localhost:56564/", "");
            var stringWriter = new StringWriter();
            var httpResponce = new HttpResponse(stringWriter);
            var httpContext = new HttpContext(httpRequest, httpResponce);

            var sessionContainer = new HttpSessionStateContainer("id", new SessionStateItemCollection(),
                                                                 new HttpStaticObjectsCollection(), 10, true,
                                                                 HttpCookieMode.AutoDetect,
                                                                 SessionStateMode.InProc, false);

            httpContext.Items["AspSession"] = typeof(HttpSessionState).GetConstructor(
                                                     BindingFlags.NonPublic | BindingFlags.Instance,
                                                     null, CallingConventions.Standard,
                                                     new[] { typeof(HttpSessionStateContainer) },
                                                     null)
                                                .Invoke(new object[] { sessionContainer });

            HttpContext.Current = httpContext;
            SessionManager.setCurrentUser(obj);
            var controller = new TaskController();
            var result = controller.gvDueSoon() as PartialViewResult;
            Assert.AreEqual("_gvDueSoon", result.ViewName);
            Assert.IsInstanceOfType(result.Model, typeof(Tasks));
        }
        [TestMethod]
        public void gvDueLater()
        {
            User obj = new User();
            obj.ID = "asad";
            obj.Password = "ASAD";

            var httpRequest = new HttpRequest("", "http://localhost:56564/", "");
            var stringWriter = new StringWriter();
            var httpResponce = new HttpResponse(stringWriter);
            var httpContext = new HttpContext(httpRequest, httpResponce);

            var sessionContainer = new HttpSessionStateContainer("id", new SessionStateItemCollection(),
                                                                 new HttpStaticObjectsCollection(), 10, true,
                                                                 HttpCookieMode.AutoDetect,
                                                                 SessionStateMode.InProc, false);

            httpContext.Items["AspSession"] = typeof(HttpSessionState).GetConstructor(
                                                     BindingFlags.NonPublic | BindingFlags.Instance,
                                                     null, CallingConventions.Standard,
                                                     new[] { typeof(HttpSessionStateContainer) },
                                                     null)
                                                .Invoke(new object[] { sessionContainer });
           
            HttpContext.Current = httpContext;
            SessionManager.setCurrentUser(obj);
            var controller = new TaskController();
            var result = controller.gvDueLater() as PartialViewResult;
            Assert.AreEqual("_gvDueLater", result.ViewName);
            Assert.IsInstanceOfType(result.Model, typeof(Tasks));
        }

        [TestMethod]
        public void TasksPartial()
        {
            var controller = new TaskController();
            var result = controller.TasksPartial("", 1) as PartialViewResult;
            Assert.AreEqual("TasksPartial", result.ViewName);
            Assert.IsInstanceOfType(result.Model, typeof(TasksViewModel));
        }
 
    }
}
