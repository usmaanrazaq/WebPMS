using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebPMS;
using WebPMS.Models;


namespace WebPMS.Models
{
    [Serializable()]
    public class TenancyRequirements : List<TenancyRequirement>
    { }


    public class TenancyRequirement
    {
        public TenancyRequirement() { }
        public TenancyRequirement(int PropertyID, string FurnishedStatus, double Rent, string Frequency, double Deposit, string DepositNotes, bool PetsAllowed, string PetsAllowedNotes, bool BenefitsAllowed, bool SmokingAllowed, DateTime? AvailableFrom, string Notes, DateTime? LastUpdatedTime, string LastUpdatedUser)
        {
            this.PropertyID = PropertyID;
            this.FurnishedStatus = FurnishedStatus;
            this.Rent = Rent;
            this.Frequency = Frequency;
            this.Deposit = Deposit;
            this.DepositNotes = DepositNotes;
            this.PetsAllowed = PetsAllowed;
            this.PetsAllowedNotes = PetsAllowedNotes;
            this.BenefitsAllowed = BenefitsAllowed;
            this.SmokingAllowed = SmokingAllowed;
            this.AvailableFrom = AvailableFrom;
            this.Notes = Notes;
            this.LastUpdatedTime = LastUpdatedTime;
            this.LastUpdatedUser = LastUpdatedUser;

        }
        public int PropertyID { get; set; }
        public string FurnishedStatus { get; set; }
        public double Rent { get; set; }
        public string Frequency { get; set; }
        public double Deposit { get; set; }
        public string DepositNotes { get; set; }
        public bool PetsAllowed { get; set; }
        public string PetsAllowedNotes { get; set; }
        public bool BenefitsAllowed { get; set; }
        public bool SmokingAllowed { get; set; }
        public DateTime? AvailableFrom { get; set; }
        public string Notes { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
        public string LastUpdatedUser { get; set; }

    }

    public static class BuildTenancyRequirement
    {

        public static TenancyRequirement ViewTenancyRequirement(int PropertyID)
        {
            DataTable DT = DB.ReadData(Constants.StoredProcedures.Read.uspReadTenancyRequirements, DB.StoredProcedures.uspReadTenancyRequirements(PropertyID));
          
            if (DT.Rows.Count > 0)
            {
               
                   return (BuildTenancyRequirementFromDataRow(DT.Rows[0]));
                
            }
            return new TenancyRequirement(); 
        }


        private static TenancyRequirement BuildTenancyRequirementFromDataRow(DataRow dr)
        {
            return new TenancyRequirement(Functions.ToInt32(dr["PropertyID"]), Functions.ToString(dr["FunishedStatus"]), Functions.ToDouble(dr["Rent"]), Functions.ToString(dr["Frequency"]), Functions.ToDouble(dr["Deposit"]), Functions.ToString(dr["DepositNotes"]), Functions.ToBool(dr["PetsAllowed"]), Functions.ToString(dr["PetsAllowedNotes"]), Functions.ToBool(dr["BenefitsAllowed"]), Functions.ToBool(dr["SmokingAllowed"]), Functions.ToDate(dr["AvailableFrom"]), Functions.ToString(dr["Notes"]), Functions.ToDate(dr["LastUpdatedTime"]), Functions.ToString(dr["LastUpdatedUser"]));
        }
    }
}