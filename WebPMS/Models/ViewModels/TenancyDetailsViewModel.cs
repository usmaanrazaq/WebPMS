using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPMS.Models
{
    public class TenancyDetailsViewModel
    {

        public IEnumerable<SelectListItem> PropertyTenancies { get; set; }
        public int SelectedTenancy { get; set; }
        public TenancyTenantsViewModel TenancyTenantsViewModel { get; set; }
        public TenancyDetail TenancyDetail { get; set; }
        public SideNavigationViewModel SideNavigationViewModel { get; set; }
        public int TenancyID { get; set; }
        public int PropertyID { get; set;}
        public PropertyImages Images { get; set; }

    }
}