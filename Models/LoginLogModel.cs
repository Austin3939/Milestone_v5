using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inscript_v5.Models
{
    public class LoginLogModel
    {

        public int LoginID { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "Login Attempt")]
        public Boolean Success { get; set; }
        public string Email { get; set; }



    }
}