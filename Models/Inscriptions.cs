using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Inscript_v5.Models
{
    public class InscriptionsModel
    {
        public int InscriptionID { get; set; }

        [Display(Name = "Inscription")]
        public string InscriptionName { get; set; }

        public int? DateID { get; set; }
        public string Date { get; set; }

        public int? LocationID { get; set; }
        public string Location { get; set; }

        public int? LanguageID { get; set; }
        public string Language { get; set; }
        public string Notes { get; set; }


    }
}