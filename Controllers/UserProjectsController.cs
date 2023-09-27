using Aspose.Words.Saving;
using Aspose.Words;
using Inscript_v5.Models;
using Inscript_v5.Data.Inscriptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Xceed.Words.NET;
using SautinSoft;

namespace Inscript_v5.Data.Controllers
{
    public class UserProjectsController : Controller
    {
        private Inscriptv4Entities db = new Inscriptv4Entities();

        // GET: UserProject
        public ActionResult Index()
        {
            var UserID = (int)Session["UserID"];
            var userProjects = UserProjectsData.GetList(UserID);

            if (userProjects.Any())
            {
                return PartialView(userProjects);
            }
            else
            {
                ViewBag.Message = "No Saved Projects";
                return PartialView();
            }
        }


        public ActionResult Details(int id, int UserID)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProjectsModel project = UserProjectsData.Get(id, UserID);
            if (project == null)
            {
                return HttpNotFound();
            }

            return View(project);
        }

        // GET: UserProject/Create
        [HttpGet]
        public ActionResult Create()
        {
            var model = new UserProjectsModel();
            model.UserID = (int)Session["UserID"];
            return View(model);
        }

        // POST: UserProject/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserProjectsModel project)
        {
            if (ModelState.IsValid)
            {
                UserProjectsModel model = UserProjectsData.Insert(project);
                project.UserID = model.UserID;
                db.SaveChanges();
                return RedirectToAction("Index", "UserPortal");
            }

            return View(project);
        }

        public ActionResult Edit(int id, int UserID)
        {

            var document = UserProjectsData.Get(id, UserID);
            if (document == null)
            {
                return HttpNotFound();
            }

            return PartialView(document);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserProjectsModel document)
        {
            if (ModelState.IsValid)
            {
                UserProjectsData.Update(document);
                return Json(new { success = true, message = "Project Document Saved!" });
            }

            return Json(new { success = false, message = "Failed to update project document." });
        }

        [HttpGet]
        public ActionResult UpdateProjectName(int id, int UserID)
        {

            var project = UserProjectsData.Get(id, UserID);
            if (project == null)
            {
                return HttpNotFound();
            }

            return PartialView(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProjectName(UserProjectsModel project)
        {

                if (ModelState.IsValid)
                {
                    UserProjectsData.UpdateProjectName(project);
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, message = "An error occurred while updating the project name." });
                }

        }

        public ActionResult Delete(int id, int UserID)
        {
            var project = UserProjectsData.Get(id, UserID);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int UserID)
        {
            var project = UserProjectsData.Get(id, UserID);
            UserProjectsData.Delete(project);

            db.SaveChanges();
            return RedirectToAction("Index", "UserPortal");
        }

        public ActionResult DownloadProject(int id, int UserID)
        {
            var project = UserProjectsData.Get(id, UserID);
            if (project != null) 
            {
                string htmlContent = project.ProjectDocument;

                htmlContent = HttpUtility.UrlDecode(htmlContent);

                byte[] docxBytes = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    SautinSoft.HtmlToRtf h = new SautinSoft.HtmlToRtf();
                    h.OpenHtml(htmlContent);
                    if (h.ToDocx(ms))
                    {
                        docxBytes = ms.ToArray();
                    }
                }

                if (docxBytes != null)
                {
                    // Return the Word document for download
                    return File(docxBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "DownloadedDocument.docx");
                }
            }

            return HttpNotFound();

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



