using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebPMS.Models
{


    [Serializable()]
    public class DynamicEntities : List<DynamicEntity>
    {

        public DynamicEntity FindByNo(int EntityID)
        {
            foreach (DynamicEntity item in this) { if (item.ID == EntityID) return item; }
            return null;
        }
    }

    public class DynamicEntity
    {
   
        public DynamicEntity() { }
        public DynamicEntity(int ID, string EntityType, string EntityLabel, string Parent, bool MultiplePerCase, int DynamicOrgID, int OrgFKID, string OrgID,
            string OrgContactID, string OrgRef, int DynamicPersonID, int PersonFKID, string ThirdPartyID, string PersonRef, int SectionHeaderID, 
            string EntityName, string AccessLevel, string LetterFolder   )
        {
            this.ID = ID;
            this.EntityType = EntityType;
            this.EntityLabel = EntityLabel;
            this.Parent = Parent;
            this.MultiplePerCase = MultiplePerCase;
            this.DynamicOrgID = DynamicOrgID;
            this.OrgFKID = OrgFKID;
            this.OrgID = OrgID;
            this.OrgContactID = OrgContactID;
            this.OrgRef = OrgRef;
            this.DynamicPersonID = DynamicPersonID;
            this.PersonFKID = PersonFKID;
            this.ThirdPartyID = ThirdPartyID;
            this.PersonRef = PersonRef;
            this.SectionHeaderID = SectionHeaderID;
            this.EntityName = EntityName;
            this.AccessLevel = AccessLevel;
            this.LetterFolder = LetterFolder;
        }


        public int ID { get; set; }
        public string EntityType { get; set; }
        public string EntityLabel { get; set; }
        public string Parent { get; set; }
        public bool MultiplePerCase { get; set; }
        public int DynamicOrgID { get; set; }
        public int OrgFKID { get; set; }
        public string OrgID { get; set; }
        public string OrgContactID { get; set; }
        public string OrgRef { get; set; }
        public int DynamicPersonID { get; set; }
        public int PersonFKID { get; set; }
        public string ThirdPartyID { get; set; }
        public string PersonRef { get; set; }
        public int SectionHeaderID { get; set; }
        public string EntityName { get; set; }
        public string AccessLevel { get; set; }
        public string LetterFolder { get; set; }

    }

    public static class BuildEntities
    {
        public static DynamicEntities ViewEntities(int PropertyID)
        {
            DataTable DT = DB.ReadData(Constants.StoredProcedures.Read.uspGetDynamicEntites, DB.StoredProcedures.uspGetDynamicEntities(Constants.CaseType.CaseType_Property, Constants.SubCaseType.CaseSubType_Property, PropertyID));
            DynamicEntities DE = new DynamicEntities();
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow R in DT.Rows)
                {
                    DE.Add(BuildDEFromDataRow(R));
                }

            }
            return DE;
        }

        private static DynamicEntity BuildDEFromDataRow(DataRow dr)
        {
            return new DynamicEntity(Functions.ToInt32(dr["ID"]), Functions.ToString(dr["EntityType"]), Functions.ToString(dr["EntityLabel"]), Functions.ToString(dr["Parent"]), Functions.ToBool(dr["MultiplePerCase"]), Functions.ToInt32(dr["DynamicOrgId"]),
                Functions.ToInt32(dr["OrgFKID"]),Functions.ToString(dr["OrgID"]), Functions.ToString(dr["OrgContactID"]), Functions.ToString(dr["OrgRef"]), Functions.ToInt32(dr["DynamicPersonID"]), Functions.ToInt32(dr["PersonFKID"]), Functions.ToString(dr["ThirdPartyID"]),
                Functions.ToString(dr["PersonRef"]), Functions.ToInt32(dr["SectionHeaderID"]), Functions.ToString(dr["EntityName"]), Functions.ToString(dr["AccessLevel"]), Functions.ToString(dr["LetterFolder"]));

        }
    }
}

