using Inscript_v5.Data.Inscriptions;
using Inscript_v5.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inscript_v5.Controllers
{
    public class UserLoginController : Controller
    {
        private Inscriptv4Entities db = new Inscriptv4Entities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(UserModel user)
        {
            using (Inscriptv4Entities db = new Inscriptv4Entities())
            {
                var userDetails = UserData.GetList().Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    user.LoginErrorMessage = "Wrong Username or Password";
                    return View("Index", user);
                }
                else
                {
                    Session["UserID"] = userDetails.UserID;
                    Session["Name"] = userDetails.Name;
                    return RedirectToAction("Index", "UserPortal");
                }
            }
         
        }

        public ActionResult Logout()
        {
            int UserID = (int) Session["UserID"];
            Session.Abandon();
            return RedirectToAction("Index", "UserLogin");
        }
    }
}
