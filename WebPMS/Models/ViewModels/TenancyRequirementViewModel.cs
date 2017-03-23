using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPMS.Models
{
    public class TenancyRequirementViewModel
    {

        public SideNavigationViewModel SideNavigationViewModel { get; set; }
        public TenancyRequirement Requirement { get; set; }
        public int PropertyID { get; set; }
    }
}