using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPMS
{
    public class ErrorController: Controller
    {
        public ActionResult Error()
        {
            return View();
        }
    }
}