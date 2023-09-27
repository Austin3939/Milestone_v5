using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Inscript_v5.Data.Inscriptions;
using Inscript_v5.Models;

namespace Inscript_v5.Controllers
{
    public class UsersController : Controller
    { 
         private Inscriptv4Entities db = new Inscriptv4Entities();

        // GET: User
        public ActionResult AdminIndex(string searchText)
        {
            if (Session["Role"] != null && Session["Role"].ToString() == "Admin")
            {
                var filteredData = UsersData.Filter(searchText);
                return View("AdminIndex", filteredData);
            }
            else
            {
                return RedirectToAction("Index/UserLogin");
            }
        }

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersModel user = UsersData.Get(id);
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
            var usersModel = new UsersModel();
            usersModel.RoleID = 1;
            return View(usersModel);
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsersModel users)
        {
            if (ModelState.IsValid)
            {
                
                UsersModel model = UsersData.Insert(users);
                users.UserID = model.UserID;
                ViewBag.NextView = true;
                return RedirectToAction("Index", "Home");
            }

            return View(users);
        }

        // GET: User/Edit
        public ActionResult Edit(int id)
        {

            var users = UsersData.Get(id);
            if (users == null)
            {
                return HttpNotFound();
            }

            return View(users);
        }

        // POST: User/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsersModel users)
        {
            if (ModelState.IsValid)
            {
                UsersData.Update(users);
                return RedirectToAction("Index");
            }

            return View(users);
        }

        // GET: User/Delete
        public ActionResult Delete(int id)
        {
            var users = UsersData.Get(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: User/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var users = UsersData.Get(id);
           UsersData.Delete(users);

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