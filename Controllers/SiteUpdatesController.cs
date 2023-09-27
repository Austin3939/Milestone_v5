using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inscript_v5.Data.Inscriptions;
using Inscript_v5.Models;

namespace Inscript_v5.Controllers
{
    public class SiteUpdatesController : Controller
    {
        private Inscriptv4Entities db = new Inscriptv4Entities();
        // GET: SiteUpdates
        public ActionResult Index()
        {
            return View(SiteUpdatesData.GetList());
        }

        public ActionResult AdminIndex()
        {
            return View(SiteUpdatesData.GetList());
        }

        // GET: SiteUpdates/Details
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteUpdatesModel update = SiteUpdatesData.Get(id);

            return PartialView(update);
        }

        // GET: SiteUpdates/Create
        [HttpGet]
        public ActionResult Create()
        {
            SiteUpdatesModel model = new SiteUpdatesModel();
            model.Date = DateTime.Now;
            model.UserID = (int)Session["UserID"];
            return View(model);
        }

        // POST: SiteUpdates/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SiteUpdatesModel update)
        {

            if (ModelState.IsValid)
            {
                SiteUpdatesModel model = SiteUpdatesData.Insert(update);
                return RedirectToAction("AdminIndex");
            }

            return View(update);
        }

        // GET: SiteUpdates/Edit
        public ActionResult Edit(int id)
        {

            var update = SiteUpdatesData.Get(id);
            if (update == null)
            {
                return HttpNotFound();
            }

            return View(update);
        }

        // POST: SiteUpdates/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SiteUpdatesModel update)
        {
            if (ModelState.IsValid)
            {
                SiteUpdatesData.Update(update);
                return RedirectToAction("AdminIndex");
            }

            return View(update);
        }

        // GET: SiteUpdates/Delete
        public ActionResult Delete(int id)
        {
            var update = SiteUpdatesData.Get(id);
            if (update == null)
            {
                return HttpNotFound();
            }
            return View(update);
        }

        // POST: SiteUpdates/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var update = SiteUpdatesData.Get(id);
            SiteUpdatesData.Delete(update);

            db.SaveChanges();
            return RedirectToAction("AdminIndex");
        }

        public ActionResult SelectRecent()
        {
            return PartialView(SiteUpdatesData.SelectRecentSiteUpdates());
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