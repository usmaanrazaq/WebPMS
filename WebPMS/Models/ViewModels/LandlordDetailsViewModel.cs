using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPMS.Models
{
    public class LandlordDetailsViewModel
    {
        public LandlordDetailsViewModel() { }
        public int PropertyID { get; set; }
  
        public ThirdParty ThirdParty { get; set; }
        public SideNavigationViewModel SideNavigationViewModel { get; set; }
    }
}