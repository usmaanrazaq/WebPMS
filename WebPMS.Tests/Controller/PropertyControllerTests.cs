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
    public class PropertyControllerTests
    {
        [TestMethod]
        public void Home()
        {
            var controller = new PropertyController();
            var result = controller.Home() as ViewResult;
            Assert.AreEqual("Home", result.ViewName);
        }
        [TestMethod]
        ///Imitating the double click of a row 
        public void gvPropertiesPartial()
        {
            var controller = new PropertyController();
            var result = controller.gvPropertiesPartial(1) as RedirectToRouteResult;            
            Assert.AreEqual("PropertyDetails", result.RouteValues["action"]); // found a property and gone straight to the property details page         
        }
        [TestMethod]
        public void RoomDetailsSelected()
        {
            var controller = new PropertyController();
            var result = controller.RoomDetailsSelected(0) as PartialViewResult;
            Assert.AreEqual("_RoomDetailsPartial", result.ViewName);
            Assert.IsInstanceOfType(result.Model, typeof(RoomDetailsViewModel));
                                 
        }
        [TestMethod]
        public void RoomDetails()
        {
            var controller = new PropertyController();
            var result = controller.RoomDetails(1) as ViewResult;
            Assert.AreEqual("RoomDetails", result.ViewName);
            Assert.IsInstanceOfType(result.Model, typeof(RoomDetailsViewModel));
        }
        [TestMethod]
        public void HistoryPartial()
        {
            var controller = new PropertyController();
            var result = controller.HistoryPartial(1) as ViewResult;
            Assert.AreEqual("HistoryPartial", result.ViewName);
            Assert.IsInstanceOfType(result.Model, typeof(HistoryList)); 
        }
        [TestMethod]
        public void PropertyDetails()
        {
            var controller = new PropertyController();
            var result = controller.PropertyDetails(0) as ViewResult;
            Assert.AreEqual("PropertyDetails", result.ViewName);
            Assert.IsInstanceOfType(result.Model, typeof(PropertyDetailsViewModel));
        }
        [TestMethod]
        public void PropertyNotes()
        {
            var controller = new PropertyController();
            var result = controller.PropertyNotes(1) as ViewResult;
            Assert.AreEqual("PropertyNotes", result.ViewName);
            Assert.IsInstanceOfType(result.Model, typeof(PropertyNotesViewModel));
        }

        [TestMethod]
        public void LandlordDetails()
        {
            var controller = new PropertyController();
            var result = controller.LandlordDetails(1) as ViewResult;
            Assert.AreEqual("LandlordDetails", result.ViewName);
            Assert.IsInstanceOfType(result.Model, typeof(LandlordDetailsViewModel));
        }

        [TestMethod]
        public void Entities()
        {
            var controller = new PropertyController();
            var result = controller.Entities(1,2,"Insurance", "FIRTH &001", 5) as ViewResult;
            Assert.AreEqual("Entities", result.ViewName);
            Assert.IsInstanceOfType(result.Model, typeof(EntityViewModel));
        }
    }
}
