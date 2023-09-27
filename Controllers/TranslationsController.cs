using Inscript_v5.Data.Inscriptions;
using Inscript_v5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Util;

namespace Inscript_v5.Controllers
{
    public class TranslationsController : Controller
    {

    private Inscriptv4Entities db = new Inscriptv4Entities();

        // GET: Translation
        public ActionResult Index()
        {
            return View(TranslationsData.PublicGetList());
        }

        public ActionResult Filter(string searchText)
        {
            var filteredData = TranslationsData.Filter(searchText);
            return View("Filter", filteredData);
        }

        // GET: AdminTranslation
        public ActionResult AdminIndex(string searchText)
        {
            if (Session["Role"] != null && Session["Role"].ToString() == "Admin")
            {
                var filteredData = TranslationsData.Filter(searchText);
                return View("AdminIndex", filteredData);
            }
            else
            {
                return RedirectToAction("Index/UserLogin");
            }
        }

        public ActionResult Details(int id, int tid)
        {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                if (tid == 0)
                {
                    TranslationsModel translation = TranslationsData.GetDefault(id);
                    if (translation == null)
                    {
                        return Content("No Translation");
                    }
                    return PartialView(translation);
                }
                else
                {
                    TranslationsModel translation = TranslationsData.Get(id, tid);
                    if (translation == null)
                    {
                        return Content("No Translation");
                    }
                    return PartialView(translation);
                }
        }

        public ActionResult TranslationNotes(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TranslationsModel translation = TranslationsData.GetDefault(id);
            if (translation == null)
            {
                return Content("No Translation Notes");
            }
            return PartialView(translation);
        }

        public ActionResult UserTranslationDetails(int id, int tid)
        {
            TranslationsModel inscriptions = TranslationsData.Get(id, tid);
            if (inscriptions == null)
            {
                return HttpNotFound();
            }

            return View(inscriptions);
        }

        // GET: Translation/Create
        [HttpGet]
        public ActionResult Create(int id)
        {

            var model = new TranslationsModel();
            model.InscriptionID = id;
            model.CreatedByUserID = (int)Session["UserID"];


                return View(model);
        }

            // POST: Translation/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(TranslationsModel translation)
            {

                if (ModelState.IsValid)
                {
                TranslationsModel model = TranslationsData.Insert(translation);
                translation.InscriptionID = model.InscriptionID;
                translation.CreatedByUserID = model.CreatedByUserID;
                    return RedirectToAction("Index", "UserPortal");
                }

                return View(translation);
            }

            // GET: Translations/Edit
            public ActionResult Edit(int id)
            {

                var translations = TranslationsData.GetById(id);
                if (translations == null)
                {
                    return HttpNotFound();
                }

                return View(translations);
            }

            // POST: Translations/Edit
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(TranslationsModel translations)
            {
                if (ModelState.IsValid)
                {
                    TranslationsData.Update(translations);
                    return RedirectToAction("Index");
                }

                return View(translations);
            }

            // GET: Translartions/Delete
            public ActionResult Delete(int id)
            {
                var translation = TranslationsData.GetById(id);
                if (translation == null)
                    {
                    return HttpNotFound();
                    }
                 return View(translation);
            }

            // POST: Translations/Delete
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                var translation = TranslationsData.GetById(id);
                TranslationsData.Delete(translation);

                db.SaveChanges();
                return RedirectToAction("Index");
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