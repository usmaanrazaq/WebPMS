using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPMS.Models
{
    public class SideNavigationViewModel
    {
        public DynamicEntities DynamicEntities { get; set; }
        public int PropertyID { get; set; }

        public int LandlordID { get; set; }
    }
}