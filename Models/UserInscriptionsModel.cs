using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inscript_v5.Models
{
    public class UserInscriptionsModel
    {
        [Display(Name = "Saved Inscriptions")]
        public int UserInscriptionsID { get; set; }
        public int UserID { get; set; }
        public int InscriptionID { get; set; }
        public string ProjectName { get; set; }
        [Display(Name = "Inscription")]
        public string InscriptionName { get; set; }

        [AllowHtml]
        public string ProjectDocument { get; set; }


    }
}