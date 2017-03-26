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
    public class PropertyDetail
    {

        public PropertyDetail() { }
        public PropertyDetail(string Status, int BranchID, string BuildingType, string NickName, string Description, string MarketingDescription,
                         string size, string AddressLine1, string AddressLine2, string AddressLine3, string AddressLine4, string AddressLine5,
                        string Postcode, double Latitude, double Longtitude, string Notes, string AccessInformation, int YearBuilt, int Garages,
                        int ParkingSpaces, int SmokeAlarms, bool HouseAlarm, string LandlordID, double CurrentValue,  DateTime? ValuationDate,
                        string ValuationNotes, string PurchaseType, double PurchasePrice, DateTime? PurchaseDate, string PurchaseNotes, double SalePrice, 
                        DateTime? SaleDate, string SaleNotes, DateTime? LeaseStart, DateTime? LeaseEnd, string LeaseNotes, string TemplateType, DateTime? LastUpdatedTime, string LastUpdatedUser, int ParentID )
        {
            this.Status = Status;
            this.BranchID = BranchID;
            this.BuildingType = BuildingType;
            this.NickName = NickName;
            this.Description = Description;
            this.MarketingDescription = MarketingDescription;
            this.size = size;
            this.AddressLine1 = AddressLine1;
            this.AddressLine2 = AddressLine2;
            this.AddressLine3 = AddressLine3;
            this.AddressLine4 = AddressLine4;
            this.AddressLine5 = AddressLine5;
            this.Postcode = Postcode;
            this.Latitude = Latitude;
            this.Longtitude = Longtitude;
            this.Notes = Notes;
            this.AccessInformation = AccessInformation;
            this.YearBuilt = YearBuilt;
            this.Garages = Garages;
            this.ParkingSpaces = ParkingSpaces;
            this.SmokeAlarms = SmokeAlarms;
            this.HouseAlarm = HouseAlarm;
            this.LandlordID = LandlordID;
            this.CurrentValue = CurrentValue;
            this.ValuationDate = ValuationDate;
            this.ValuationNotes = ValuationNotes;
            this.PurchaseType = PurchaseType;
            this.PurchasePrice = PurchasePrice;
            this.PurchaseDate = PurchaseDate;
            this.PurchaseNotes = PurchaseNotes;
            this.SalePrice = SalePrice;
            this.SaleDate = SaleDate;
            this.SaleNotes = SaleNotes;
            this.LeaseStart = LeaseStart;
            this.LeaseEnd = LeaseEnd;
            this.LeaseNotes = LeaseNotes;
            this.TemplateType = TemplateType;
            this.LastUpdatedTime = LastUpdatedTime;
            this.LastUpdatedUser = LastUpdatedUser;
            this.ParentID = ParentID;

        }

        public string AccessInformation { get;  set; }
        [Required]
        public string AddressLine1 { get;  set; }
        public string AddressLine2 { get;  set; }
        public string AddressLine3 { get;  set; }
        public string AddressLine4 { get;  set; }
        public string AddressLine5 { get;  set; }
        public int BranchID { get;  set; }
        public string BuildingType { get;  set; }
        public double CurrentValue { get;  set; }
        public string Description { get;  set; }
        public int Garages { get;  set; }
        public bool HouseAlarm { get;  set; }
        public string LandlordID { get;  set; }
        public DateTime? LastUpdatedTime { get;  set; }
        public string LastUpdatedUser { get;  set; }
        public double Latitude { get;  set; }
        public DateTime? LeaseEnd { get;  set; }
        public string LeaseNotes { get;  set; }
        public DateTime? LeaseStart { get;  set; }
        public double Longtitude { get;  set; }
        public string MarketingDescription { get;  set; }

        [Required]
        public string NickName { get;  set; }
        public string Notes { get;  set; }
       

       
        public int ParkingSpaces { get;  set; }
        [Required]
        public string Postcode { get;  set; }
        public DateTime? PurchaseDate { get;  set; }
        public string PurchaseNotes { get;  set; }
        public double PurchasePrice { get;  set; }
        public string PurchaseType { get;  set; }
        public DateTime? SaleDate { get;  set; }
        public int ParentID { get; set; }
        public string SaleNotes { get;  set; }
        public double SalePrice { get;  set; }
        public string size { get;  set; }
        public int SmokeAlarms { get;  set; }
        [Required]
        public string Status { get;  set; }
        public string TemplateType { get;  set; }
        public DateTime? ValuationDate { get;  set; }
        public string ValuationNotes { get;  set; }
        public int YearBuilt { get;  set; }
    }
}

public static class BuildProperyDetail
{
    public static PropertyDetail ViewProperty(int PropertyID)
    {
        DataTable DT = DB.ReadData(Constants.StoredProcedures.Read.uspReadProperty, DB.StoredProcedures.uspReadProperty(PropertyID));

        if (DT.Rows.Count > 0)
        {
            return BuildProperyDetail.BuildPropertyDetailFromDataRow(DT.Rows[0]);
        }
        return null;
    }

    private static PropertyDetail BuildPropertyDetailFromDataRow(DataRow dr)
    {

        return new PropertyDetail(Functions.ToString(dr["Status"]), Functions.ToInt32(dr["BranchID"]), Functions.ToString(dr["BuildingType"]), Functions.ToString(dr["NickName"]), Functions.ToString(dr["Description"]), Functions.ToString(dr["MarketingDescription"]), Functions.ToString(dr["size"]),
            Functions.ToString(dr["AddressLine1"]), Functions.ToString(dr["AddressLine2"]), Functions.ToString(dr["AddressLine3"]), Functions.ToString(dr["AddressLine4"]), Functions.ToString(dr["AddressLine5"]), Functions.ToString(dr["Postcode"]), Functions.ToDouble(dr["Latitude"]),
            Functions.ToDouble(dr["Longtitude"]), Functions.ToString(dr["Notes"]), Functions.ToString(dr["AccessInformation"]), Functions.ToInt32(dr["YearBuilt"]), Functions.ToInt32(dr["Garages"]), Functions.ToInt32(dr["ParkingSpaces"]), Functions.ToInt32(dr["SmokeAlarms"]), Functions.ToBool(dr["HouseAlarm"]),
            Functions.ToString(dr["LandlordID"]), Functions.ToDouble(dr["CurrentValue"]), Functions.ToDate(dr["ValuationDate"]), Functions.ToString(dr["ValuationNotes"]), Functions.ToString(dr["PurchaseType"]), Functions.ToDouble(dr["PurchasePrice"]), Functions.ToDate(dr["PurchaseDate"]), Functions.ToString(dr["PurchaseNotes"]),
            Functions.ToDouble(dr["SalePrice"]), Functions.ToDate(dr["SaleDate"]), Functions.ToString(dr["SaleNotes"]), Functions.ToDate(dr["LeaseStart"]), Functions.ToDate(dr["LeaseEnd"]), Functions.ToString(dr["LeaseNotes"]), Functions.ToString(dr["TemplateType"]), Functions.ToDate(dr["LastUpdatedTime"]), Functions.ToString(dr["LastUpdatedUser"]), Functions.ToInt32(dr["ParentID"]));

    }

}