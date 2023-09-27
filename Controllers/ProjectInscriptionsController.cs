using Inscript_v5.Data.Inscriptions;
using Inscript_v5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inscript_v5.Controllers
{
    public class ProjectInscriptionsController : Controller
    {
        private Inscriptv4Entities db = new Inscriptv4Entities();

        public ActionResult UserProjectInscriptionsView(int id)
        {
            var userInscriptions = ProjectInscriptionsData.GetList().Where(x => x.ProjectID == id);

            return PartialView(userInscriptions);
        }


        [HttpGet]
        public ActionResult AddInscription(int ProjectID)
        {
            var userID = (int)Session["UserID"];
            ViewBag.LoggedIn = true;
            var data = UserInscriptionsData.GetList().Where(x => x.UserID == userID);

            // Create a SelectList
            ViewBag.SelectInscription = new SelectList(data, "UserInscriptionsID", "InscriptionName");
            var model = new ProjectInscriptionsModel
            {
                ProjectID = ProjectID
            };


            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddInscription(ProjectInscriptionsModel model)
        {
            if (ModelState.IsValid)
            {
                ProjectInscriptionsData.Add(model);
                return Json(new { success = true, message = "Inscription Added to Project!" });
            }

            var userID = (int)Session["UserID"];
            var data = UserInscriptionsData.GetList().Where(x => x.UserID == userID);
            // If ModelState is not valid or an error occurred, re-populate the dropdown
            ViewBag.SelectInscription = new SelectList(data, "UserInscriptionsID", "InscriptionName");

            // Return the view with the model for re-displaying the form
            return PartialView(model);
        }

        // GET: Remove Inscription
        public ActionResult Remove(int id)
        {
            var model = ProjectInscriptionsData.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Remove Inscription
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveConfirmed(int id)
        {
            var model = ProjectInscriptionsData.Get(id);
            ProjectInscriptionsData.Remove(model);

            db.SaveChanges();
            return Json(new { success = true, message = "Inscription Added to Project!" });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}