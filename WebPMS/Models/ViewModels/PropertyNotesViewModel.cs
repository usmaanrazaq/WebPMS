using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPMS.Models
{
    public class PropertyNotesViewModel
    {
        public int PropertyID { get; set; }
        public PropertyNotes PropertyNotes { get; set; }
        public SideNavigationViewModel SideNavigationViewModel { get; set; }
    }
}