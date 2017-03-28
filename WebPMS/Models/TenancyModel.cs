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
    public class Tenancies : List<Tenancy>
    { }


    public class Tenancy
    {
        public Tenancy(int TenancyID, string TenantID, string TenancyStatus, string TenancyType, DateTime? StartDate, DateTime? EndDate, double Rent, string Frequency, int RentDueDay, int PropertyID, string NickName, string AddressLine1, string AddressLine2, string AddressLine3, string AddressLine4, string AddressLine5, string postcode, int BranchID, string PropertyStatus, string TenantNames)
        {
            this.TenancyID = TenancyID;
            this.TenantID = TenantID;
            this.TenancyStatus = TenancyStatus;
            this.TenancyType = TenancyType;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.Rent = Rent;
            this.Frequency = Frequency;
            this.RentDueDay = RentDueDay;
            this.PropertyID = PropertyID;
            this.NickName = NickName;
            this.AddressLine1 = AddressLine1;
            this.AddressLine2 = AddressLine2;
            this.AddressLine3 = AddressLine3;
            this.AddressLine4 = AddressLine4;
            this.AddressLine5 = AddressLine5;
            this.postcode = postcode;
            this.BranchID = BranchID;
            this.PropertyStatus = PropertyStatus;
            this.TenantNames = TenantNames;

        }
        public int TenancyID { get; set; }
        public string TenantID { get; set; }
        public string TenancyStatus { get; set; }
        public string TenancyType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double Rent { get; set; }
        public string Frequency { get; set; }
        public int RentDueDay { get; set; }
        public int PropertyID { get; set; }
        public string NickName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string AddressLine5 { get; set; }

        [RegularExpression(@"^(?i)([A-PR-UWYZ](([0-9](([0-9]|[A-HJKSTUW])?)?)|([A-HK-Y][0-9]([0-9]|[ABEHMNPRVWXY])?)) [0-9][ABD-HJLNP-UW-Z]{2})|GIR 0AA$", ErrorMessage = "This is not right")]
        public string postcode { get; set; }
        public int BranchID { get; set; }
        public string PropertyStatus { get; set; }
        public string TenantNames { get; set; }

    }

    public static class BuildTenancy
    {
        public static Tenancies ViewTenants(int BranchID, bool ActiveOnly, bool Tenancies)
        {
            DataTable DT = DB.ReadData(Constants.StoredProcedures.Read.uspGetTenancyList, DB.StoredProcedures.uspGetTenancyList(BranchID, ActiveOnly, Tenancies));
            Tenancies prop = new Tenancies();
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow R in DT.Rows)
                {
                    prop.Add(BuildTenancyFromDataRow(R));
                }
            }
            return prop;
        }


        private static Tenancy BuildTenancyFromDataRow(DataRow dr)
        {
            return new Tenancy(Functions.ToInt32(dr["TenancyID"]), Functions.ToString(dr["TenantID"]), Functions.ToString(dr["TenancyStatus"]), Functions.ToString(dr["TenancyType"]), Functions.ToDate(dr["StartDate"]), Functions.ToDate(dr["EndDate"]), Functions.ToDouble(dr["Rent"]), Functions.ToString(dr["Frequency"]),
                Functions.ToInt32(dr["RentDueDay"]), Functions.ToInt32(dr["PropertyID"]), Functions.ToString(dr["NickName"]), Functions.ToString(dr["AddressLine1"]), Functions.ToString(dr["AddressLine2"]), Functions.ToString(dr["AddressLine3"]), Functions.ToString(dr["AddressLine4"]), Functions.ToString(dr["AddressLine5"]),
                Functions.ToString(dr["postcode"]), Functions.ToInt32(dr["BranchID"]), Functions.ToString(dr["PropertyStatus"]), Functions.ToString(dr["TenantNames"]));
        }
    }
}