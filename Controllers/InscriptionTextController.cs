using Inscript_v5.Data.Inscriptions;
using Inscript_v5.Models;
using System;
using System.Collections.Generic;
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

        // GET: InscriptionText/Details/5
        public ActionResult Details(int id)
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
            var model = new InscriptionTextModel();
            
                model.InscriptionID = id;
            
            
            
            return View(model);
        }

        /*
        public ActionResult NewEntry(int id)
        {
            var model = new InscriptionTextModel();

            model.InscriptionID = id;

            List<newEntry> newLineList = new List<newEntry>
            {
                new newEntry  { TextID = 0, InscriptionID = id, LineNumber = 1, Text = "" }
            };
            model.newLines = newLineList;
            ViewBag.List = newLineList;
            return PartialView(model);
        }
        */

        // POST: InscriptionText/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InscriptionTextModel inscriptionText)
        {
            if (ModelState.IsValid)
            { 
                InscriptionTextData.Insert(inscriptionText);
                RedirectToAction("Index");
            }

            return View(inscriptionText);
        }

        // GET: InscriptionText/Edit/5
        public ActionResult Edit(int id)
        {

            var inscriptionText = InscriptionTextData.Get(id);
            if (inscriptionText == null)
            {
                return HttpNotFound();
            }

            return View(inscriptionText);
        }

        // POST: InscriptionText/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InscriptionTextModel inscriptionText)
        {
            if (ModelState.IsValid)
            {
                InscriptionTextData.Update(inscriptionText);
                return RedirectToAction("Index");
            }

            return View(inscriptionText);
        }

        // GET: InscriptionText/Delete/5
        public ActionResult Delete(int id)
        {
            var inscriptionText = InscriptionTextData.Get(id);
            if (inscriptionText == null)
            {
                return HttpNotFound();
            }
            return View(inscriptionText);
        }

        // POST: InscriptionText/Delete/5
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
