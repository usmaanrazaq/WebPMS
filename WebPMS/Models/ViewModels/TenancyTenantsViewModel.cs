using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPMS.Models
{
    public class TenancyTenantsViewModel
    {
        public IEnumerable<SelectListItem> TenancyTenants { get; set; }
        public Organisation Tenant { get; set; }   
        public int SelectedTenancyTenant { get; set; }
    }
}