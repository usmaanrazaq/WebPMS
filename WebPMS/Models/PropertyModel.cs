using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebPMS.Models
{


    [Serializable()]
    public class Properties : List<Property>
    {

        public Property FindByNo(int PropertyID)
        {
            foreach (Property item in this) { if (item.PropertyID == PropertyID) return item; }
            return null;
        }
        public int GetNextProperty()
        {
            int PropertyID = 1;
            foreach (Property item in this) { if (item.PropertyID >= PropertyID) PropertyID = item.PropertyID + 1; }
            return PropertyID;
        }
    }

    public class Property
    {
   
        
        public Property(int PropertyID, int ParentID, string ParentNickname, int BranchID, string Status, string NickName,
                         string BuildingType, string AddressLine1, string AddressLine2, string AddressLine3, string AddressLine4, string AddressLine5,
                        string Postcode)
        {
            this.PropertyID = PropertyID;
            this.ParentID = ParentID;
            this.ParentNickName = ParentNickName;
            this.BranchID = BranchID;
            this.Status = Status;
            this.NickName = NickName;
            this.BuildingType = BuildingType;
            this.AddressLine1 = AddressLine1;
            this.AddressLine2 = AddressLine2;
            this.AddressLine3 = AddressLine3;
            this.AddressLine4 = AddressLine4;
            this.AddressLine5 = AddressLine5;
            this.PostCode = Postcode;
        }
        public int PropertyID { get; set; }
        public int ParentID { get; set; }
        public string ParentNickName { get; set; }
        public int BranchID { get; set; }
        public string Status { get; set; }
        public string NickName { get; set; }
        public string BuildingType { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string AddressLine5 { get; set; }
        public string PostCode { get; set; }
        public int DisplayIndex { get; set; }
    }

    public static class BuildProperty
    {
        public static Properties ViewProperties()
        {
            DataTable DT = DB.ReadData(Constants.StoredProcedures.Read.uspGetPropertyList, DB.StoredProcedures.uspGetPropertyList(0));
            Properties prop = new Properties();
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow R in DT.Rows)
                {
                    prop.Add(BuildPropertyFromDataRow(R));
                }

            }
            return prop;
        }

        private static Property BuildPropertyFromDataRow(DataRow dr)
        {
            return new Property(Functions.ToInt32(dr["ID"]), Functions.ToInt32(dr["ParentID"]), Functions.ToString(dr["ParentPropertyNickName"]), Functions.ToInt32(dr["BranchID"]), Functions.ToString(dr["Status"]),
                Functions.ToString(dr["Nickname"]), Functions.ToString(dr["BuildingType"]), Functions.ToString(dr["AddressLine1"]), Functions.ToString(dr["AddressLine2"]),
                Functions.ToString(dr["AddressLine3"]), Functions.ToString(dr["AddressLine4"]), Functions.ToString(dr["AddressLine5"]), Functions.ToString(dr["PostCode"]));

        }
    }
}

