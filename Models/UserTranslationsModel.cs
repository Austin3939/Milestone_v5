using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inscript_v5.Models
{
    public class UserTranslationsModel
    {
        public int TranslationID { get; set; }
        [Display(Name = "User")]
        public int CreatedByUserID { get; set; }
        public int InscriptionID { get; set; }
        [Display(Name = "Inscription Name")]
        public string InscriptionName { get; set; }
        [Display(Name = "Translation Name")]
        public string TranslationName { get; set; }

    }

}