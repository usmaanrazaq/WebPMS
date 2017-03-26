using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPMS.Models;
using Newtonsoft.Json;
namespace WebPMS.Controllers
{
    public class TenancyController : Controller
    {
        // GET: Tenancy
        public ActionResult Tenants()
        {
            if (TempData["Confirmation"] != null)
            {
                ViewBag.showPopup = true;
                ViewBag.Confirmation = TempData["Confirmation"];
            }      
            return View();
        }
        public ActionResult Tenancies()
        {
            if (TempData["Confirmation"] != null)
            {
                ViewBag.showPopup = true;
                ViewBag.Confirmation = TempData["Confirmation"];
            }
            return View();
        }

        public ActionResult TenancyRequirements(int PropertyID)
        {
            if (TempData["Confirmation"] != null)
            {
                ViewBag.showPopup = true;
                ViewBag.Confirmation = TempData["Confirmation"];
            }
            if (PropertyID != 0)
            {
                DynamicEntities Entities = BuildEntities.ViewEntities(PropertyID);
                var SideNavModel = new SideNavigationViewModel
                {
                    DynamicEntities = Entities,
                    PropertyID = PropertyID,
                };

                var model = new TenancyRequirementViewModel
                {
                    SideNavigationViewModel = SideNavModel,
                    Requirement = BuildTenancyRequirement.ViewTenancyRequirement(PropertyID),
                    PropertyID = PropertyID
                };

                return View(model);
            }
            return RedirectToAction("PropertyDetails","Property", new { PropertyID = 0 });
        }
        public ActionResult TenancyDetails(int PropertyID)
        {
            if (TempData["Confirmation"] != null)
            {
                ViewBag.showPopup = true;
                ViewBag.Confirmation = TempData["Confirmation"];
            }
            if (PropertyID != 0)
            {
                DynamicEntities Entities = BuildEntities.ViewEntities(PropertyID);
                var SideNavModel = new SideNavigationViewModel
                {
                    DynamicEntities = Entities,
                    PropertyID = PropertyID,
                };

                TenancyDetail TenancyDetail = new TenancyDetail();
                Organisation Tenant = new Organisation();
                var model = new TenancyDetailsViewModel
                {
                    PropertyTenancies = GetPropertyTenancyList(PropertyID, ref TenancyDetail),
                    TenancyDetail = TenancyDetail,
                    TenancyTenantsViewModel = new TenancyTenantsViewModel
                    {
                        TenancyTenants = GetTenancyTenantsList(TenancyDetail.ID, ref Tenant),
                        Tenant = Tenant,
                    },
                    Images = GetTenancyImages(PropertyID, TenancyDetail.ID),
                    SideNavigationViewModel = SideNavModel,
                    TenancyID = TenancyDetail.ID,
                    PropertyID = PropertyID,

                };
                return View(model);
            }
            return RedirectToAction("PropertyDetails","Property", new { PropertyID = 0 });
            
        }

        private PropertyImages GetTenancyImages(int PropertyID, int TenancyID)
        {
            PropertyRoomList RoomList = BuildPropertyRoomList.ViewPropertyRoomList(PropertyID);
            PropertyImages Images = new PropertyImages();

            foreach (PropertyRoomItem room in RoomList)
            {
                string path = "/Insight/Property " + PropertyID.ToString() + "/Tenancy " + TenancyID.ToString() + "/Room " + room.ID;
                DirectoryInfo di = Directory.CreateDirectory(Server.MapPath(path));
                Images.AddRange(BuildPropertyImages.ViewPropertyImages(Constants.ImageTypes.ImageType_Tenancy, PropertyID, room.ID, TenancyID, 0, path));
            }
            return Images;
        }
        private IEnumerable<SelectListItem> GetTenancyTenantsList(int TenancyID, ref Organisation Tenant)
        {
            TenancyTenants TenancyTenants = BuildTenancyTenant.ViewTenancyTenants(TenancyID);
            if(TenancyTenants.Count > 0)
                Tenant = BuildOrganisations.ViewOrganisation(TenancyTenants[0].TenantID, 0);
            var tenancy = TenancyTenants.Select(x =>
                                new SelectListItem
                                {
                                    Value = x.TenantID,
                                    Text = x.Name
                                });

            return new SelectList(tenancy, "Value", "Text");
        }
        private IEnumerable<SelectListItem> GetPropertyTenancyList(int PropertyID, ref TenancyDetail TenancyDetail) // passing by reference so this function can set the value of the tenancy detail to show first result
        {
            PropertyTenancies Tenancies = new PropertyTenancies();
            
                Tenancies = BuildPropertyTenancy.ViewPropertyTenancies(PropertyID);
                if(Tenancies.Count > 0)
                    TenancyDetail = BuildTenancyDetail.ViewTenancyDetail(Tenancies[0].ID); // PRESELECT FIRST OPTION ALL THE TIME
            
                var tenancy = Tenancies.Select(x =>
                                    new SelectListItem
                                    {
                                        Value = x.ID.ToString(),
                                        Text = x._comboDisplay
                                    });

                return new SelectList(tenancy, "Value", "Text", TenancyDetail.ID.ToString());
            
         
           
           
        }



        [ValidateInput(false)]
        public ActionResult gvTenants_Partial(int pPropID = -1)
        {

            if (pPropID == -1)
            {
                var model = BuildTenancy.ViewTenants(1, false, false);
                return PartialView("_gvTenants_Partial", model);
            }
            else
            {
                return RedirectToAction("TenancyDetails", new { PropertyID = pPropID });
            }
        }

        [ValidateInput(false)]
        public ActionResult gvTenancy_Partial(int pPropID = -1)
        {
            if (pPropID == -1)
            {
                var model = BuildTenancy.ViewTenants(1, false, true);
                return PartialView("_gvTenancy_Partial", model);
            }
            else
            {
                return RedirectToAction("TenancyDetails", new { PropertyID = pPropID });
            }

        }
        [HttpPost]
        public ActionResult SaveTenancyDetails(TenancyDetailsViewModel TenancyDetailsViewModel)
        {

            // saving tenancy details goes an
            int updateInt = 0;
            if (TenancyDetailsViewModel.PropertyID != 0)
            {
                if (string.IsNullOrEmpty(TenancyDetailsViewModel.TenancyTenantsViewModel.Tenant.ID))// CREATE NEW TENANT 
                {
                    TenancyDetailsViewModel.TenancyTenantsViewModel.Tenant.ID = Functions.GenerateOrgID(TenancyDetailsViewModel.TenancyTenantsViewModel.Tenant.Name);
                    TenancyDetailsViewModel.TenancyTenantsViewModel.Tenant.TypeOfOrganisation = "Tenant";
                    DB.UpdateData(Constants.StoredProcedures.Insert.uspInsertOrg, DB.StoredProcedures.uspInsertOrg(TenancyDetailsViewModel.TenancyTenantsViewModel.Tenant, SessionManager.getCurrentUser().ID), ref updateInt);                

                    
                }else
                {
                    if (DB.UpdateData(Constants.StoredProcedures.Update.uspUpdateOrg, DB.StoredProcedures.uspUpdateOrg(TenancyDetailsViewModel.TenancyTenantsViewModel.Tenant, SessionManager.getCurrentUser().ID),ref updateInt) == 1)
                    {//Upading Org, if passed move to next update                     
                       
                    }
                }
                
                if(TenancyDetailsViewModel.TenancyDetail.PropertyID == 0) // if new attach to property currently viewing
                {
                    TenancyDetailsViewModel.TenancyDetail.PropertyID = TenancyDetailsViewModel.PropertyID;                    
                }
                if (DB.UpdateData(Constants.StoredProcedures.Update.uspUpdateTenancyDetails, DB.StoredProcedures.uspUpdateTenancyDetails(TenancyDetailsViewModel.TenancyDetail, SessionManager.getCurrentUser().ID),ref updateInt) == 1) //Upading Org, if passed move to next update  
                {
                    DB.UpdateData(Constants.StoredProcedures.Update.uspUpdateTenancyTenants, DB.StoredProcedures.uspUpdateTenancyTenants(0, updateInt, TenancyDetailsViewModel.TenancyTenantsViewModel.Tenant.ID, "Asad"), ref updateInt);
                    TempData["Confirmation"] = "Tenancy & Tenant Details  Saved Succesfully!";                   
                    return RedirectToAction("Tenants");

                }               
            }
            return Json("ERROR");
        }

        [HttpPost]
        public ActionResult SaveRequirements(TenancyRequirementViewModel TenancyRequirementViewModel)
        {
            int updateInt = 0;
            if (TenancyRequirementViewModel.PropertyID != 0)
            {
                TenancyRequirementViewModel.Requirement.PropertyID = TenancyRequirementViewModel.PropertyID;
                if (DB.UpdateData(Constants.StoredProcedures.Update.uspUpdateTenancyRequirements, DB.StoredProcedures.uspUpdateTenancyRequirements(TenancyRequirementViewModel.Requirement, SessionManager.getCurrentUser().ID),ref updateInt) == 1)
                {
                   
                    TempData["Confirmation"] = "Requirements Saved Succesfully!";
                    return RedirectToAction("TenancyDetails", new { PropertyID = TenancyRequirementViewModel.Requirement.PropertyID });
                }
            }
            return Json("ERROR");
        }
    }


}