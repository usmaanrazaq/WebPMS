using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPMS
{
    public static class Constants
    {

        public static class StoredProcedures
        {

            public static class Read
            {
                public const string uspReadUsers = "uspReadUsers";
                public const string uspGetPropertyList = "uspGetPropertyList";
                public const string uspGetDynamicEntites = "uspGetDynamicEntities";
                public const string uspReadProperty = "uspReadProperty";
                public const string uspGetPropertyImages = "uspGetPropertyImages";
                public const string uspGetInventoryList = "uspGetInventoryList";
                public const string uspGetPropertyRoomList = "uspGetPropertyRoomList";
                public const string uspGetPropertyRoom = "uspGetPropertyRoom";
                public const string uspGetPropertyNotes = "uspGetPropertyNotes";
                public const string uspReadThirdParty = "uspReadThirdParty";
                public const string uspGetDynamicEntityFields = "uspGetDynamicEntityFields";
                public const string uspGetTenancyList = "uspGetTenancyList";
                public const string uspGetPropertyTenancies = "uspGetPropertyTenancies";
                public const string uspReadTenancy = "uspReadTenancy";
                public const string uspGetTenancyTenants = "uspGetTenancyTenants";
                public const string uspRetrieveOrg = "uspRetrieveOrg";
                public const string uspReadTenancyRequirements = "uspReadTenancyRequirements";
                public const string uspGetExistingOrgs = "uspGetExistingOrgs";
                public const string uspGetOrgDetails = "uspGetOrgDetails";
                public const string uspGetOrgContacts = "uspGetOrgContacts";
                public const string uspGetExistingPeople = "uspGetExistingPeople";
                public const string uspRetrieveTasksByUser  =  "uspRetrieveTasksByUser";
                public const string uspRetrieveUsers = "uspRetrieveUsers";
                public const string uspRetrieveTask = "uspRetrieveTask";
                public const string uspGetNewPersonID = "uspGetNewPersonID";
                public const string UspGetNewOrgID = "UspGetNewOrgID";
            }
            public static class Update
            {
                public const string uspUpdateProperty = "uspUpdateProperty";
                public const string uspUpdatePropertyRoom = "uspUpdatePropertyRoom";
                public const string uspAppendPropertyNotes = "uspAppendPropertyNotes";
                public const string uspUpdateThirdParty = "uspUpdateThirdParty";
                public const string uspUpdateDynamicData = "uspUpdateDynamicData";
                public const string uspUpdateOrg = "uspUpdateOrg";
                public const string uspUpdateTenancyDetails = "uspUpdateTenancyDetails";
                public const string uspUpdateTenancyTenants = "uspUpdateTenancyTenants";
                public const string uspUpdateTenancyRequirements = "uspUpdateTenancyRequirements";
                public const string uspUpdateDynamicOrg = "uspUpdateDynamicOrg";           
                public const string uspUpdateTask = "uspUpdateTask";
                public const string uspUpdatePropertyImage = "uspUpdatePropertyImage";

            }
            public static class Insert
            {
                public const string uspInsertTask = "uspInsertTask";
                public const string uspInsertThirdParty = "uspInsertThirdParty";
                public const string uspInsertOrg = "uspInsertOrg";
                public const string uspInsertOrgContact = "uspInsertOrgContact";
            }

            public static class Delete {
                public const string uspDeleteProperty = "uspDeleteProperty";
                public const string uspDeletePropertyImage = "uspDeletePropertyImage";
                public const string uspDeleteTenancy = "uspDeleteTenancy";
                public const string uspDeletePropertyRoom = "uspDeletePropertyRoom";
                public const string uspDeleteTenancyTenants = "uspDeleteTenancyTenants";
            }
        }

        public static class DynamicEntities
        {
            //Dynamic Entities
            public const string Dynamic_EntityOrg = "O";
            public const string Dynamic_EntityPerson = "T";
            public const string Dynamic_EntityDetails = "D";
        }

        public static class CaseType
        {
            public const string CaseType_Property = "P";
            public const string CaseType_Property_Room = "R";

        }
        public static class SubCaseType
        {
            public const string CaseSubType_Property = "PA";
        }

        public class ImageTypes
        {
            public const string ImageType_Property = "P";
            public const string ImageType_Room = "R";
            public const string ImageType_Tenancy = "T";
            public const string ImageType_Inventory = "I";

        }
    }
}