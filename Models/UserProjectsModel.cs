using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inscript_v5.Models
{
    public class UserProjectsModel
    {
        public int ProjectID { get; set; }
        public int UserID { get; set; }
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [AllowHtml]
        public string ProjectDocument { get; set; }

    }

}