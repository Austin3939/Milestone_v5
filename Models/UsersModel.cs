using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Inscript_v5.Models
{
    public class UsersModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage="This Feild is Required")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This Feild is Required")]
        public string Password { get; set; }
        public int RoleID { get; set; }  
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string LoginErrorMessage { get; set; }

    }
}