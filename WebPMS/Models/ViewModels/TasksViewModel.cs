using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPMS.Models
{
    public class TasksViewModel
    {
        public Task Task { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }
        public string returnURL { get; set; }
        public string mode { get; set; }
    }
}