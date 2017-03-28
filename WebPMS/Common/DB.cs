using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebPMS.Models;

namespace WebPMS
{
    public static class DB
    {
        public static DataTable ReadData(string ProcName, SqlParameter[] Params)
        {
            DataTable DT = new DataTable();
            string connString = "Data Source=DESKTOP-DE8DKHT\\SQLEXPRESS;Initial Catalog=PakFoodsPartnership;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //Your Connection
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            using (SqlDataAdapter sda = new SqlDataAdapter(ProcName, conn))
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;

                //Create a command to execute your Stored Procedure
                sda.SelectCommand.Parameters.AddRange(Params);
                //Open your connection
                conn.Open();
                //Execute your Stored Procedure
                sda.Fill(DT);
                //Close the connection
                conn.Close();
            }
            return DT;
        }

        public static string ReturnPersonID(string ProcName, SqlParameter[] Params)
        {          
            
            string ID;
            //Your Connection
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            using (SqlDataAdapter sda = new SqlDataAdapter(ProcName, conn))
            {
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;

                //Create a command to execute your Stored Procedure
                sda.SelectCommand.Parameters.AddRange(Params);
                //Open your connection
                SqlParameter outputParam = sda.SelectCommand.Parameters.Add("@NewID", SqlDbType.VarChar);
                outputParam.Direction = ParameterDirection.Output;
                outputParam.Size = 10;
                conn.Open();
                //Execute your Stored Procedure
                sda.SelectCommand.ExecuteNonQuery();
                ID = Convert.ToString(outputParam.Value);
                //Close the connection
                conn.Close();
            }
            return ID;
        }
        public static void DeleteData(string ProcName, SqlParameter[] Params)
        {        
            
            //Your Connection
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            using (SqlDataAdapter sda = new SqlDataAdapter(ProcName, conn))
            {
                sda.UpdateCommand = new SqlCommand(ProcName, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
             
                //Create a command to execute your Stored Procedure              
                //Open your connection
                conn.Open();
                sda.UpdateCommand.Parameters.AddRange(Params);
                //Execute your Stored Procedure
                sda.UpdateCommand.ExecuteNonQuery();

                //Close the connection
                conn.Close();
            }
       
        }
        public static int  UpdateData(string ProcName, SqlParameter[] Params, ref int ID)
        {
         
         
            int result;
            //Your Connection
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            using (SqlDataAdapter sda = new SqlDataAdapter(ProcName, conn))
            {
                SqlParameter OutID = new SqlParameter();
                SqlParameter DyanmicOrgID = new SqlParameter();
                int index = 0;
                sda.UpdateCommand = new SqlCommand(ProcName, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                foreach(SqlParameter p in Params)
                {
                    if (p.ParameterName == "@OutID")
                    {
                        OutID = p;
                    }
                    else if (p.ParameterName == "@NewDynamicOrgID")
                    {
                        DyanmicOrgID = p;
                    }else 
                    {
                        sda.UpdateCommand.Parameters.Add(p);
                    }

                }

                if (OutID.ParameterName == "@OutID")
                {
                    OutID.Direction = ParameterDirection.Output;
                    OutID.SqlDbType = SqlDbType.Int;
                    OutID.Size = 32;
                    sda.UpdateCommand.Parameters.Add(OutID);
                }
                if (DyanmicOrgID.ParameterName == "@NewDynamicOrgID")
                {
                    DyanmicOrgID.Direction = ParameterDirection.InputOutput;
                    DyanmicOrgID.SqlDbType = SqlDbType.Int;
                    DyanmicOrgID.Size = 32;
                    sda.UpdateCommand.Parameters.Add(DyanmicOrgID);
                }
                //Create a command to execute your Stored Procedure              
                //Open your connection
                conn.Open();            
                //Execute your Stored Procedure
                result = Functions.ToInt32(sda.UpdateCommand.ExecuteNonQuery());

                ID = Convert.ToInt32(OutID.Value);
                if(ID == 0)
                ID = Convert.ToInt32(DyanmicOrgID.Value);


                //Close the connection
                conn.Close();
            }
            return result;
        }
        public static string _UpdateDataS(string ProcName, SqlParameter[] Params)
        {

           
            string result;
            //Your Connection
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            using (SqlDataAdapter sda = new SqlDataAdapter(ProcName, conn))
            {
                sda.UpdateCommand = new SqlCommand(ProcName, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                //Create a command to execute your Stored Procedure
                sda.UpdateCommand.Parameters.AddRange(Params);
                //Open your connection
                conn.Open();

                //Execute your Stored Procedure
                result = Functions.ToString(sda.UpdateCommand.ExecuteNonQuery());
                //Close the connection
                conn.Close();
            }
            return result;
        }

        public static class StoredProcedures
        {

            public static SqlParameter[] uspReadUsers(string UserID, bool? UnlockRecords = null)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@UserID", UserID), new SqlParameter("@UnlockRecords", UnlockRecords) };
                return sqlParams;
            }
            public static SqlParameter[] uspRetrieveUsers(string UserID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@UserID", UserID) };
                return sqlParams;
            }
            public static SqlParameter[] uspGetNewPersonID(string Title, string Forename, string MiddleName, string Surname)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@Title", Title), new SqlParameter("@Forename", Forename), new SqlParameter("@MiddleName", MiddleName), new SqlParameter("@Surname", Surname) };
                return sqlParams;
            }
            public static SqlParameter[] uspRetrieveTasksByUser(string UserID, int NoOfDays, bool BeforeDays)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@UserID", UserID), new SqlParameter("@NoOfDays", NoOfDays), new SqlParameter("@BeforeDays", BeforeDays) };
                return sqlParams;
            }

            public static SqlParameter[] uspRetrieveTask(int ID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@ID", ID) };
                return sqlParams;
            }
            public static SqlParameter[] uspGetPropertyList(int BranchID, bool ActiveOnly = true)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@BranchID", BranchID), new SqlParameter("@ActiveOnly", ActiveOnly) };
                return sqlParams;
            }
            public static SqlParameter[] uspGetDynamicEntities(string Type, string SubType, int PropertyID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@Type", Type), new SqlParameter("@SubType", SubType), new SqlParameter("@FKID", PropertyID) };
                return sqlParams;
            }
    
            public static SqlParameter[] uspReadProperty(int ID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@ID", ID) };
                return sqlParams;
            }
            public static SqlParameter[] uspReadTenancy(int ID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@ID", ID) };
                return sqlParams;
            }
          
        public static SqlParameter[] uspGetTenancyTenants(int TenantID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@TenancyID", TenantID) };
                return sqlParams;
            }
            public static SqlParameter[] uspGetPropertyTenancies(int PropertyID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@PropertyID", PropertyID) };
                return sqlParams;
            }
            public static SqlParameter[] uspReadTenancyRequirements(int PropertyID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@PropertyID", PropertyID) };
                return sqlParams;
            }
            public static SqlParameter[] uspGetPropertyImages(string Type, int PropertyID, int RoomID, int TenancyID, int InventoryID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@Type", Type), new SqlParameter("@PropertyID", PropertyID), new SqlParameter("@RoomID", RoomID), new SqlParameter("@TenancyID", TenancyID), new SqlParameter("@InventoryID", InventoryID) };
                return sqlParams;
            }
            public static SqlParameter[] uspRetrieveOrg(string ID,  int ParentID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@ID", ID), new SqlParameter("@ParentID", ParentID) };
                return sqlParams;
            }
            public static SqlParameter[] uspGetExistingOrgs(string Name, string TypeOfOrg, bool ExactMatch, string Status)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@Name", Name), new SqlParameter("@TypeOfOrg", TypeOfOrg), new SqlParameter("@ExactMatch", ExactMatch), new SqlParameter("@Status", Status) };
                return sqlParams;
            }
            public static SqlParameter[] uspGetOrgDetails(string ID, bool ReturnContactDetails)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@ID", ID), new SqlParameter("@ReturnContactDetails", ReturnContactDetails) };
                return sqlParams;
            }
            public static SqlParameter[] uspGetOrgContacts(string ID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@ID", ID) };
                return sqlParams;
            }
            public static SqlParameter[] uspGetExistingPeople(string ID, string Surname = null, string Forename = null, string TypeOfPerson = null, string Address = null, string Postcode = null, string Status = null)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@ID", ID), new SqlParameter("@Surname", Surname), new SqlParameter("@Forename", Forename), new SqlParameter("@TypeOfPerson", TypeOfPerson), new SqlParameter("@Address", Address), new SqlParameter("@Postcode", Postcode), new SqlParameter("@Status", Status) };
                return sqlParams;
            }
            public static SqlParameter[] uspGetInventoryList(string Type, int PropertyID, int RoomID, int TenancyID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@Type", Type), new SqlParameter("@PropertyID", PropertyID), new SqlParameter("@RoomID", RoomID), new SqlParameter("@TenancyID", TenancyID) };
                return sqlParams;
            }

            public static SqlParameter[] uspGetPropertyRoomList(int PropertyID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@PropertyID", PropertyID) };
                return sqlParams;
            }
            public static SqlParameter[] uspGetPropertyRoom(int ID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@ID", ID) };
                return sqlParams;
            }
            public static SqlParameter[] uspGetPropertyNotes(int ID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@ID", ID) };
                return sqlParams;
            }
            public static SqlParameter[] uspReadThirdParty(string ID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@ID", ID) };
                return sqlParams;
            }
            public static SqlParameter[] uspGetDynamicEntityFields(string Type, string SubType, int EntityID, string EntityName, int PropertyID, string OrgID, string PersonID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@Type", Type), new SqlParameter("@SubType", SubType), new SqlParameter("@EntityID", EntityID), new SqlParameter("@EntityName", EntityName), new SqlParameter("@FKID", PropertyID), new SqlParameter("@OrgID", OrgID), new SqlParameter("@PersonID", PersonID) };
                return sqlParams;
            }
            public static SqlParameter[] uspUpdateDynamicOrg(int? DynamicOrgID, int FKID, string OrgID, string OrgContactID, string Ref, int? NewDynamicOrgID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@DynamicOrgID", DynamicOrgID), new SqlParameter("@FKID", FKID), new SqlParameter("@OrgID", OrgID), new SqlParameter("@OrgContactID", OrgContactID), new SqlParameter("@Ref", Ref), new SqlParameter("@NewDynamicOrgID", NewDynamicOrgID) };
                return sqlParams;
            }
            public static SqlParameter[] uspGetTenancyList(int BranchID, bool ActiveOnly, bool Tenancies )
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@BranchID", BranchID), new SqlParameter("@ActiveOnly", ActiveOnly), new SqlParameter("@Tenancies", @Tenancies)};
                return sqlParams;
            }
            public static SqlParameter[] uspUpdateProperty(PropertyDetail Property, int ID, string UserID)
            {
                int? ParentID = null;
                //FOREGIN CONSTRAINTS FIXES
                if (Property.ParentID > 0)
                    ParentID = Property.ParentID;
                //-----
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@ID", ID), new SqlParameter("@ParentID", ParentID), new SqlParameter("@Status", Property.Status), new SqlParameter("@BranchID", Property.BranchID),
                    new SqlParameter("@BuildingType", Property.BuildingType), new SqlParameter("@NickName", Property.NickName), new SqlParameter("@Description", Property.Description), new SqlParameter("@MarketingDescription", Property.MarketingDescription),
                    new SqlParameter("@Size", Property.size), new SqlParameter("@AddressLine1  ", Property.AddressLine1 ), new SqlParameter("@AddressLine2", Property.AddressLine2), new SqlParameter("@AddressLine3 ", Property.AddressLine3),
                    new SqlParameter("@AddressLine4", Property.AddressLine4),new SqlParameter("@AddressLine5", Property.AddressLine5),new SqlParameter("@PostCode", Property.Postcode),new SqlParameter("@Latitude", Property.Latitude),
                    new SqlParameter("@Longtitude", Property.Longtitude),new SqlParameter("@AccessInformation", Property.AccessInformation),new SqlParameter("@YearBuilt", Property.YearBuilt),new SqlParameter("@Garages", Property.Garages),
                    new SqlParameter("@ParkingSpaces", Property.ParkingSpaces),new SqlParameter("@SmokeAlarms", Property.SmokeAlarms),new SqlParameter("@HouseAlarm", Property.HouseAlarm),new SqlParameter("@LandlordID", Property.LandlordID),
                    new SqlParameter("@CurrentValue", Property.CurrentValue),new SqlParameter("@ValuationDate", Property.ValuationDate),new SqlParameter("@ValuationNotes", Property.ValuationNotes),new SqlParameter("@PurchaseType", Property.PurchaseType),
                    new SqlParameter("@PurchasePrice", Property.PurchasePrice),new SqlParameter("@PurchaseDate", Property.PurchaseDate),new SqlParameter("@PurchaseNotes", Property.PurchaseNotes ),new SqlParameter("@SalePrice", Property.SalePrice),
                    new SqlParameter("@SaleDate", Property.SaleDate),new SqlParameter("@SaleNotes", Property.SaleNotes),new SqlParameter("@LeaseStart", Property.LeaseStart ),new SqlParameter("@LeaseEnd", Property.LeaseEnd),new SqlParameter("@LeaseNotes", Property.LeaseNotes),
                    new SqlParameter("@TemplateType", Property.TemplateType ),new SqlParameter("@UserID", UserID), new SqlParameter("@OutID" , ID)
                              };
                return sqlParams;
            }
            public static SqlParameter[] uspUpdatePropertyRoom(PropertyRoom r, string UserID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@ID", r.ID), new SqlParameter("@PropertyID", r.PropertyID), new SqlParameter("@Sequence", r.Sequence), new SqlParameter("@Title", r.Title), new SqlParameter("@Type", r.Type), new SqlParameter("@MarketingDescription", r.MarketingDescription), new SqlParameter("@Notes", r.Notes),
                new SqlParameter("@Length", r.Length),new SqlParameter("@Width", r.Width),new SqlParameter("@Height", r.Height),new SqlParameter("@Habitable", r.Habitable),new SqlParameter("@Communal", r.Communal),new SqlParameter("@UserID", UserID),new SqlParameter("@OutID", r.ID)};
                return sqlParams;
            }
            public static SqlParameter[] uspAppendPropertyNotes(int PropertyID, string NewNote)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@PropertyID", PropertyID), new SqlParameter("@NewNote", NewNote) };

                return sqlParams;
            }
            public static SqlParameter[] uspUpdateThirdParty(ThirdParty t, string UserID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@ID", t.ID  ), new SqlParameter("@TypeOfPerson", t.TypeOfPerson), new SqlParameter("@AddressLine1", t.AddressLine1), new SqlParameter("@AddressLine2", t.AddressLine2), new SqlParameter("@AddressLine3", t.AddressLine3), new SqlParameter("@AddressLine4", t.AddressLine4), new SqlParameter("@AddressLine5", t.AddressLine5), new SqlParameter("@EmailAddress", t.EmailAddress),
                 new SqlParameter("@Fax", t.Fax),  new SqlParameter("@Forename", t.Forename),  new SqlParameter("@Gender", t.Gender), new SqlParameter("@Suffix", t.Suffix   ),  new SqlParameter("@HomePhone", t.HomePhone),  new SqlParameter("@Middlename", t.MiddleName),  new SqlParameter("@Mobile", t.Mobile),  new SqlParameter("@Postcode", t.PostCode),  new SqlParameter("@Surname", t.Surname  ),
                 new SqlParameter("@WorkExtensionNumber", t.WorkExtensionNumber),  new SqlParameter("@WorkPhone", t.WorkPhone),  new SqlParameter("@PreferredContactMethod", t.PreferredContactMethod), new SqlParameter("@PreferredContactTime", t.PreferredContactTime), new SqlParameter("@Title", t.Title), new SqlParameter("@DateOfBirth", t.DateOfBirth), new SqlParameter("@Notes", t.Notes    ), new SqlParameter("@Dept", t.Dept), new SqlParameter("@Status", t.Status   ), new SqlParameter("@UserID", UserID),
                 new SqlParameter("@JobTitle", t.JobTitle), new SqlParameter("@ID2", t.ID2), new SqlParameter("@SubType", t.SubType), new SqlParameter("@NINUmber", t.NINumber), new SqlParameter("@BranchID", t.BranchID), new SqlParameter("@PaymentTerms", t.PaymentTerms), new SqlParameter("@SalesPerson", t.SalesPerson), new SqlParameter("@ISOCountryCode", t.ISOCountryCode   ), new SqlParameter("@ISOCurrencyCode", t.ISOCurrencyCode), new SqlParameter("@ISOLanguageCode", t.ISOLanguageCode), new SqlParameter("@MultipleJobsPerInvoice", t.MultipleJobsPerInvoice),
                 new SqlParameter("@TemplateType", t.TemplateType),  new SqlParameter("@PaymentTermsRecurrenceInfo", t.PaymentTermsRecurrenceInfo),  new SqlParameter("@HolidayEntitlement", t.HolidayEntitlement),  new SqlParameter("@MaritalStatus", t.MaritalStatus),  new SqlParameter("@DateStarted", t.DateStarted),  new SqlParameter("@DateFinished", t.DateFinished),  new SqlParameter("@Department", t.Department),  new SqlParameter("@LineManager", t.LineManager),  new SqlParameter("@Password", t.Password),  new SqlParameter("@RegistrationNumber", t.RegistrationNumber),  new SqlParameter("@Apprentice", t.Apprentice),  new SqlParameter("@AllowProductRequests", t.AllowProductRequests),
                 new SqlParameter("@EthnicOrigin", t.EthnicOrigin),  new SqlParameter("@CriminalConviction", t.CriminalConviction),  new SqlParameter("@CriminalConvictionDetails", t.CriminalConvictionDetails)};

                return sqlParams;
            }
            public static SqlParameter[] uspInsertThirdParty(ThirdParty cs, string UserID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@ID", cs.ID), new SqlParameter("@TypeOfPerson", cs.TypeOfPerson), new SqlParameter("@AddressLine1", cs.AddressLine1), new SqlParameter("@AddressLine2", cs.AddressLine2),
                    new SqlParameter("@AddressLine3", cs.AddressLine3), new SqlParameter("@AddressLine4", cs.AddressLine4), new SqlParameter("@AddressLine5", cs.AddressLine5), new SqlParameter("@EmailAddress", cs.EmailAddress), new SqlParameter("@Fax", cs.Fax),
                    new SqlParameter("@Forename", cs.Forename), new SqlParameter("@Gender", cs.Gender), new SqlParameter("@HomePhone", cs.HomePhone), new SqlParameter("@Middlename", cs.MiddleName), new SqlParameter("@Mobile", cs.Mobile), new SqlParameter("@Postcode", cs.PostCode),
                    new SqlParameter("@Surname", cs.Surname), new SqlParameter("@WorkExtensionNumber", cs.WorkExtensionNumber), new SqlParameter("@WorkPhone", cs.WorkPhone), new SqlParameter("@PreferredContactMethod", cs.PreferredContactMethod),
                    new SqlParameter("@PreferredContactTime", cs.PreferredContactTime), new SqlParameter("@Title", cs.Title), new SqlParameter("@DateOfBirth", cs.DateOfBirth), new SqlParameter("@Notes", cs.Notes), new SqlParameter("@Dept", cs.Dept),
                    new SqlParameter("@Status", cs.Status), new SqlParameter("@UserID", UserID), new SqlParameter("@Suffix", cs.Suffix), new SqlParameter("@JobTitle", cs.JobTitle), new SqlParameter("@ID2", cs.ID2), new SqlParameter("@SubType", cs.SubType),
                    new SqlParameter("@NINUmber", cs.NINumber), new SqlParameter("@BranchID", cs.BranchID), new SqlParameter("@PaymentTerms", cs.PaymentTerms), new SqlParameter("@SalesPerson", cs.SalesPerson), new SqlParameter("@ISOCountryCode", cs.ISOCountryCode),
                    new SqlParameter("@ISOCurrencyCode", cs.ISOCurrencyCode), new SqlParameter("@ISOLanguageCode", cs.ISOLanguageCode), new SqlParameter("@MultipleJobsPerInvoice", cs.MultipleJobsPerInvoice), new SqlParameter("@TemplateType", cs.TemplateType),
                    new SqlParameter("@PaymentTermsRecurrenceInfo", cs.PaymentTermsRecurrenceInfo), new SqlParameter("@HolidayEntitlement", cs.HolidayEntitlement), new SqlParameter("@MaritalStatus", cs.MaritalStatus), new SqlParameter("@DateStarted", cs.DateStarted),
                    new SqlParameter("@DateFinished", cs.DateFinished), new SqlParameter("@Department", cs.Department), new SqlParameter("@LineManager", cs.LineManager), new SqlParameter("@Password", cs.Password), new SqlParameter("@RegistrationNumber", cs.RegistrationNumber),
                    new SqlParameter("@Apprentice", cs.Apprentice), new SqlParameter("@AllowProductRequests", cs.AllowProductRequests), new SqlParameter("@EthnicOrigin", cs.EthnicOrigin), new SqlParameter("@CriminalConviction", cs.CriminalConviction),
                    new SqlParameter("@CriminalConvictionDetails", cs.CriminalConvictionDetails), new SqlParameter("@Identity", 0) };
                return sqlParams;
            }
            public static SqlParameter[] uspUpdateDynamicData(int ID, int? DynamicOrgID, int? DynamicPersonID, int? FKID, int? FieldID, string FieldValue, int? EntityID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@ID", ID), new SqlParameter("@DynamicOrgID", DynamicOrgID), new SqlParameter("@DynamicPersonID", DynamicPersonID), new SqlParameter("@FKID", FKID), new SqlParameter("@FieldID", FieldID), new SqlParameter("@FieldValue", FieldValue), new SqlParameter("@EntityID", EntityID) };

                return sqlParams;
            }
            public static SqlParameter[] uspUpdateOrg(Organisation cs, string UserID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@ID", cs.ID), new SqlParameter("@Name", cs.Name), new SqlParameter("@AddressLine1", cs.AddressLine1),
                    new SqlParameter("@AddressLine2", cs.AddressLine2), new SqlParameter("@AddressLine3", cs.AddressLine3), new SqlParameter("@AddressLine4", cs.AddressLine4), new SqlParameter("@AddressLine5", cs.AddressLine5),
                    new SqlParameter("@Postcode", cs.PostCode), new SqlParameter("@Phone", cs.Phone), new SqlParameter("@Fax", cs.Fax), new SqlParameter("@HomePage", cs.HomePage), new SqlParameter("@VATRegistered", cs.VATRegistered),
                    new SqlParameter("@VATNo", cs.VATNo), new SqlParameter("@Status", cs.Status),new SqlParameter("@Sector", cs.Sector), new SqlParameter("@SubSector", cs.SubSector), new SqlParameter("@UserID", UserID),
                    new SqlParameter("@Source", cs.Source), new SqlParameter("@AlternativeRef", cs.AlternativeRef), new SqlParameter("@OurAccountNo", cs.OurAccountNo), new SqlParameter("@BillingContactID", cs.BillingContactID),
                    new SqlParameter("@PaymentTerms", cs.PaymentTerms), new SqlParameter("@SalesPerson", cs.SalesPerson), new SqlParameter("@ISOCountryCode", cs.ISOCountryCode), new SqlParameter("@ISOCurrencyCode", cs.ISOCurrencyCode),
                    new SqlParameter("@ISOLanguageCode", cs.ISOLanguageCode), new SqlParameter("@MultipleJobsPerInvoice", cs.MultipleJobsPerInvoice), new SqlParameter("@TemplateType", cs.TemplateType),
                    new SqlParameter("@PaymentTermsRecurrenceInfo", cs.PaymentTermsRecurrenceInfo) };
                return sqlParams;
            }
            public static SqlParameter[] UspGetNewOrgID(string Name)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@Name", Name) };
                return sqlParams;
            }
            public static SqlParameter[] uspInsertOrg(Organisation cs, string UserID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@ID", cs.ID), new SqlParameter("@TypeOfOrganisation", cs.TypeOfOrganisation), new SqlParameter("@Name", cs.Name), new SqlParameter("@AddressLine1", cs.AddressLine1),
                    new SqlParameter("@AddressLine2", cs.AddressLine2), new SqlParameter("@AddressLine3", cs.AddressLine3), new SqlParameter("@AddressLine4", cs.AddressLine4), new SqlParameter("@AddressLine5", cs.AddressLine5),
                    new SqlParameter("@Postcode", cs.PostCode), new SqlParameter("@Phone", cs.Phone), new SqlParameter("@Fax", cs.Fax), new SqlParameter("@HomePage", cs.HomePage), new SqlParameter("@VATRegistered", cs.VATRegistered),
                    new SqlParameter("@VATNo", cs.VATNo), new SqlParameter("@Status", cs.Status), new SqlParameter("@Sector", cs.Sector), new SqlParameter("@SubSector", cs.SubSector), new SqlParameter("@Notes", cs.Notes),
                    new SqlParameter("@UserID", UserID), new SqlParameter("@Source", cs.Source), new SqlParameter("@AlternativeRef", cs.AlternativeRef), new SqlParameter("@OurAccountNo", cs.OurAccountNo),
                    new SqlParameter("@BillingContactID", cs.BillingContactID), new SqlParameter("@PaymentTerms", cs.PaymentTerms), new SqlParameter("@SalesPerson", cs.SalesPerson), new SqlParameter("@ISOCountryCode", cs.ISOCountryCode),
                    new SqlParameter("@ISOCurrencyCode", cs.ISOCurrencyCode), new SqlParameter("@ISOLanguageCode", cs.ISOLanguageCode), new SqlParameter("@MultipleJobsPerInvoice", cs.MultipleJobsPerInvoice),
                    new SqlParameter("@TemplateType", cs.TemplateType), new SqlParameter("@PaymentTermsRecurrenceInfo", cs.PaymentTermsRecurrenceInfo), new SqlParameter("@Identity", 0) };
                return sqlParams;
            }
            public static SqlParameter[] uspUpdateTenancyTenants(int ID, int TenancyDetailsID, string TenantID, string UserID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@ID", ID), new SqlParameter("@TenancyDetailsID", TenancyDetailsID), new SqlParameter("@TenantID", TenantID), new SqlParameter("@UserID", UserID) };
                return sqlParams;
            }
            public static SqlParameter[] uspUpdateTenancyDetails(TenancyDetail cs , string UserID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@ID", cs.ID), new SqlParameter("@PropertyID", cs.PropertyID), new SqlParameter("@Status", cs.Status), new SqlParameter("@TenancyType", cs.TenancyType), new SqlParameter("@StartDate", cs.StartDate),
                    new SqlParameter("@EndDate", cs.EndDate), new SqlParameter("@Rent", cs.Rent), new SqlParameter("@Frequency", cs.Frequency), new SqlParameter("@RentDueDay", cs.RentDueDay), new SqlParameter("@DepositReceived", cs.DepositReceived),
                    new SqlParameter("@DepositNotes", cs.DepositNotes), new SqlParameter("@DateDepositProtected", cs.DateDepositProtected), new SqlParameter("@DepositReturned", cs.DepositReturned),
                    new SqlParameter("@PaymentReference", cs.PaymentReference), new SqlParameter("@Notes", cs.Notes), new SqlParameter("@UserID", UserID), new SqlParameter("@OutID", ParameterDirection.Output) };
                return sqlParams;
            }
            public static SqlParameter[] uspUpdateTenancyRequirements(TenancyRequirement cs, string UserID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@PropertyID", cs.PropertyID), new SqlParameter("@FurnishedStatus", cs.FurnishedStatus), new SqlParameter("@Rent", cs.Rent), new SqlParameter("@Frequency", cs.Frequency), new SqlParameter("@Deposit", cs.Deposit), new SqlParameter("@DepositNotes", cs.DepositNotes), new SqlParameter("@PetsAllowed", cs.PetsAllowed), new SqlParameter("@PetsAllowedNotes", cs.PetsAllowedNotes), new SqlParameter("@BenefitsAllowed", cs.BenefitsAllowed), new SqlParameter("@SmokingAllowed", cs.SmokingAllowed), new SqlParameter("@AvailableFrom", cs.AvailableFrom), new SqlParameter("@Notes", cs.Notes), new SqlParameter("@UserID", UserID)};
                return sqlParams;
            }
            public static SqlParameter[] uspInsertTask(Task cs, string UserID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@Type", cs.Type), new SqlParameter("@Status", cs.Status), new SqlParameter("@UserID", cs.UserID), new SqlParameter("@LinkedReference", cs.LinkedReference), new SqlParameter("@Task", cs.task), new SqlParameter("@Priority", cs.Priority), new SqlParameter("@DueDate", cs.DueDate), new SqlParameter("@StartDate", cs.StartDate), new SqlParameter("@CompletedDate", cs.CompletedDate), new SqlParameter("@Overdue", cs.OverDue), new SqlParameter("@AutoReminder", cs.AutoReminder), new SqlParameter("@ReminderDate", cs.ReminderDate), new SqlParameter("@UpdateTime", DateTime.Now), new SqlParameter("@UpdateUser", UserID), new SqlParameter("@Identity", cs.ID)};
                return sqlParams;


            }
            public static SqlParameter[] uspUpdateTask(Task cs, string UserID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@ID", cs.ID), new SqlParameter("@Type", cs.Type), new SqlParameter("@Status", cs.Status), new SqlParameter("@UserID", cs.UserID), new SqlParameter("@LinkedReference", cs.LinkedReference), new SqlParameter("@Task", cs.task), new SqlParameter("@Priority", cs.Priority), new SqlParameter("@DueDate", cs.DueDate), new SqlParameter("@StartDate", cs.StartDate), new SqlParameter("@CompletedDate", cs.CompletedDate), new SqlParameter("@Overdue", cs.OverDue), new SqlParameter("@AutoReminder", cs.AutoReminder), new SqlParameter("@ReminderDate", cs.ReminderDate), new SqlParameter("@UpdateTime", DateTime.Now), new SqlParameter("@UpdateUser", UserID) };
                return sqlParams;
            }
            public static SqlParameter[] uspDeleteTenancyTenants(int TenancyDetailsID, string TenantID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@TenancyDetailsID", TenancyDetailsID), new SqlParameter("@TenantID", TenantID) };
                return sqlParams;
            }
            public static SqlParameter[] uspDeleteProperty(int ID, string UserID, string DeleteComments)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@ID", ID), new SqlParameter("@UserID", UserID), new SqlParameter("@DeleteComments", DeleteComments) };
                return sqlParams;
            }
            public static SqlParameter[] uspInsertOrgContact(string OrgID, string ContactID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@OrgID", OrgID), new SqlParameter("@ContactID", ContactID) };
                return sqlParams;
            }
            public static SqlParameter[] uspUpdatePropertyImage(int ID, int PropertyID, int? TenancyID, int? RoomID, int? InventoryID, string Type, string Title, string Description, string Filename, int Sequence, DateTime? DateAdded, string UserID, int OutID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@ID", ID), new SqlParameter("@PropertyID", PropertyID), new SqlParameter("@TenancyID", TenancyID), new SqlParameter("@RoomID", RoomID), new SqlParameter("@InventoryID", InventoryID), new SqlParameter("@Type", Type), new SqlParameter("@Title", Title), new SqlParameter("@Description", Description), new SqlParameter("@Filename", Filename), new SqlParameter("@Sequence", Sequence), new SqlParameter("@DateAdded", DateAdded), new SqlParameter("@UserID", UserID), new SqlParameter("@OutID", OutID) };
                return sqlParams;
            }
            public static SqlParameter[] uspDeletePropertyImage(int ID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@ID", ID) };
                return sqlParams;
            }
            public static SqlParameter[] uspDeleteTenancy(int ID, int PropertyID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@ID", ID), new SqlParameter("@PropertyID", PropertyID) };
                return sqlParams;
            }
            public static SqlParameter[] uspDeletePropertyRoom(int ID, int PropertyID)
            {
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@ID", ID), new SqlParameter("@PropertyID", PropertyID) };
                return sqlParams;
            }
        }
    }
}
