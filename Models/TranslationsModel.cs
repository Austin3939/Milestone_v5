using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Inscript_v5.Models
{
    public class TranslationsModel
    {
        public int TranslationID { get; set; }

        [Display(Name = "User")]
        public int CreatedByUserID { get; set; }

        [Display(Name = "Created by")]
        public string UserName { get; set; }

        [Display(Name = "Public")]
        public Boolean PublicView { get; set; }
        public int? InscriptionID { get; set; }

        [Display(Name = "Inscription")]
        public string InscriptionName { get; set; }

        [Display(Name = "Translation Name")]
        public string TranslationName { get; set; }

        [Display(Name = "Translation Text")]
        public string TranslationText { get; set; }
        public string Notes { get; set; }

    }

}