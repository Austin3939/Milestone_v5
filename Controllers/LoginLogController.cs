using Inscript_v5.Data.Inscriptions;
using Inscript_v5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inscript_v5.Controllers
{
    public class LoginLogController : Controller
    {
        private Inscriptv4Entities db = new Inscriptv4Entities();

        // GET: AdminTranslation
        public ActionResult AdminIndex()
        {
            if (Session["Role"] != null && Session["Role"].ToString() == "Admin")
            {
                return View(LoginLogData.GetList());
            }
            else
            {
                return RedirectToAction("Index/UserLogin");
            }
        }

    }
}