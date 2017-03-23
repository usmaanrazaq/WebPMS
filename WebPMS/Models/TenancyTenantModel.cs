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
    public class TenancyTenants : List<TenancyTenant>
    { }


    public class TenancyTenant
    {
        public TenancyTenant(string TenantID, string Status, string TypeOfPerson, string Title, string Surname, string Forename )
        {
            this.TenantID = TenantID;
            this.Status = Status;
            this.TypeOfPerson = TypeOfPerson;
            this.Title = Title;
            this.Surname = Surname;
            this.Forename = Forename;

        }
        public string TenantID { get; set; }
        public string Status { get; set; }
        public string TypeOfPerson { get; set; }
        public string Title { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }

    }

    public static class BuildTenancyTenant
    {
        public static TenancyTenants ViewTenancyTenants(int TenancyID)
        {
            DataTable DT = DB.ReadData(Constants.StoredProcedures.Read.uspGetTenancyTenants, DB.StoredProcedures.uspGetTenancyTenants(TenancyID));
            TenancyTenants prop = new TenancyTenants();
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow R in DT.Rows)
                {
                    prop.Add(BuildTenancyTenantFromDataRow(R));
                }
            }
            return prop;
        }


        private static TenancyTenant BuildTenancyTenantFromDataRow(DataRow dr)
        {
            return new TenancyTenant(Functions.ToString(dr["TenantID"]), Functions.ToString(dr["Status"]), Functions.ToString(dr["TypeOfPerson"]), Functions.ToString(dr["Title"]), Functions.ToString(dr["Surname"]), Functions.ToString(dr["Forename"]));
        }
    }
}