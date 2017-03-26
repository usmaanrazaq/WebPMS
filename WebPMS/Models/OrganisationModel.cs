using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using WebPMS;
using WebPMS.Models;


namespace WebPMS
{
    [Serializable()]
    public class Organisations : List<Organisation>
    { }


    /// <summary>
    /// Organisationy contains constructors for the following : Org Details,  Exsisting Orgs, and Organisation
    /// </summary>
    public class Organisation
    {

        public Organisation() {}
        /// <summary>
        /// Organisation Details Stored procedure  uspGetOrgDetails
        /// </summary>
        /// <param name="TypeOfOrganisation"></param>
        /// <param name="ID"></param>
        /// <param name="Name"></param>
        /// <param name="AddressLine1"></param>
        /// <param name="AddressLine2"></param>
        /// <param name="AddressLine3"></param>
        /// <param name="AddressLine4"></param>
        /// <param name="AddressLine5"></param>
        /// <param name="Postcode"></param>
        /// <param name="Phone"></param>
        /// <param name="Source"></param>
        /// <param name="VATRegistered"></param>
        /// <param name="VATNo"></param>
        /// <param name="ISOCurrencyCode"></param>
        /// <param name="ISOLanguageCode"></param>
        /// <param name="OurAccountNo"></param>
        /// <param name="TemplateType"></param>
        /// <param name="PaymentTerms"></param>
        /// <param name="PaymentTermsRecurrenceInfo"></param>
        /// <param name="Status"></param>
        public Organisation(string TypeOfOrganisation, string ID, string Name, string AddressLine1, string AddressLine2, string AddressLine3, string AddressLine4, string AddressLine5, string Postcode, string Phone, string Source, bool VATRegistered, string VATNo, string ISOCurrencyCode, string ISOLanguageCode, string OurAccountNo, string TemplateType, int PaymentTerms, string PaymentTermsRecurrenceInfo, string Status)
        {
            this.TypeOfOrganisation = TypeOfOrganisation;
            this.ID = ID;
            this.Name = Name;
            this.AddressLine1 = AddressLine1;
            this.AddressLine2 = AddressLine2;
            this.AddressLine3 = AddressLine3;
            this.AddressLine4 = AddressLine4;
            this.AddressLine5 = AddressLine5;
            this.PostCode = Postcode;
            this.Phone = Phone;
            this.Source = Source;
            this.VATRegistered = VATRegistered;
            this.VATNo = VATNo;
            this.ISOCurrencyCode = ISOCurrencyCode;
            this.ISOLanguageCode = ISOLanguageCode;
            this.OurAccountNo = OurAccountNo;
            this.TemplateType = TemplateType;
            this.PaymentTerms = PaymentTerms;
            this.PaymentTermsRecurrenceInfo = PaymentTermsRecurrenceInfo;
            this.Status = Status;

        }
        /// <summary>
        /// Exsisting Orgs Stored procedure
        /// </summary>
        /// <param name="TypeOfOrganisation"></param>
        /// <param name="ID"></param>
        /// <param name="Name"></param>
        /// <param name="AddressLine1"></param>
        /// <param name="AddressLine2"></param>
        /// <param name="AddressLine3"></param>
        /// <param name="AddressLine4"></param>
        /// <param name="AddressLine5"></param>
        /// <param name="Postcode"></param>
        /// <param name="Phone"></param>
        /// <param name="Source"></param>
        /// <param name="VATRegistered"></param>
        /// <param name="VATNo"></param>
        /// <param name="ISOCurrencyCode"></param>
        /// <param name="ISOLanguageCode"></param>
        /// <param name="OurAccountNo"></param>
        /// <param name="Status"></param>
        /// <param name="AlternativeID"></param>
        /// <param name="EmailAddress"></param>
        /// <param name="Status1"></param>
        /// <param name="AlternativeID2"></param>
        /// <param name="SubType"></param>
        /// <param name="GroupCode"></param>
        /// <param name="Group"></param>
        public Organisation(string TypeOfOrganisation, string ID, string Name, string AddressLine1, string AddressLine2, string AddressLine3, string AddressLine4, string AddressLine5, string Postcode, string Phone, string Source, bool VATRegistered, string VATNo, string ISOCurrencyCode, string ISOLanguageCode, string OurAccountNo, string Status, string AlternativeID, string EmailAddress, string Status1, string AlternativeID2, string SubType, string GroupCode, string Group)
            {
                this.TypeOfOrganisation = TypeOfOrganisation;
                this.ID = ID;
                this.Name = Name;
                this.AddressLine1 = AddressLine1;
                this.AddressLine2 = AddressLine2;
                this.AddressLine3 = AddressLine3;
                this.AddressLine4 = AddressLine4;
                this.AddressLine5 = AddressLine5;
                this.PostCode = Postcode;
                this.Phone = Phone;
                this.Source = Source;
                this.VATRegistered = VATRegistered;
                this.VATNo = VATNo;
                this.ISOCurrencyCode = ISOCurrencyCode;
                this.ISOLanguageCode = ISOLanguageCode;
                this.OurAccountNo = OurAccountNo;
                this.Status = Status;
                this.AlternativeID = AlternativeID;
                this.EmailAddress = EmailAddress;
                this.Status1 = Status1;
                this.AlternativeID2 = AlternativeID2;
                this.SubType = SubType;
                this.GroupCode = GroupCode;
                this.Group = Group;
            }
            public Organisation(string ID, string TypeOfOrganisation, string Name, string AddressLine1, string AddressLine2, string AddressLine3, string AddressLine4, string AddressLine5, string PostCode, string Phone, string Fax, string HomePage, bool VATRegistered, string VATNo, string Notes, string Status, string Sector, string SubSector, DateTime? LastUpdatedTime, string LastUpdatedUser, string Source, string AlternativeRef, string OurAccountNo, string BillingContactID, int PaymentTerms, string SalesPerson, string ISOCountryCode, string ISOCurrencyCode, string ISOLanguageCode, bool MultipleJobsPerInvoice, string TemplateType, string PaymentTermsRecurrenceInfo, string EmailAddress)
        {
            this.ID = ID;
            this.TypeOfOrganisation = TypeOfOrganisation;
            this.Name = Name;
            this.AddressLine1 = AddressLine1;
            this.AddressLine2 = AddressLine2;
            this.AddressLine3 = AddressLine3;
            this.AddressLine4 = AddressLine4;
            this.AddressLine5 = AddressLine5;
            this.PostCode = PostCode;
            this.Phone = Phone;
            this.Fax = Fax;
            this.HomePage = HomePage;
            this.VATRegistered = VATRegistered;
            this.VATNo = VATNo;
            this.Notes = Notes;
            this.Status = Status;
            this.Sector = Sector;
            this.SubSector = SubSector;
            this.LastUpdatedTime = LastUpdatedTime;
            this.LastUpdatedUser = LastUpdatedUser;
            this.Source = Source;
            this.AlternativeRef = AlternativeRef;
            this.OurAccountNo = OurAccountNo;
            this.BillingContactID = BillingContactID;
            this.PaymentTerms = PaymentTerms;
            this.SalesPerson = SalesPerson;
            this.ISOCountryCode = ISOCountryCode;
            this.ISOCurrencyCode = ISOCurrencyCode;
            this.ISOLanguageCode = ISOLanguageCode;
            this.MultipleJobsPerInvoice = MultipleJobsPerInvoice;
            this.TemplateType = TemplateType;
            this.PaymentTermsRecurrenceInfo = PaymentTermsRecurrenceInfo;
            this.EmailAddress = EmailAddress;

        }
        public string ID { get; set; }

        public string TypeOfOrganisation { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string AddressLine5 { get; set; }
        [Required]
        public string PostCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string HomePage { get; set; }
        public bool VATRegistered { get; set; }
        public string VATNo { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public string Sector { get; set; }
        public string SubSector { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
        public string LastUpdatedUser { get; set; }
        public string Source { get; set; }
        public string AlternativeRef { get; set; }
        public string OurAccountNo { get; set; }
        public string BillingContactID { get; set; }
        public int PaymentTerms { get; set; }
        public string SalesPerson { get; set; }
        public string ISOCountryCode { get; set; }
        public string ISOCurrencyCode { get; set; }
        public string ISOLanguageCode { get; set; }
        public bool MultipleJobsPerInvoice { get; set; }
        public string TemplateType { get; set; }
        public string PaymentTermsRecurrenceInfo { get; set; }
        public string EmailAddress { get; set; }

        //ExisitingOrgs
        public string AlternativeID { get; set; }

        public string Status1 { get; set; }
        public string AlternativeID2 { get; set; }
        public string SubType { get; set; }
        public string GroupCode { get; set; }
        public string Group { get; set; }
    }

    public static class BuildOrganisations
    {
        public static Organisations ViewOrganisations(string ID, int ParentID)
        {
            DataTable DT = DB.ReadData(Constants.StoredProcedures.Read.uspRetrieveOrg, DB.StoredProcedures.uspRetrieveOrg(ID, ParentID));
            Organisations prop = new Organisations();
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow R in DT.Rows)
                {
                    prop.Add(BuildOrganisationFromDataRow(R));
                }
            }
            return prop;
        }
        public static Organisation ViewOrganisation(string ID, int ParentID)
        {
            DataTable DT = DB.ReadData(Constants.StoredProcedures.Read.uspRetrieveOrg, DB.StoredProcedures.uspRetrieveOrg(ID, ParentID));
         
            if (DT.Rows.Count > 0)
            {               
                    return BuildOrganisationFromDataRow(DT.Rows[0]);                
            }
            return  null;
        }
        public static Organisations ViewExsistingOrgs(string Name, string TypeOfOrg, bool ExactMatch, string Status)
        {
            DataTable DT = DB.ReadData(Constants.StoredProcedures.Read.uspGetExistingOrgs, DB.StoredProcedures.uspGetExistingOrgs(Name, TypeOfOrg, ExactMatch, Status));
            Organisations prop = new Organisations();
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow R in DT.Rows)
                {
                    prop.Add(BuildExsistingOrgFromDataRow(R));
                }
            }
            return prop;
        }

        public static Organisation ViewOrgDetail(string ID, bool ReturnContactDetails)
        {
            DataTable DT = DB.ReadData(Constants.StoredProcedures.Read.uspGetOrgDetails, DB.StoredProcedures.uspGetOrgDetails(ID, ReturnContactDetails));                      
                foreach (DataRow R in DT.Rows)
                {
                  return BuildOrgDetailsFromDataRow(DT.Rows[0]);
                }
            
            return new Organisation();
        }

        private static Organisation BuildOrgDetailsFromDataRow(DataRow dr)
        {
            return new Organisation(Functions.ToString(dr["TypeOfOrganisation"]), Functions.ToString(dr["ID"]), Functions.ToString(dr["Name"]), Functions.ToString(dr["AddressLine1"]), Functions.ToString(dr["AddressLine2"]), Functions.ToString(dr["AddressLine3"]), Functions.ToString(dr["AddressLine4"]), Functions.ToString(dr["AddressLine5"]), Functions.ToString(dr["Postcode"]), Functions.ToString(dr["Phone"]), Functions.ToString(dr["Source"]), Functions.ToBool(dr["VATRegistered"]), Functions.ToString(dr["VATNo"]), Functions.ToString(dr["ISOCurrencyCode"]), Functions.ToString(dr["ISOLanguageCode"]), Functions.ToString(dr["OurAccountNo"]), Functions.ToString(dr["TemplateType"]), Functions.ToInt32(dr["PaymentTerms"]), Functions.ToString(dr["PaymentTermsRecurrenceInfo"]), Functions.ToString(dr["Status"]));
        }
    

    private static Organisation BuildExsistingOrgFromDataRow(DataRow dr)
        {
            return new Organisation(Functions.ToString(dr["TypeOfOrganisation"]), Functions.ToString(dr["ID"]), Functions.ToString(dr["Name"]), Functions.ToString(dr["AddressLine1"]), Functions.ToString(dr["AddressLine2"]), Functions.ToString(dr["AddressLine3"]), Functions.ToString(dr["AddressLine4"]), Functions.ToString(dr["AddressLine5"]), Functions.ToString(dr["Postcode"]), Functions.ToString(dr["Phone"]), Functions.ToString(dr["Source"]), Functions.ToBool(dr["VATRegistered"]), Functions.ToString(dr["VATNo"]), Functions.ToString(dr["ISOCurrencyCode"]), Functions.ToString(dr["ISOLanguageCode"]), Functions.ToString(dr["OurAccountNo"]), Functions.ToString(dr["Status"]), Functions.ToString(dr["AlternativeID"]), Functions.ToString(dr["EmailAddress"]), Functions.ToString(dr["Status1"]), Functions.ToString(dr["AlternativeID2"]), Functions.ToString(dr["SubType"]), Functions.ToString(dr["GroupCode"]), Functions.ToString(dr["Group"]));
        }

        private static Organisation BuildOrganisationFromDataRow(DataRow dr)
        {
            return new Organisation(Functions.ToString(dr["ID"]), Functions.ToString(dr["TypeOfOrganisation"]), Functions.ToString(dr["Name"]), Functions.ToString(dr["AddressLine1"]), Functions.ToString(dr["AddressLine2"]), Functions.ToString(dr["AddressLine3"]), Functions.ToString(dr["AddressLine4"]), Functions.ToString(dr["AddressLine5"]), Functions.ToString(dr["PostCode"]), Functions.ToString(dr["Phone"]), Functions.ToString(dr["Fax"]), Functions.ToString(dr["HomePage"]), Functions.ToBool(dr["VATRegistered"]), Functions.ToString(dr["VATNo"]), Functions.ToString(dr["Notes"]), Functions.ToString(dr["Status"]), Functions.ToString(dr["Sector"]), Functions.ToString(dr["SubSector"]), Functions.ToDate(dr["LastUpdatedTime"]), Functions.ToString(dr["LastUpdatedUser"]), Functions.ToString(dr["Source"]), Functions.ToString(dr["AlternativeRef"]), Functions.ToString(dr["OurAccountNo"]), Functions.ToString(dr["BillingContactID"]), Functions.ToInt32(dr["PaymentTerms"]), Functions.ToString(dr["SalesPerson"]), Functions.ToString(dr["ISOCountryCode"]), Functions.ToString(dr["ISOCurrencyCode"]), Functions.ToString(dr["ISOLanguageCode"]), Functions.ToBool(dr["MultipleJobsPerInvoice"]), Functions.ToString(dr["TemplateType"]), Functions.ToString(dr["PaymentTermsRecurrenceInfo"]), Functions.ToString(dr["EmailAddress"]));
        }
    }
}
  
