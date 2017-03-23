using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebPMS.Models
{

    public class InventoryList : List<InventoryItem>
    {
        public InventoryItem FindByNo(int ID)
        {
            foreach (InventoryItem item in this) { if (item.ID == ID) return item; }
            return null;
        }
    }
    public class InventoryItem
    {
        public InventoryItem(int ID, int PropertyID, int TenacyID, int RoomID, string EquipmentID,
            string Make, string Model, string Description)
        {
            this.ID = ID;
            this.PropertyID = PropertyID;
            this.TenacyID = TenacyID;
            this.RoomID = RoomID;
            this.EquipmentID = EquipmentID;
            this.Make = Make;
            this.Model = Model;
            this.Description = Description;
        }

        public string Description { get; private set; }
        public string EquipmentID { get; private set; }
        public int ID { get; private set; }
        public string Make { get; private set; }
        public string Model { get; private set; }
        public int PropertyID { get; private set; }
        public int RoomID { get; private set; }
        public int TenacyID { get; private set; }
    }



public static class BuildInventoryList
    {

        public static InventoryList ViewInventoryList(string Type, int PropertyID, int RoomID, int TenancyID)
        {
            DataTable DT = DB.ReadData(Constants.StoredProcedures.Read.uspGetInventoryList, DB.StoredProcedures.uspGetInventoryList(Type,PropertyID, RoomID, TenancyID));
            InventoryList prop = new InventoryList();
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow R in DT.Rows)
                {
                    prop.Add(BuildInvListByRow(R));
                }

            }
            return prop;
        }

        private static InventoryItem BuildInvListByRow(DataRow dr)
        {
            return new InventoryItem(Functions.ToInt32(dr["ID"]), Functions.ToInt32(dr["PropertyID"]), Functions.ToInt32(dr["TenancyID"]), Functions.ToInt32(dr["RoomID"]), Functions.ToString(dr["EquipmentID"]),
                Functions.ToString(dr["Make"]), Functions.ToString(dr["Model"]), Functions.ToString(dr["Description"]));
        }
    }
}