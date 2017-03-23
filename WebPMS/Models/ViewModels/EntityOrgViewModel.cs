using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPMS.Models
{
    public class EntityOrgViewModel
    {
        public Organisation orgDetail { get; set; }

        public IEnumerable<SelectListItem> orgContacts { get; set; }
        public ThirdParty orgContactDetail { get; set; }
    }
}