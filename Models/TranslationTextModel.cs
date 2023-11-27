using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inscript_v5.Models
{
    public class TranslationTextModel
    {
        public int TextID { get; set; }
        public int? TranslationID { get; set; }
        public int? InscriptionID { get; set; }
        public string TranslationName { get; set; }
        public int CreatedByUserID { get; set; }
        public string Text { get; set; }
        public int? LineNumber { get; set; }
        public int Row { get; set; }
    }
}