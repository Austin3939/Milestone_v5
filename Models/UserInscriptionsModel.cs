using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inscript_v5.Models
{
    public class UserInscriptionsModel
    {
        public int UserInscriptionsID { get; set; }
        public int UserID { get; set; }
        public int InscriptionID { get; set; }
        public string InscriptionName { get; set; }

    }
}