using Inscript_v5.Data;
using Inscript_v5.Data.Inscriptions;
using Inscript_v5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Inscript_v5.Controllers
{
    public class UserPortalController : Controller
    {
        // GET: UserPortal
        public ActionResult Index()
        {
            return View(InscriptionsData.GetList());

        }
        // GET: UserInscriptions
        public ActionResult UserInscriptionsView(int id)
        {
            var inscriptions = UserInscriptionsData.GetList().Where(x => x.UserID == id).ToList();

            if (inscriptions.Count == 0)
            {
                ViewBag.Message = "No Saved Inscriptions";
                return PartialView();
            }

            return PartialView(inscriptions);
        }

        // GET: UserTranslations
        public ActionResult UserTranslationsView(int id)
        {
            var translations = UserTranslationsData.GetList().Where(x => x.CreatedByUserID == id).ToList();

            if (translations.Count == 0)
            {
                ViewBag.Message = "No User Translations";
                return PartialView();
            }

            return PartialView(translations);
        }

        public ActionResult AdminIndex()
        {
            return View();
        }
    }


}