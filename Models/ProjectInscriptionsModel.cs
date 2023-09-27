using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inscript_v5.Models
{
    public class ProjectInscriptionsModel
    {
        public int ProjectInscriptionID { get; set; }
        public int ProjectID { get; set; }
        [Display(Name = "Saved Inscriptions")]
        public int UserInscriptionsID { get; set; }
        public int InscriptionID { get; set; }
        [Display(Name = "Inscription")]
        public string InscriptionName { get; set; }



    }
}