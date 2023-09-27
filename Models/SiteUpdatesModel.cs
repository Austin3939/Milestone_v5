using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inscript_v5.Models
{
    public class SiteUpdatesModel
    {
        public int UpdateID { get; set; }
        public string UpdateName { get; set; }
        public DateTime Date { get; set; }

        [AllowHtml]
        public string Text { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }

    }
}