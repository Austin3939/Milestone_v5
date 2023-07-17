using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inscript_v5.Models
{
    public class TranslationsModel
    {
        public int TranslationID { get; set; }
        public int? InscriptionID { get; set; }
        public string Translator { get; set; }
        public string Translation { get; set; }
        public string Notes { get; set; }
    }
}