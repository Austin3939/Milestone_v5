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

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage="This Feild is Required")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This Feild is Required")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        public int RoleID { get; set; }  
        public string Role { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string LoginErrorMessage { get; set; }

    }
}