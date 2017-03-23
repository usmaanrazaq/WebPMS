using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPMS.Models
{
    public class EntityViewModel
    {

        public int PropertyID { get; set; }
        public int DynamicOrgID { get; set; }
        public SideNavigationViewModel SideNavigationViewModel { get; set; }

        public DynamicEntityFields DEF { get; set; }

        public IEnumerable<SelectListItem> Organisations { get; set; }
     
       public EntityOrgViewModel EntityOrgViewModel { get; set; }
        public string EntityName { get; set; }



    }
}