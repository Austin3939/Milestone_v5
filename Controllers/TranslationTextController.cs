using Inscript_v5.Data.Inscriptions;
using Inscript_v5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inscript_v5.Controllers
{
    public class TranslationTextController : Controller
    {

        private Inscriptv4Entities db = new Inscriptv4Entities();

        /* GET: TranslationText
        public ActionResult Index()
        {
            return View(TranslationTextData.GetList());
        }
        */

        // GET: TranslationText/Details
        public ActionResult Details(int id)
        {
            List<TranslationTextModel> translations = TranslationTextData.GetList(id).ToList();
            if (translations == null)
            {
                return HttpNotFound();
            }

            return PartialView(translations);

        }

        public ActionResult TextDetailsPartial(int id)
        {
            List<TranslationTextModel> translations = TranslationTextData.GetList(id).ToList();
            if (translations == null)
            {
                return HttpNotFound();
            }

            return PartialView(translations);

        }

        // GET: TranslationText/Create
        [HttpGet]
        public ActionResult Create(int id, int InscriptionID)
        {
            var translationtext = new TranslationTextModel();
            translationtext.InscriptionID = InscriptionID;
            translationtext.TranslationID = id;
            ViewBag.NextView = false;
            return PartialView(translationtext);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TranslationTextModel translationText)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TranslationTextData.Insert(translationText);
                    // You can optionally return a JSON response indicating success
                    return Json(new { success = true, message = "Form submitted successfully." });
                }

                // If there are validation errors, return a JSON response with error messages
                var errorMessages = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();

                return Json(new { success = false, errors = errorMessages });
            }
            catch (Exception ex)
            {
                // Handle unexpected server-side errors
                return Json(new { success = false, errorMessage = ex.Message });
            }
        }

        // GET: TranslationText/Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var translations = TranslationTextData.GetList(id);
            if (translations == null)
            {
                return HttpNotFound();
            }

            return PartialView(translations);
        }

        // POST: TranslationText/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(List<TranslationTextModel> translationTextList)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int InscriptionID = translationTextList.FirstOrDefault().InscriptionID.Value;
                    TranslationTextData.Update(translationTextList);
                    // You can optionally return a JSON response indicating success
                    return RedirectToAction("Details", "Inscriptions", new { id = InscriptionID });
                }

                // If there are validation errors, return a JSON response with error messages
                var errorMessages = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();

                return Json(new { success = false, errors = errorMessages });
            }
            catch (Exception ex)
            {
                // Handle unexpected server-side errors
                return Json(new { success = false, errorMessage = ex.Message });
            }
        }

        // GET: TranslationText/Delete
        public ActionResult Delete(int id)
        {
            var translationText = TranslationTextData.Get(id);
            if (translationText == null)
            {
                return HttpNotFound();
            }
            return View(translationText);
        }

        // POST: TranslationText/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var translationText = TranslationTextData.Get(id);
            TranslationTextData.Delete(translationText);

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