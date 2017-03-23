using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPMS.Models
{
    public class RoomDetailsViewModel
    {
        public IEnumerable<SelectListItem> PropertyRoomList { get; set; }
        public int SelectedRoomList { get; set; }
        public PropertyRoom PropertyRoom { get; set; }
        public PropertyImages PropertyImages { get; set; }
        public InventoryList InventoryList { get; set; }
        public SideNavigationViewModel SideNavigationViewModel { get; set; }

        public string PropertyPath { get; set; }
        public int PropertyID { get; set; }
    }
}