using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebPMS.Models;

namespace WebPMS
{
    public static class SessionManager
    {
        //set the login status in session for the current user.
        public static void setIsLoggedIn(bool value)
        {
            //value is true when the the usser logs in
            HttpContext.Current.Session["isLoggedIn"] = value;
            //value is false when the the usser logsout
            if (!value)
                HttpContext.Current.Session["isLoggedIn"] = null;
        }

        //check to see if the user is logged in
        public static bool isLoggedIn()
        {
            if (HttpContext.Current.Session["isLoggedIn"].Equals(null))
                return false;
            else
                return true;
        }

        //set current user in the sessoin
        public static void setCurrentUser(User value)
        {
            var str = JsonConvert.SerializeObject(value);
            HttpContext.Current.Session["CurrentUser"] = str;
        }
        public static void clearSession()
        {            
            HttpContext.Current.Session.Clear(); ;
        }
        //get current employee fro the session
        public static User getCurrentUser()
        {
            return JsonConvert.DeserializeObject<User>(Functions.ToString(HttpContext.Current.Session["CurrentUser"]));
        }


   
     

    }
}