using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace WebPMS.Models
{
    public class Users : List<User>
    {

    }
    public class User
    {

        public User(string ID, string Surname, string Forename, string MiddleName, string Title, bool ViewAdjustments, bool AddAdjustments, string JobTitle, float ChargingRate, string Password, string AccessLevel, string Revoked,
                        string EmailAddress, string WorkPhone, string WorkExtensionNumber, string Mobile, string Fax, System.DateTime LastUpdatedTime, string LastUpdatedUser, int OwnBranchID, string LinkedStaffID, int cNoOfCopies,
                        bool cViewInWord)
        {
            this.ID = ID;
            this.Surname = Surname;
            this.Forename = Forename;
            this.MiddleName = MiddleName;
            this.Title = Title;
            this.ViewAdjustments = ViewAdjustments;
            this.JobTitle = JobTitle;
            this.ChargingRate = ChargingRate;
            this.Password = Password;
            this.AccessLevel = AccessLevel;
            this.Revoked = Revoked;
            this.EmailAddress = EmailAddress;
            this.WorkPhone = WorkPhone;
            this.WorkExtensionNumber = WorkExtensionNumber;
            this.Mobile = Mobile;
            this.Fax = Fax;
            this.LastUpdatedTime = LastUpdatedTime;
            this.LastUpdatedUser = LastUpdatedUser;
            this.OwnBranchID = OwnBranchID;
            this.LinkedStaffID = LinkedStaffID;
            this.cNoOfCopies = cNoOfCopies;
            this.cViewInWord = cViewInWord;
        }
        public User() { }
        [Required]
        public string ID { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        public string MiddleName { get; set; }
        public string Title { get; set; }
        public bool ViewAdjustments { get; set; }
        public bool AddAdjustments { get; set; } 
        public string JobTitle { get; set; }
        public float? ChargingRate { get; set; }
        [Required]
        public string Password { get; set; }
        public string AccessLevel { get; set; }
        public string Revoked { get; set; }
        public string EmailAddress { get; set; }
        public string WorkPhone { get; set; }
        public string WorkExtensionNumber { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public System.DateTime? LastUpdatedTime { get; set; }
        public string LastUpdatedUser { get; set; }
        public int OwnBranchID { get; set; }
        public string LinkedStaffID { get; set; }
        public int cNoOfCopies { get; set; }
        public bool cViewInWord { get; set; }
    }
    public static class BuildUser
    {
        public static User ViewUser(string ID)
        {
            DataTable DT = DB.ReadData(Constants.StoredProcedures.Read.uspReadUsers, DB.StoredProcedures.uspReadUsers(ID));

            if (DT.Rows.Count > 0)
            {
                return BuildUser.BuildUserFromDataRow(DT.Rows[0]);
            }
            return null;
        }


        public static Users ViewUsers(string UserID)
        {
            DataTable DT = DB.ReadData(Constants.StoredProcedures.Read.uspRetrieveUsers, DB.StoredProcedures.uspRetrieveUsers(UserID));
            Users prop = new Users();
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow d in DT.Rows)
                {
                    prop.Add(BuildUserFromDataRow(d));
                }
               
            }
            return prop;
        }


        public static User BuildUserFromDataRow(DataRow dr)
        {

            return new User((string)dr["ID"], Functions.ToString(dr["Surname"]), Functions.ToString(dr["Forename"]), Functions.ToString(dr["MiddleName"]), Functions.ToString(dr["Title"]), Functions.ToBool(dr["FeeEarner"]), Functions.ToBool(dr["Supervisor"]), Functions.ToString(dr["JobTitle"]),
              Functions.ToFloat(dr["ChargingRate"]), Functions.ToString(dr["Password"]), Functions.ToString(dr["AccessLevel"]), Functions.ToString(dr["Revoked"]), Functions.ToString(dr["EmailAddress"]), Functions.ToString(dr["WorkPhone"]), Functions.ToString(dr["WorkExtensionNumber"]), Functions.ToString(dr["Mobile"]), Functions.ToString(dr["Fax"]),
                Convert.ToDateTime(dr["LastUpdatedTime"]), Functions.ToString(dr["LastUpdatedUser"]), Convert.ToInt32(dr["OwnBranchID"]), Functions.ToString(dr["LinkedStaffID"]), 0, false);

        }

    }
}