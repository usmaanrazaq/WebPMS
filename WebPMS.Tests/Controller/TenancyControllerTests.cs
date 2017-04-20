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
   public class TenancyControllerTests
    {

        [TestMethod]
        public void Tenants()
        {
            var controller = new TenancyController();
            var result = controller.Tenants() as ViewResult;
            Assert.AreEqual("Tenants", result.ViewName);
        }
        [TestMethod]
        public void Tenancies()
        {
            var controller = new TenancyController();
            var result = controller.Tenancies() as ViewResult;
            Assert.AreEqual("Tenancies", result.ViewName);
        }
        [TestMethod]
        public void TenancyRequirements()
        {
            var controller = new TenancyController();
            var result = controller.TenancyRequirements(1) as ViewResult;
            Assert.AreEqual("TenancyRequirements", result.ViewName);
            Assert.IsInstanceOfType(result.Model, typeof(TenancyRequirementViewModel));
        }
        [TestMethod]
        public void TenancyDetails()
        {
            var controller = new TenancyController();
            var result = controller.TenancyDetails(0) as RedirectToRouteResult;
            Assert.AreEqual("PropertyDetails", result.RouteValues["action"]); // ensuring cant view tennacy details without propertyID
        }
        [TestMethod]
        public void gvTenants_Partial()
        {
            var controller = new TenancyController();
            var result = controller.gvTenants_Partial(-1) as PartialViewResult;
            Assert.AreEqual("_gvTenants_Partial", result.ViewName);
            Assert.IsInstanceOfType(result.Model, typeof(Tenancies));
        }
        [TestMethod]
        public void gvTenancy_Partial()
        {
            var controller = new TenancyController();
            var result = controller.gvTenancy_Partial(-1) as PartialViewResult;
            Assert.AreEqual("_gvTenancy_Partial", result.ViewName);
            Assert.IsInstanceOfType(result.Model, typeof(Tenancies));
        }
    }
}
