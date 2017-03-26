using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebPMS
{
    public static class Functions
    {
        public static bool ToBool(object val)
        {
            string input;
            if (val is DBNull)
               input  = " ";
            else
                 input = Convert.ToString(val);

            if(input.Equals("true", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            if (input.Equals("false", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            // input will never be null, as you cannot call a method on a null object
            if (input.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (input.Equals("n", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            else
            {
                return false; //TODO
            }
        }

        public static int ToInt32(object val)
        {
            if (val is DBNull)
                return 0;

            return Convert.ToInt32(val);
        }

        public static string ToString(object val)
        {
            if(val is DBNull)
            {
                return "";
            }else
            {
                return Convert.ToString(val);
            }
        }

        public static float ToFloat(object val)
        {
            if(val is DBNull)
            {
                return 0.00f;
            }else
            {
                return Convert.ToSingle(val);
            }
        }

        public static double ToDouble(object val)
        {
            if (val is DBNull)
            {
                return 0.00;
            }
            else
            {
                return Convert.ToDouble(val);
            }
        }

        public static DateTime? ToDate(object val)
        {
            if (val is DBNull)
            {
                return null;
            }
            else
            {
                return Convert.ToDateTime(val);
            }
        }

        public static string GenerateThirdPartyID(string Title, string MiddleName, string Forename, string Surname)
        {            
            string ID = DB.ReturnPersonID(Constants.StoredProcedures.Read.uspGetNewPersonID, DB.StoredProcedures.uspGetNewPersonID(Title, Forename, MiddleName, Surname));       
            return ID;
        }
        public static string GenerateOrgID(string Name)
        {

           string ID = DB.ReturnPersonID(Constants.StoredProcedures.Read.UspGetNewOrgID, DB.StoredProcedures.UspGetNewOrgID(Name));
            return ID;
        }
    }
}