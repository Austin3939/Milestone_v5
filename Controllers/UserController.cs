using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inscript_v5.Data.Inscriptions;
using Inscript_v5.Models;

namespace Inscript_v5.Controllers
{
    public class UserController : Controller
    { 
         private Inscriptv4Entities db = new Inscriptv4Entities();
    
        // GET: User
        public ActionResult Index(int id)
        {
            return View(UserData.Get(id));
        }

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModel user = UserData.Get(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.NextView = false;
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserModel user)
        {
            if (ModelState.IsValid)
            {
                UserModel model = UserData.Insert(user);
                user.UserID = model.UserID;
                ViewBag.NextView = true;
            }

            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {

            var user = UserData.Get(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserModel user)
        {
            if (ModelState.IsValid)
            {
                UserData.Update(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Inscriptions/Delete/5
        public ActionResult Delete(int id)
        {
            var user = UserData.Get(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = UserData.Get(id);
           UserData.Delete(user);

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