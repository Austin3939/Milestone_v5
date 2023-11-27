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

        public ActionResult TranslationNotes(int id, int tid)
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
                    return Content("No Notes");
                }
                return PartialView(translation);
            }
            else
            {
                TranslationsModel translation = TranslationsData.Get(id, tid);
                if (translation == null)
                {
                    return Content("No Translation Notes");
                }
                return PartialView(translation);
            }
        }

        public ActionResult UserTranslationDetails(int id, int tid)
        {

            List<TranslationsModel> translations = TranslationsData.GetForList(id); // Replace with your actual data retrieval logic

            // Create an instance of your view model and populate the Translations property
            TranslationsModel viewModel = new TranslationsModel
            {
                Translations = translations
            };

            TranslationsModel inscriptions = TranslationsData.Get(id, tid);
            if (inscriptions == null)
            {
                return HttpNotFound();
            }

            return View(inscriptions);
        }

        // POST: Translation/Create
        public ActionResult Create(int id)
        {
            var translation = new TranslationsModel();
            translation.InscriptionID = id;
            translation.CreatedByUserID = (int)Session["UserID"];

            if (ModelState.IsValid)
            {
                TranslationsModel model = TranslationsData.Insert(translation);
                translation.TranslationID = model.TranslationID;
                return RedirectToAction("Edit", new { translation.InscriptionID, translation.TranslationID });
            }

            return View(translation);
        }

        // GET: Translations/Edit
        public ActionResult Edit(int InscriptionID, int TranslationID)
        {

                var translations = TranslationsData.Get(InscriptionID, TranslationID);
                if (translations == null)
                {
                    return HttpNotFound();
                }

                return View(translations);
        }

            // POST: Translations/Edit
            [HttpPost]
            
            public ActionResult Edit(TranslationsModel translations)
            {
                if (ModelState.IsValid)
                {
                    TranslationsData.Update(translations);
                    return RedirectToAction("Index");
                }

                return View(translations);
            }

        // GET: Translations/Edit
        public ActionResult EditTranslationText(int InscriptionID, int TranslationID)
        {

            var translations = TranslationsData.Get(InscriptionID, TranslationID);
            if (translations == null)
            {
                return HttpNotFound();
            }

            return View(translations);
        }

        // POST: Translations/Edit
        [HttpPost]

        public ActionResult EditTranslationText(TranslationsModel translations)
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
                return RedirectToAction("Filter");
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