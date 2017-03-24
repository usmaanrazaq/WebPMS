using DevExpress.Web.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using WebPMS.Models;
using Newtonsoft.Json;

namespace WebPMS.Controllers
{
    public class PropertyController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        // GET: Property
        public ActionResult Home()
        {
            // Retrieve
            //  Properties prop = 

            return View();
        }





        [ValidateInput(false)]
        public ActionResult gvPropertiesPartial(int pPropID = -1)
        {

            if (pPropID == -1)
            {
                Properties model = BuildProperty.ViewProperties();
                return PartialView("_gvPropertiesPartial", model);
            }
            else
            {
                return RedirectToAction("PropertyDetails", new { PropertyID = pPropID });

            }

        }

        private IEnumerable<SelectListItem> GetRoomList(int PropertyID)
        {
            PropertyRoomList RoomList = BuildPropertyRoomList.ViewPropertyRoomList(PropertyID);
            var Room = RoomList.Select(x =>
                                new SelectListItem
                                {
                                    Value = x.ID.ToString(),
                                    Text = x.Title
                                });

            return new SelectList(Room, "Value", "Text");
        }

        [HttpGet]
        public ActionResult RoomDetailsSelected(int RoomID)
        {
            if (RoomID == 0)
            {
                var Empty = new RoomDetailsViewModel
                {

                    PropertyRoom = new PropertyRoom(),
                    PropertyImages = new PropertyImages(),
                    InventoryList = new InventoryList(),

                    PropertyPath = "",
                };
                return PartialView("_RoomDetailsPartial", Empty);
            }
            //SELECTED ROOM BY DROPDOWN LIST
            PropertyRoom Room = BuildPropertyRoom.ViewPropertyRoom(RoomID);
            string path = "/Insight/Property " + Room.PropertyID.ToString() + "/Room " + RoomID.ToString();
            PropertyImages Images = BuildPropertyImages.ViewPropertyImages(Constants.CaseType.CaseType_Property_Room, Room.PropertyID, RoomID, 0, 0);
            InventoryList InvList = BuildInventoryList.ViewInventoryList(Constants.CaseType.CaseType_Property_Room, Room.PropertyID, RoomID, 0);
            var model = new RoomDetailsViewModel
            {
                PropertyRoom = Room,
                PropertyImages = Images,
                InventoryList = InvList,
                PropertyPath = path,

            };
            return PartialView("_RoomDetailsPartial", model);

        }
        public ActionResult RoomDetails(int PropertyID)
        {
            DynamicEntities Entities = BuildEntities.ViewEntities(PropertyID);


            var SideNavModel = new SideNavigationViewModel
            {
                DynamicEntities = Entities,
                PropertyID = PropertyID,
            };

            var Emptymodel = new RoomDetailsViewModel
            {
                PropertyRoomList = GetRoomList(PropertyID),
                PropertyRoom = new PropertyRoom(),
                PropertyImages = new PropertyImages(),
                InventoryList = new InventoryList(),
                SideNavigationViewModel = SideNavModel,
                PropertyPath = "",
                PropertyID = PropertyID
            };
            return View(Emptymodel);
        }



        public ActionResult PropertyDetails(int PropertyID)
        {

            if (PropertyID != 0)
            {
             
                string path = "/Insight/Property " + PropertyID.ToString();
                DirectoryInfo di = Directory.CreateDirectory(Server.MapPath(path));

                DynamicEntities Entities = BuildEntities.ViewEntities(PropertyID);
                var SideNavModel = new SideNavigationViewModel
                {
                    DynamicEntities = Entities,
                    PropertyID = PropertyID,
                };

                PropertyDetail Detail = BuildProperyDetail.ViewProperty(PropertyID);
                PropertyImages Images = BuildPropertyImages.ViewPropertyImages(Constants.SubCaseType.CaseSubType_Property, PropertyID, 0, 0, 0);
                InventoryList InvList = BuildInventoryList.ViewInventoryList(Constants.SubCaseType.CaseSubType_Property, PropertyID, 0, 0);
                var model = new PropertyDetailsViewModel
                {
                    PropertyID = PropertyID,
                    PropertyDetail = Detail,
                    PropertyImages = Images,
                    InventoryList = InvList,
                    PropertyPath = path,
                    SideNavigationViewModel = SideNavModel,
                    SubUnitOf = GetPropertyList()
                };

                return View(model);
            }else
            {
                var SideNavModel = new SideNavigationViewModel
                {
                    DynamicEntities = new DynamicEntities(),                                     
                };
                var model = new PropertyDetailsViewModel
                {
                    PropertyID = 0,
                    PropertyDetail = new PropertyDetail(),
                    PropertyImages = new PropertyImages(),
                    InventoryList = new InventoryList(),
                    PropertyPath = "",
                    SideNavigationViewModel = SideNavModel,
                    SubUnitOf = GetPropertyList()
                };
                return View(model);
            }
         
        }
        private IEnumerable<SelectListItem> GetPropertyList()
        {
            Properties Properties = BuildProperty.ViewProperties();
           
            var property = Properties.Select(x =>
                                new SelectListItem
                                {
                                    Value = x.PropertyID.ToString(),
                                    Text = x.NickName
                                });

            return new SelectList(property, "Value", "Text");
        }
        public ActionResult PropertyNotes(int PropertyID)
        {
            if (PropertyID != 0)
            {
                DynamicEntities Entities = BuildEntities.ViewEntities(PropertyID);
                var SideNavModel = new SideNavigationViewModel
                {
                    DynamicEntities = Entities,
                    PropertyID = PropertyID,
                };
                PropertyNotes PropertyNotes = BuildPropertyNotes.ViewPropertyNotes(PropertyID);

                PropertyNotesViewModel model = new PropertyNotesViewModel
                {
                    PropertyID = PropertyID,
                    PropertyNotes = PropertyNotes,
                    SideNavigationViewModel = SideNavModel
                };
                return View(model);
            }
            else
            {
                return View("Index", "Home");
            }
        }

        public ActionResult LandlordDetails(int PropertyID)
        {
              DynamicEntities Entities = BuildEntities.ViewEntities(PropertyID);

                var SideNavModel = new SideNavigationViewModel
                {
                    DynamicEntities = Entities,
                    PropertyID = PropertyID,
                };
            if (PropertyID != 0)
            {
                PropertyDetail Detail = BuildProperyDetail.ViewProperty(PropertyID);
                ThirdParty LandlordDetails = BuildThirdParty.ViewThirdParty(Detail.LandlordID);
              
                LandlordDetailsViewModel modelUpdate = new LandlordDetailsViewModel
                {
                    PropertyID = PropertyID,
                    ThirdParty = LandlordDetails,
                    SideNavigationViewModel = SideNavModel

                };
                return View(modelUpdate);
            }

            LandlordDetailsViewModel model = new LandlordDetailsViewModel
            {
                PropertyID = 0,
                ThirdParty = new ThirdParty(),
                SideNavigationViewModel = SideNavModel

            };
            return View(model);
        }



        public ActionResult EntityDetailsD(int PropertyID, int EntityID, string EntityName, string OrgID, string PersonID)
        {
            DynamicEntities Entities = BuildEntities.ViewEntities(PropertyID);

            var SideNavModel = new SideNavigationViewModel
            {
                DynamicEntities = Entities,
                PropertyID = PropertyID,
            };
            DynamicEntityFields DEF = BuildDynamicEntityFields.ViewDynamicEntityFields(Constants.CaseType.CaseType_Property, Constants.SubCaseType.CaseSubType_Property, EntityID, EntityName, PropertyID, OrgID, PersonID);

            DynamicEntityFieldsViewModel model = new DynamicEntityFieldsViewModel
            {
                PropertyID = PropertyID,
                DynamicEntityFields = DEF,
                SideNavigationViewModel = SideNavModel

            };
            return View(model);
        }

        public ActionResult Entities(int PropertyID, int EntityID, string EntityName, string OrgID, int DynamicOrgID)
        {
            DynamicEntities Entities = BuildEntities.ViewEntities(PropertyID);

            var SideNavModel = new SideNavigationViewModel
            {
                DynamicEntities = Entities,
                PropertyID = PropertyID,
            };
            DynamicEntityFields DEF = BuildDynamicEntityFields.ViewDynamicEntityFields(Constants.CaseType.CaseType_Property, Constants.SubCaseType.CaseSubType_Property, EntityID, EntityName, PropertyID, OrgID, null);
            Organisations ExsistingOrgs = BuildOrganisations.ViewExsistingOrgs("", EntityName, false, "All");

            Organisation orgDetails = new Organisation(); //DropDownDetail for ExsistingORgs
            ThirdParties orgContacts = new ThirdParties(); // orgContacts Dorpdown
            ThirdParty orgContactDetail = new ThirdParty(); // Dropdown for orgcontactDetails

            var EntityOrgViewModel = new EntityOrgViewModel
            {
                orgDetail = new Organisation(),
                orgContacts = GetOrgContactList(orgContacts),
                orgContactDetail = orgContactDetail
            };
     

            var model = new EntityViewModel
            {
                SideNavigationViewModel = SideNavModel,
                PropertyID = PropertyID,
                DEF = DEF,
                Organisations = GetOrgsList(ExsistingOrgs),
                EntityOrgViewModel =  EntityOrgViewModel,
                EntityName = EntityName,
                DynamicOrgID = DynamicOrgID

            };

            return View(model);

        }


        public ActionResult SaveEntity(int PropertyID, Organisation orgDetail, int? DynamicOrgID, string ID, DynamicEntityFields DEF)
        {
            int updateInt = 0;
            if (PropertyID != 0)
            {
                if (DynamicOrgID == 0)// insert
                {
                    DynamicOrgID = null;
                }           

                if (DB.UpdateData(Constants.StoredProcedures.Update.uspUpdateDynamicOrg, DB.StoredProcedures.uspUpdateDynamicOrg(DynamicOrgID, PropertyID, orgDetail.ID, ID, null, DynamicOrgID), ref updateInt) == 1)
                {
                    ViewBag.showPopup = "true";
                    ViewBag.Confirmation = orgDetail.Name +  " Saved Succesfully!";
                    if (DEF != null)
                    {
                        foreach(DynamicEntityField d in DEF)
                        {
                            if (DB.UpdateData(Constants.StoredProcedures.Update.uspUpdateDynamicData, DB.StoredProcedures.uspUpdateDynamicData(0, DynamicOrgID, null, PropertyID, d.ID, d.FieldValue, null), ref updateInt) == 1)
                            {
                                ViewBag.Confirmation = orgDetail.Name + " Saved Succesfully! ";
                            }
                        }
                    }

                }
                return View("Home");
            }
            else
            {
                return Json("Error");
            }


       
        }
        
        public ActionResult EntitySelected(string orgDetailID)
        {
            Organisation orgDetails = BuildOrganisations.ViewOrgDetail(orgDetailID, false);
            ThirdParties orgContacts = BuildThirdParty.ViewOrgContacts(orgDetails.ID);
            var model = new EntityOrgViewModel
            {
                orgDetail = orgDetails,
                orgContacts = GetOrgContactList(orgContacts),
                orgContactDetail = new ThirdParty()
            };            
            return PartialView("_EntityDetailsPartial", model);
        }
        public ActionResult EntityContactSelected(string ID)
        { 
            ThirdParty orgContactDetail = BuildThirdParty.ViewExsistingPeople(ID);
        
            return PartialView("_EntityContactDetailsPartial", orgContactDetail);
        }


        private IEnumerable<SelectListItem> GetOrgsList(Organisations ExsistingOrgs)
        {
          
            var org = ExsistingOrgs.Select(x =>
                                new SelectListItem
                                {
                                    Value = x.ID.ToString(),
                                    Text = x.Name
                                });

            return new SelectList(org, "Value", "Text");
        }
        private IEnumerable<SelectListItem> GetOrgContactList(ThirdParties orgContactList)
        {
            
            var org = orgContactList.Select(x =>
                                new SelectListItem
                                {
                                    Value = x.ID.ToString(),
                                    Text = x.Name
                                });

            return new SelectList(org, "Value", "Text");
        }


        [HttpPost]
        public ActionResult SaveDetails(PropertyDetailsViewModel PropertyDetailsViewModel)
        {

            int updateInt = 0;
            PropertyDetailsViewModel.PropertyDetail.BranchID = 1;
            if (DB.UpdateData(Constants.StoredProcedures.Update.uspUpdateProperty, DB.StoredProcedures.uspUpdateProperty(PropertyDetailsViewModel.PropertyDetail, PropertyDetailsViewModel.PropertyID, SessionManager.getCurrentUser().ID),ref updateInt) == 1)
            {
                ViewBag.showPopup = "true";
                ViewBag.Confirmation = PropertyDetailsViewModel.PropertyDetail.NickName + " Saved Succesfully!";
                return View("Home");
            }

            return View("Home");
        }
        [HttpPost]
        public ActionResult SaveRoom(RoomDetailsViewModel RoomDetailsViewModel)
        {
            int updateInt = 0;
            RoomDetailsViewModel.PropertyRoom.PropertyID = RoomDetailsViewModel.PropertyID;
            if (DB.UpdateData(Constants.StoredProcedures.Update.uspUpdatePropertyRoom, DB.StoredProcedures.uspUpdatePropertyRoom(RoomDetailsViewModel.PropertyRoom, "Asad"),ref updateInt) == 1)
            {                
                ViewBag.showPopup = "true";
                ViewBag.Confirmation = RoomDetailsViewModel.PropertyRoom.Title + " Saved Succesfully!";
                return View("Home");
            }

          
              
            

            return Json("ERROR");
        }

        [HttpPost]
        public ActionResult SaveNote(string Note, int PropertyID)
        {
            int updateInt = 0;
            string newNote = DateTime.Now.ToString("ddMMMyy HH:mm") + " (" + SessionManager.getCurrentUser().ID + ")" + Note;
            if (DB.UpdateData(Constants.StoredProcedures.Update.uspAppendPropertyNotes, DB.StoredProcedures.uspAppendPropertyNotes(PropertyID, newNote), ref updateInt) == 1)
                ViewBag.showPopup = "true";
            ViewBag.Confirmation = Note + " Saved Succesfully!";
            return View("Home");

            return Json("Error");
        }


        [HttpPost]
        public ActionResult SaveLandord(LandlordDetailsViewModel LandlordDetailsViewModel, string note)
        {
            int updateInt = 0;
            if (!string.IsNullOrEmpty(LandlordDetailsViewModel.ThirdParty.ID))
            {
                string newNote = DateTime.Now.ToString("ddMMMyy HH:mm") + " (" + SessionManager.getCurrentUser().ID + ")" + note;
                LandlordDetailsViewModel.ThirdParty.Notes += newNote;
                if (DB.UpdateData(Constants.StoredProcedures.Update.uspUpdateThirdParty, DB.StoredProcedures.uspUpdateThirdParty(LandlordDetailsViewModel.ThirdParty, SessionManager.getCurrentUser().ID),ref updateInt) == 1)
                {
                    ViewBag.showPopup = "true";
                    ViewBag.Confirmation = LandlordDetailsViewModel.ThirdParty.ID + " Saved Succesfully!";
                    return View("Home");
                }
            }else // new landlord
            {
                string newNote = DateTime.Now.ToString("ddMMMyy HH:mm") + " (" + SessionManager.getCurrentUser().ID + ")" + note;
                LandlordDetailsViewModel.ThirdParty.Notes += newNote;
                LandlordDetailsViewModel.ThirdParty.TypeOfPerson = "Landlord";
          
                LandlordDetailsViewModel.ThirdParty.ID = Functions.GenerateThirdPartyID(LandlordDetailsViewModel.ThirdParty.Title, LandlordDetailsViewModel.ThirdParty.MiddleName, LandlordDetailsViewModel.ThirdParty.Forename, LandlordDetailsViewModel.ThirdParty.Surname);
                if (!String.IsNullOrEmpty(DB._UpdateDataS(Constants.StoredProcedures.Insert.uspInsertThirdParty, DB.StoredProcedures.uspInsertThirdParty(LandlordDetailsViewModel.ThirdParty, SessionManager.getCurrentUser().ID))))
                {

                    PropertyDetail property = BuildProperyDetail.ViewProperty(LandlordDetailsViewModel.PropertyID);
                    property.LandlordID = LandlordDetailsViewModel.ThirdParty.ID;
                    property.LandlordID = LandlordDetailsViewModel.ThirdParty.TypeOfPerson = "Landlord";
                    if (DB.UpdateData(Constants.StoredProcedures.Update.uspUpdateProperty, DB.StoredProcedures.uspUpdateProperty(property, LandlordDetailsViewModel.PropertyID, SessionManager.getCurrentUser().ID), ref updateInt) == 1)
                    {
                        ViewBag.showPopup = "true";
                        ViewBag.Confirmation = LandlordDetailsViewModel.ThirdParty.ID + " Saved Succesfully!";
                        return View("Home");
                    }
                    return View("Home");
                }
            }

            return Json("Error");

        }
    }
    
}