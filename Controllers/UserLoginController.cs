using Inscript_v5.Data.Inscriptions;
using Inscript_v5.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Inscript_v5.Controllers
{
    public class UserLoginController : Controller
    {
        private Inscriptv4Entities db = new Inscriptv4Entities();

        public ActionResult Index(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsersModel user)
        {
            using (Inscriptv4Entities db = new Inscriptv4Entities())
            {
                if (ModelState.IsValid)
                {
                    var userDetails = UsersData.GetList().FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
                    if (userDetails != null)
                    {
                        FormsAuthentication.SetAuthCookie(userDetails.Email, false);
                        Session["UserID"] = userDetails.UserID;
                        Session["UserName"] = userDetails.UserName;
                        Session["Role"] = userDetails.Role;

                        return Json(new { success = true, redirectUrl = Url.Action("Index", "UserPortal") });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Login failed. Please check your credentials.");
                    }
                }

                return Json(new { success = false, errorMessage = "Login failed. Please check your credentials." });
            }
        }



        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.UtcNow - TimeSpan.FromDays(1));
            return RedirectToAction("Index", "UserLogin");
        }
        
    }
}
