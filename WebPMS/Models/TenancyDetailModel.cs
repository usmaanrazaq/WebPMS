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
    [Serializable()]
    public class TenancyDetails : List<TenancyDetail>
    { }


    public class TenancyDetail
    {

        public TenancyDetail() { }
        public TenancyDetail(int ID, int PropertyID, string Status, string TenancyType, int TenantName, DateTime? StartDate, DateTime? EndDate, double Rent, string Frequency, int RentDueDay, double DepositReceived, string DepositNotes, DateTime? DateDepositProtected, double DepositReturned, string PaymentReference, string Notes, DateTime? LastUpdatedTime, string LastUpdatedUser)
        {
            this.ID = ID;
            this.PropertyID = PropertyID;
            this.Status = Status;
            this.TenancyType = TenancyType;
            this.TenantName = TenantName;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.Rent = Rent;
            this.Frequency = Frequency;
            this.RentDueDay = RentDueDay;
            this.DepositReceived = DepositReceived;
            this.DepositNotes = DepositNotes;
            this.DateDepositProtected = DateDepositProtected;
            this.DepositReturned = DepositReturned;
            this.PaymentReference = PaymentReference;
            this.Notes = Notes;
            this.LastUpdatedTime = LastUpdatedTime;
            this.LastUpdatedUser = LastUpdatedUser;

        }
        public int ID { get; set; }
        public int PropertyID { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string TenancyType { get; set; }
        public int TenantName { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }
        public double Rent { get; set; }
        public string Frequency { get; set; }
        public int RentDueDay { get; set; }
        public double DepositReceived { get; set; }
        public string DepositNotes { get; set; }
        public DateTime? DateDepositProtected { get; set; }
        public double DepositReturned { get; set; }
        public string PaymentReference { get; set; }
        public string Notes { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
        public string LastUpdatedUser { get; set; }

    }

    public static class BuildTenancyDetail
    {

        public static TenancyDetail ViewTenancyDetail(int ID)
        {
            DataTable DT = DB.ReadData(Constants.StoredProcedures.Read.uspReadTenancy, DB.StoredProcedures.uspReadTenancy(ID));
            if (DT.Rows.Count > 0)
            {
                return BuildTenancyDetailFromDataRow(DT.Rows[0]);
            }
            return null;
        }
        private static TenancyDetail BuildTenancyDetailFromDataRow(DataRow dr)
        {
            return new TenancyDetail(Functions.ToInt32(dr["ID"]), Functions.ToInt32(dr["PropertyID"]), Functions.ToString(dr["Status"]), Functions.ToString(dr["TenancyType"]), Functions.ToInt32(dr["TenantName"]), Functions.ToDate(dr["StartDate"]), Functions.ToDate(dr["EndDate"]), Functions.ToDouble(dr["Rent"]), Functions.ToString(dr["Frequency"]), Functions.ToInt32(dr["RentDueDay"]), Functions.ToDouble(dr["DepositReceived"]), Functions.ToString(dr["DepositNotes"]), Functions.ToDate(dr["DateDepositProtected"]), Functions.ToDouble(dr["DepositReturned"]), Functions.ToString(dr["PaymentReference"]), Functions.ToString(dr["Notes"]), Functions.ToDate(dr["LastUpdatedTime"]), Functions.ToString(dr["LastUpdatedUser"]));
        }
    }
}