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
    public class PropertyTenancies : List<PropertyTenancy>
    { }


    public class PropertyTenancy
    {

        public PropertyTenancy() { }
        public PropertyTenancy(int ID, string Status, string TenancyType, string tenant_list, DateTime? StartDate, DateTime? EndDate )
        {
            this.ID = ID;
            this.Status = Status;
            this.TenancyType = TenancyType;
            this.tenant_list = tenant_list;
            this.StartDate = StartDate;
            this.EndDate = EndDate;

        }
        public int ID { get; set; }
        public string Status { get; set; }
        public string TenancyType { get; set; }
        public string tenant_list { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string _comboDisplay { get
            {
                string enddate;
                if (EndDate == null) // if end date is empty
                    enddate = "No End date for Tenancy";
                else
                    enddate = EndDate.Value.ToString("dd/MM/yyyy");
                return Status + " " + TenancyType + " " + tenant_list + " " + StartDate.Value.ToString("dd/MM/yyyy") + " " + enddate;
            }
        }

    }

    public static class BuildPropertyTenancy
    {
        public static PropertyTenancies ViewPropertyTenancies(int PropertyID)
        {
            DataTable DT = DB.ReadData(Constants.StoredProcedures.Read.uspGetPropertyTenancies, DB.StoredProcedures.uspGetPropertyTenancies(PropertyID));
            PropertyTenancies prop = new PropertyTenancies();
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow R in DT.Rows)
                {
                    prop.Add(BuildPropertyTenancyFromDataRow(R));
                }
            }
            return prop;
        }


        private static PropertyTenancy BuildPropertyTenancyFromDataRow(DataRow dr)
        {
            return new PropertyTenancy(Functions.ToInt32(dr["ID"]), Functions.ToString(dr["Status"]), Functions.ToString(dr["TenancyType"]), Functions.ToString(dr["tenant_list"]), Functions.ToDate(dr["StartDate"]), Functions.ToDate(dr["EndDate"]));
        }
    }
}