using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebPMS.Models;
using WebPMS;

namespace WebPMS.Models
{
    public class PropertyImages : List<PropertyImage>
    {

        public PropertyImage FindByNo(int ID)
        {
            foreach (PropertyImage item in this) { if (item.ID == ID) return item; }
            return null;
        }

    }


        public class PropertyImage
    {
        public PropertyImage(int ID, int PropertyID, int TenancyID, int RoomID, int InventoryID,
            string Type, string Title, string Description, string Filename, int Sequence, DateTime? DateAdded )
        {
            this.ID = ID;
            this.PropertyID = PropertyID;
            this.TenancyID = TenancyID;
            this.RoomID = RoomID;
            this.InventoryID = InventoryID;
            this.Type = Type;
            this.Title = Title;
            this.Description = Description;
            this.Filename = Filename;
            this.Sequence = Sequence;
            this.DateAdded = DateAdded;
        }

        public DateTime? DateAdded { get;  set; }
        public string Description { get;  set; }
        public string Filename { get;  set; }
        public int ID { get;  set; }
        public int InventoryID { get;  set; }
        public int PropertyID { get;  set; }
        public int RoomID { get;  set; }
        public int Sequence { get;  set; }
        public int TenancyID { get;  set; }
        public string Title { get;  set; }
        public string Type { get;  set; }
        
        public string _tenancyPath { get; set; }
    }
}
public static class BuildPropertyImages
{
    

        public static PropertyImages ViewPropertyImages(string Type, int PropertyID, int RoomID, int TenancyID, int InventoryID, string path = "" )
        {
            DataTable DT = DB.ReadData(Constants.StoredProcedures.Read.uspGetPropertyImages, DB.StoredProcedures.uspGetPropertyImages(Type,PropertyID, RoomID, TenancyID, InventoryID));
            PropertyImages prop = new PropertyImages();
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow R in DT.Rows)
                {
                PropertyImage img = BuildPropertyImageFromDataRow(R);
                img._tenancyPath = path;
                    prop.Add(img);
                }

            }
            return prop;
        }
 


    private static PropertyImage BuildPropertyImageFromDataRow(DataRow dr)
    {

        return new PropertyImage(Functions.ToInt32(dr["ID"]), Functions.ToInt32(dr["PropertyID"]), Functions.ToInt32(dr["TenancyID"]), Functions.ToInt32(dr["RoomID"]),
            Functions.ToInt32(dr["InventoryID"]), Functions.ToString(dr["Type"]), Functions.ToString(dr["Title"]), Functions.ToString(dr["Description"]), Functions.ToString(dr["Filename"]), Functions.ToInt32(dr["Sequence"]), Functions.ToDate(dr["DateAdded"]));

    }

}