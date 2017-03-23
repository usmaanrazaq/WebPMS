using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPMS.Models
{
    public class DynamicEntityFieldsViewModel
    {
        public int PropertyID { get; set; }
  
        public DynamicEntityFields DynamicEntityFields { get; set; }
        public SideNavigationViewModel SideNavigationViewModel { get; set; }
    }
}