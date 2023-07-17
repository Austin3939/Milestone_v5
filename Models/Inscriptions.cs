using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inscript_v5.Models
{
    public class InscriptionsModel
    {
        public int InscriptionID { get; set; }
        public string InscriptionName { get; set; }

        public int? DateID { get; set; }
        public string Date { get; set; }

        public int? LocationID { get; set; }
        public string Location { get; set; }

        public int? LanguageID { get; set; }
        public string Language { get; set; }

        
    }
}