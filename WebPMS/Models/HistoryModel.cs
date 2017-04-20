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
    public class HistoryList : List<History>
    { }


    public class History
    {
        public History(int ID, string OrgID, int JobID, string UserID, DateTime? TimeStamp, string Narrative, string TypeOfEntry, string FileName, string ThirdPartyID, int CustomerServiceID, int PropertyID)
        {
            this.ID = ID;
            this.OrgID = OrgID;
            this.JobID = JobID;
            this.UserID = UserID;
            this.TimeStamp = TimeStamp;
            this.Narrative = Narrative;
            this.TypeOfEntry = TypeOfEntry;
            this.FileName = FileName;
            this.ThirdPartyID = ThirdPartyID;
            this.CustomerServiceID = CustomerServiceID;
            this.PropertyID = PropertyID;

        }
        public int ID { get; set; }
        public string OrgID { get; set; }
        public int JobID { get; set; }
        public string UserID { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string Narrative { get; set; }
        public string TypeOfEntry { get; set; }
        public string FileName { get; set; }
        public string ThirdPartyID { get; set; }
        public int CustomerServiceID { get; set; }
        public int PropertyID { get; set; }

    }

    public static class BuildHistory
    {
        public static HistoryList ViewHistoryList(string HistoryType, string ID)
        {
            DataTable DT = DB.ReadData(Constants.StoredProcedures.Read.uspRetrieveHistory, DB.StoredProcedures.uspRetrieveHistory(HistoryType, ID));
            HistoryList prop = new HistoryList();
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow R in DT.Rows)
                {
                    prop.Add(BuildHistoryFromDataRow(R));
                }
            }
            return prop;
        }


        private static History BuildHistoryFromDataRow(DataRow dr)
        {
            return new History(Functions.ToInt32(dr["ID"]), Functions.ToString(dr["OrgID"]), Functions.ToInt32(dr["Column1"]), Functions.ToString(dr["Column2"]), Functions.ToDate(dr["TimeStamp"]), Functions.ToString(dr["Narrative"]), Functions.ToString(dr["TypeOfEntry"]), Functions.ToString(dr["FileName"]), Functions.ToString(dr["ThirdPartyID"]), Functions.ToInt32(dr["CustomerServiceID"]), Functions.ToInt32(dr["PropertyID"]));
        }
    }
}