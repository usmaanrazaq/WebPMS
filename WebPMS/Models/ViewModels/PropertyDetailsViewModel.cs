using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPMS.Models
{
    [Serializable]
    public class PropertyDetailsViewModel
    {
        public PropertyDetailsViewModel() { }
        public int PropertyID { get; set; }
        public PropertyDetail PropertyDetail { get; set; }
        public PropertyImages PropertyImages { get; set; }
        public InventoryList InventoryList { get; set; }
   
        public string PropertyPath { get; set; }

        public SideNavigationViewModel SideNavigationViewModel { get;set;}
        public IEnumerable<SelectListItem> SubUnitOf { get; set; }
    }
}