using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using WebPMS;
using WebPMS.Models;

namespace WebPMS.Models
{
    public class PropertyRoom
    {
        public PropertyRoom() { }
        public PropertyRoom(int ID, int PropertyID, int Sequence, string Title, string Type, string MarketingDescription,
            string Notes, double Length, double Width, double Height, bool Habitable, bool Communal, DateTime? LastUpdatedTime,
            string LastUpdatedUser)
        {
            this.ID = ID;
            this.PropertyID = PropertyID;
            this.Sequence = Sequence;
            this.Title = Title;
            this.Type = Type;
            this.MarketingDescription = MarketingDescription;
            this.Notes = Notes;
            this.Length = Length;
            this.Width = Width;
            this.Height = Height;
            this.Habitable = Habitable;
            this.Communal = Communal;
            this.LastUpdatedTime = LastUpdatedTime;
            this.LastUpdatedUser = LastUpdatedUser;
        }

        public bool Communal { get; set; }
        public bool Habitable { get; set; }
        public double Height { get; set; }
        public int ID { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
        public string LastUpdatedUser { get; set; }
        public double Length { get; set; }
        public string MarketingDescription { get; set; }
        public string Notes { get; set; }
        public int PropertyID { get; set; }
        public int Sequence { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Type { get; set; }
        public double Width { get; set; }
    }

}
public static class BuildPropertyRoom
{

    public static PropertyRoom ViewPropertyRoom(int ID)
    {
        DataTable DT = DB.ReadData(Constants.StoredProcedures.Read.uspGetPropertyRoom, DB.StoredProcedures.uspGetPropertyRoom(ID));

        if (DT.Rows.Count > 0)
        {
            return BuildPropertyRoomByRow(DT.Rows[0]);
        }
        return null;
    }


    private static PropertyRoom BuildPropertyRoomByRow(DataRow dr)
    {
        return new PropertyRoom(Functions.ToInt32(dr["ID"]), Functions.ToInt32(dr["PropertyID"]), Functions.ToInt32(dr["Sequence"]), Functions.ToString(dr["Title"]),
            Functions.ToString(dr["Type"]), Functions.ToString(dr["MarketingDescription"]), Functions.ToString(dr["Notes"]), Functions.ToDouble(dr["Length"]),
            Functions.ToDouble(dr["Width"]), Functions.ToDouble(dr["Height"]), Functions.ToBool(dr["Habitable"]), Functions.ToBool(dr["Communal"]),
            Functions.ToDate(dr["LastUpdatedTime"]), Functions.ToString(dr["LastUpdatedUser"]));
    }

}