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
    
    public class ThirdParties : List<ThirdParty>
    { }

    /// <summary>
    /// Third Party contains constructors for the following : ExsistingPeople, Org Contacts, and ThirdParties
    /// </summary>
    public class ThirdParty
    {


        /// <summary>
        /// Used to get Exsisting People (uspGetExsisingPeople)
        /// </summary>
        /// <param name="TypeOfPerson"></param>
        /// <param name="ID"></param>
        /// <param name="Title"></param>
        /// <param name="Forename"></param>
        /// <param name="Surname"></param>
        /// <param name="Suffix"></param>
        /// <param name="DateofBirth"></param>
        /// <param name="AddressLine1"></param>
        /// <param name="AddressLine2"></param>
        /// <param name="AddressLine3"></param>
        /// <param name="AddressLine4"></param>
        /// <param name="AddressLine5"></param>
        /// <param name="Postcode"></param>
        /// <param name="HomePhone"></param>
        /// <param name="WorkPhone"></param>
        /// <param name="Mobile"></param>
        /// <param name="MiddleName"></param>
        /// <param name="EmailAddress"></param>
        /// <param name="Fax"></param>
        /// <param name="ISOCurrencyCode"></param>
        /// <param name="ISOLanguageCode"></param>
        /// <param name="TemplateType"></param>
        public ThirdParty(string TypeOfPerson, string ID, string Title, string Forename, string Surname, string Suffix, DateTime? DateofBirth, string AddressLine1, string AddressLine2, string AddressLine3, string AddressLine4, string AddressLine5, string Postcode, string HomePhone, string WorkPhone, string Mobile, string MiddleName, string EmailAddress, string Fax, string ISOCurrencyCode, string ISOLanguageCode, string TemplateType)
        {
            this.TypeOfPerson = TypeOfPerson;
            this.ID = ID;
            this.Title = Title;
            this.Forename = Forename;
            this.Surname = Surname;
            this.Suffix = Suffix;
            this.DateOfBirth = DateofBirth;
            this.AddressLine1 = AddressLine1;
            this.AddressLine2 = AddressLine2;
            this.AddressLine3 = AddressLine3;
            this.AddressLine4 = AddressLine4;
            this.AddressLine5 = AddressLine5;
            this.PostCode = Postcode;
            this.HomePhone = HomePhone;
            this.WorkPhone = WorkPhone;
            this.Mobile = Mobile;
            this.MiddleName = MiddleName;
            this.EmailAddress = EmailAddress;
            this.Fax = Fax;
            this.ISOCurrencyCode = ISOCurrencyCode;
            this.ISOLanguageCode = ISOLanguageCode;
            this.TemplateType = TemplateType;
        }
        public ThirdParty() { }

        /// <summary>
        /// Used FOR Org Contacts
        /// </summary>
        /// <param name="TypeOfPerson"></param>
        /// <param name="ID"></param>
        /// <param name="Surname"></param>
        /// <param name="Forename"></param>
        /// <param name="MiddleName"></param>
        /// <param name="Title"></param>
        /// <param name="Suffix"></param>
        /// <param name="WorkPhone"></param>
        /// <param name="Fax"></param>
        /// <param name="EmailAddress"></param>
        /// <param name="Dept"></param>
        /// <param name="Name"></param>
        public ThirdParty(string TypeOfPerson, string ID, string Surname, string Forename, string MiddleName, string Title, string Suffix, string WorkPhone, string Fax, string EmailAddress, string Dept, string Name)
        {
            this.TypeOfPerson = TypeOfPerson;
            this.ID = ID;
            this.Surname = Surname;
            this.Forename = Forename;
            this.MiddleName = MiddleName;
            this.Title = Title;
            this.Suffix = Suffix;
            this.WorkPhone = WorkPhone;
            this.Fax = Fax;
            this.EmailAddress = EmailAddress;
            this.Dept = Dept;
            this.Name = Name;

        }

        public ThirdParty(string ID, string TypeOfPerson, string Surname, string Forename, string MiddleName, string Title, string Suffix, string Gender,
            DateTime? DateOfBirth, string AddressLine1, string AddressLine2, string AddressLine3, string AddressLine4, string AddressLine5, string PostCode,
            string HomePhone, string WorkPhone, string WorkExtensionNumber, string Mobile, string Fax, string EmailAddress, string PreferredContactMethod,
            string PreferredContactTime, string Notes, string Dept, string Status, DateTime? LastUpdatedTime, string LastUpdatedUser, string JobTitle,
            string ID2, string SubType, string NINumber, int BranchID, int PaymentTerms, string SalesPerson, string ISOCountryCode, string ISOCurrencyCode,
            string ISOLanguageCode, bool MultipleJobsPerInvoice, string TemplateType, string PaymentTermsRecurrenceInfo, double HolidayEntitlement, string MaritalStatus,
            DateTime? DateStarted, DateTime? DateFinished, string Department, string LineManager, string Password, string RegistrationNumber, bool Apprentice,
            bool AllowProductRequests, string EthnicOrigin, bool CriminalConviction, string CriminalConvictionDetails)
        {
            this.ID = ID;
            this.TypeOfPerson = TypeOfPerson;
            this.Surname = Surname;
            this.Forename = Forename;
            this.MiddleName = MiddleName;
            this.Title = Title;
            this.Suffix = Suffix;
            this.Gender = Gender;
            this.DateOfBirth = DateOfBirth;
            this.AddressLine1 = AddressLine1;
            this.AddressLine2 = AddressLine2;
            this.AddressLine3 = AddressLine3;
            this.AddressLine4 = AddressLine4;
            this.AddressLine5 = AddressLine5;
            this.PostCode = PostCode;
            this.HomePhone = HomePhone;
            this.WorkPhone = WorkPhone;
            this.WorkExtensionNumber = WorkExtensionNumber;
            this.Mobile = Mobile;
            this.Fax = Fax;
            this.EmailAddress = EmailAddress;
            this.PreferredContactMethod = PreferredContactMethod;
            this.PreferredContactTime = PreferredContactTime;
            this.Notes = Notes;
            this.Dept = Dept;
            this.Status = Status;
            this.LastUpdatedTime = LastUpdatedTime;
            this.LastUpdatedUser = LastUpdatedUser;
            this.JobTitle = JobTitle;
            this.ID2 = ID2;
            this.SubType = SubType;
            this.NINumber = NINumber;
            this.BranchID = BranchID;
            this.PaymentTerms = PaymentTerms;
            this.SalesPerson = SalesPerson;
            this.ISOCountryCode = ISOCountryCode;
            this.ISOCurrencyCode = ISOCurrencyCode;
            this.ISOLanguageCode = ISOLanguageCode;
            this.MultipleJobsPerInvoice = MultipleJobsPerInvoice;
            this.TemplateType = TemplateType;
            this.PaymentTermsRecurrenceInfo = PaymentTermsRecurrenceInfo;
            this.HolidayEntitlement = HolidayEntitlement;
            this.MaritalStatus = MaritalStatus;
            this.DateStarted = DateStarted;
            this.DateFinished = DateFinished;
            this.Department = Department;
            this.LineManager = LineManager;
            this.Password = Password;
            this.RegistrationNumber = RegistrationNumber;
            this.Apprentice = Apprentice;
            this.AllowProductRequests = AllowProductRequests;
            this.EthnicOrigin = EthnicOrigin;
            this.CriminalConviction = CriminalConviction;
            this.CriminalConvictionDetails = CriminalConvictionDetails;
        }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string AddressLine5 { get; set; }
        public bool AllowProductRequests { get; set; }
        public bool Apprentice { get; set; }
        public int BranchID { get; set; }
        public bool CriminalConviction { get; set; }
        public string CriminalConvictionDetails { get; set; }
        public DateTime? DateFinished { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateStarted { get; set; }
        public string Department { get; set; }
        public string Dept { get; set; }
        public string EmailAddress { get; set; }
        public string EthnicOrigin { get; set; }
        public string Fax { get; set; }
        public string Forename { get; set; }
        public string Gender { get; set; }
        public double HolidayEntitlement { get; set; }
        public string HomePhone { get; set; }
        public string ID { get; set; }
        public string ID2 { get; set; }
        public string ISOCountryCode { get; set; }
        public string ISOCurrencyCode { get; set; }
        public string ISOLanguageCode { get; set; }
        public string JobTitle { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
        public string LastUpdatedUser { get; set; }
        public string LineManager { get; set; }
        public string MaritalStatus { get; set; }
        public string MiddleName { get; set; }
        public string Mobile { get; private set; }
        public bool MultipleJobsPerInvoice { get; set; }

        public string NINumber { get; set; }
        public string Notes { get; set; }

        public string[] NotesSeperated
        {
            get
            {
                var items = this.Notes.Split(new[] { "\r\n\r\n" }, StringSplitOptions.None);
                return items;
            }
        }
        public string Password { get; set; }
        public int PaymentTerms { get; set; }
        public string PaymentTermsRecurrenceInfo { get; set; }
        public string PostCode { get; set; }
        public string PreferredContactMethod { get; set; }
        public string PreferredContactTime { get; set; }
        public string RegistrationNumber { get; set; }
        public string SalesPerson { get; set; }
        public string Status { get; set; }
        public string SubType { get; set; }
        public string Suffix { get; set; }
        public string Surname { get; set; }
        public string TemplateType { get; set; }
        public string Title { get; set; }
        public string TypeOfPerson { get; set; }
        public string WorkExtensionNumber { get; set; }
        public string WorkPhone { get; set; }


        //ORG CONTACTS 
        public string Name { get; set; }
    }
}

public static class BuildThirdParty
{
    public static ThirdParty ViewThirdParty(string ID)
    {
        DataTable DT = DB.ReadData(Constants.StoredProcedures.Read.uspReadThirdParty, DB.StoredProcedures.uspReadThirdParty(ID));

        if (DT.Rows.Count > 0)
        {
            return BuildThirdPartyByRow(DT.Rows[0]);
        }
        return null;
    }

    public static ThirdParties ViewOrgContacts(string ID)
    {
        DataTable DT = DB.ReadData(Constants.StoredProcedures.Read.uspGetOrgContacts, DB.StoredProcedures.uspGetOrgContacts(ID));
        ThirdParties prop = new ThirdParties();
        if (DT.Rows.Count > 0)
        {
            foreach (DataRow R in DT.Rows)
            {
                prop.Add(BuildOrgContactFromDataRow(R));
            }
        }
        return prop;
    }
    public static  ThirdParty ViewExsistingPeople(string ID)
    {
        DataTable DT = DB.ReadData(Constants.StoredProcedures.Read.uspGetExistingPeople, DB.StoredProcedures.uspGetExistingPeople(ID));
      
        if (DT.Rows.Count > 0)
        {          
                return BuildExsistingPeopleFromDataRow(DT.Rows[0]);
            
        }
        return new ThirdParty(); 
    }
    private static ThirdParty BuildExsistingPeopleFromDataRow(DataRow dr)
    {
        return new ThirdParty(Functions.ToString(dr["TypeOfPerson"]), Functions.ToString(dr["ID"]), Functions.ToString(dr["Title"]), Functions.ToString(dr["Forename"]), Functions.ToString(dr["Surname"]), Functions.ToString(dr["Suffix"]), Functions.ToDate(dr["DateofBirth"]), Functions.ToString(dr["AddressLine1"]), Functions.ToString(dr["AddressLine2"]), Functions.ToString(dr["AddressLine3"]), Functions.ToString(dr["AddressLine4"]), Functions.ToString(dr["AddressLine5"]), Functions.ToString(dr["Postcode"]), Functions.ToString(dr["HomePhone"]), Functions.ToString(dr["WorkPhone"]), Functions.ToString(dr["Mobile"]), Functions.ToString(dr["MiddleName"]), Functions.ToString(dr["EmailAddress"]), Functions.ToString(dr["Fax"]), Functions.ToString(dr["ISOCurrencyCode"]), Functions.ToString(dr["ISOLanguageCode"]), Functions.ToString(dr["TemplateType"]));
    }

private static ThirdParty BuildOrgContactFromDataRow(DataRow dr)
    {
        return new ThirdParty(Functions.ToString(dr["TypeOfPerson"]), Functions.ToString(dr["ID"]), Functions.ToString(dr["Surname"]), Functions.ToString(dr["Forename"]), Functions.ToString(dr["MiddleName"]), Functions.ToString(dr["Title"]), Functions.ToString(dr["Suffix"]), Functions.ToString(dr["WorkPhone"]), Functions.ToString(dr["Fax"]), Functions.ToString(dr["EmailAddress"]), Functions.ToString(dr["Dept"]), Functions.ToString(dr["Name"]));
    }

    private static ThirdParty BuildThirdPartyByRow(DataRow dr)
    {
        return new ThirdParty(Functions.ToString(dr["ID"]), Functions.ToString(dr["TypeOfPerson"]), Functions.ToString(dr["Surname"]), Functions.ToString(dr["Forename"]), Functions.ToString(dr["MiddleName"]), Functions.ToString(dr["Title"]),
             Functions.ToString(dr["Suffix"]), Functions.ToString(dr["Gender"]), Functions.ToDate(dr["DateofBirth"]), Functions.ToString(dr["AddressLine1"]), Functions.ToString(dr["AddressLine2"]), Functions.ToString(dr["AddressLine3"]),
             Functions.ToString(dr["AddressLine4"]), Functions.ToString(dr["AddressLine5"]), Functions.ToString(dr["PostCode"]), Functions.ToString(dr["HomePhone"]), Functions.ToString(dr["WorkPhone"]), Functions.ToString(dr["WorkExtensionNumber"]),
             Functions.ToString(dr["Mobile"]), Functions.ToString(dr["Fax"]), Functions.ToString(dr["EmailAddress"]), Functions.ToString(dr["PreferredContactMethod"]), Functions.ToString(dr["PreferredContactTime"]), Functions.ToString(dr["Notes"]),
             Functions.ToString(dr["Dept"]), Functions.ToString(dr["Status"]), Functions.ToDate(dr["LastUpdatedTime"]), Functions.ToString(dr["LastUpdatedUser"]), Functions.ToString(dr["JobTitle"]), Functions.ToString(dr["ID2"]), Functions.ToString(dr["SubType"]),
             Functions.ToString(dr["NINumber"]), Functions.ToInt32(dr["BranchID"]), Functions.ToInt32(dr["PaymentTerms"]), Functions.ToString(dr["SalesPerson"]), Functions.ToString(dr["ISOCountryCode"]), Functions.ToString(dr["ISOCurrencyCode"]), Functions.ToString(dr["ISOLanguageCode"]),
             Functions.ToBool(dr["MultipleJobsPerInvoice"]), Functions.ToString(dr["TemplateType"]), Functions.ToString(dr["PaymentTermsRecurrenceInfo"]), Functions.ToDouble(dr["HolidayEntitlement"]), Functions.ToString(dr["MaritalStatus"]), Functions.ToDate(dr["DateStarted"])
             , Functions.ToDate(dr["DateFinished"]), Functions.ToString(dr["Department"]), Functions.ToString(dr["LineManager"]), Functions.ToString(dr["Password"]), Functions.ToString(dr["RegistrationNumber"]), Functions.ToBool(dr["Apprentice"]), Functions.ToBool(dr["AllowProductRequests"]), Functions.ToString(dr["EthnicOrigin"]), Functions.ToBool(dr["CriminalConviction"]), Functions.ToString(dr["CriminalConvictionDetails"]));
    }
}