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
    public class HomeControllerTests
    {
        [TestMethod]
        public void Login()
        {
            var controller = new HomeController();
            var result = controller.Login() as ViewResult;
            Assert.AreEqual("Login", result.ViewName);
        }
        [TestMethod]
        public void Logout()
        {
            var controller = new HomeController();
            var result = controller.Logout() as ViewResult;
            Assert.AreEqual("Login", result.ViewName);
      
        }
        [TestMethod]
        public void ValidateLogin()
        {
            User obj = new User();
            obj.ID = "asad";
            obj.Password = "ASAD";
            var controller = new HomeController();
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

            var result = (RedirectToRouteResult)controller.ValidateUser(obj);
            Assert.AreEqual("Home", result.RouteValues["action"]);
            Assert.AreEqual("Asad", SessionManager.getCurrentUser().ID);
        }

       
    }
}
