using Inscript_v5.Data.Inscriptions;
using Inscript_v5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inscript_v5.Controllers
{
    public class InscriptionTextController : Controller
    {

        private Inscriptv4Entities db = new Inscriptv4Entities();

        /* GET: InscriptionText
        public ActionResult Index()
        {
            return View(InscriptionTextData.GetList());
        }
        */

        // GET: InscriptionText/Details
        public ActionResult Details(int id)
        {
            List<InscriptionTextModel> inscriptions = InscriptionTextData.GetList(id).ToList();
            if (inscriptions == null)
            {
                return HttpNotFound();
            }

            return PartialView(inscriptions);

        }

        public ActionResult AdvancedSearch(string searchText)
        {
            var filteredData = InscriptionTextData.AdvancedSearch(searchText);
            return View("AdvancedSearch", filteredData);
        }

        public ActionResult TextDetailsPartial(int id)
        {
            List<InscriptionTextModel> inscriptions = InscriptionTextData.GetList(id).ToList();
            if (inscriptions == null)
            {
                return HttpNotFound();
            }

            return PartialView(inscriptions);

        }

        // GET: InscriptionText/Create
        [HttpGet]
        public ActionResult Create(int id)
        {
            var inscriptiontext = new InscriptionTextModel();
            inscriptiontext.InscriptionID = id;
            ViewBag.NextView = false;
            return PartialView(inscriptiontext);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InscriptionTextModel inscriptionText)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    InscriptionTextData.Insert(inscriptionText);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAndTranslate(InscriptionTextModel inscriptionText)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    InscriptionTextData.Insert(inscriptionText);
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


        // GET: InscriptionText/Edit
        public ActionResult Edit(int id)
        {

            var inscriptionText = InscriptionTextData.GetList(id);
            if (inscriptionText == null)
            {
                return HttpNotFound();
            }

            return PartialView(inscriptionText);
        }

        // POST: InscriptionText/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(List<InscriptionTextModel> inscriptionTextList)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int InscriptionID = inscriptionTextList.FirstOrDefault().InscriptionID.Value;
                    InscriptionTextData.Update(inscriptionTextList);
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

        // GET: InscriptionText/Delete
        public ActionResult Delete(int id)
        {
            var inscriptionText = InscriptionTextData.Get(id);
            if (inscriptionText == null)
            {
                return HttpNotFound();
            }
            return View(inscriptionText);
        }

        // POST: InscriptionText/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var inscriptionText = InscriptionTextData.Get(id);
            InscriptionTextData.Delete(inscriptionText);

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
