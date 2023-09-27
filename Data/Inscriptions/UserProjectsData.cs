using Inscript_v5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Inscript_v5.Data.Inscriptions
{
    public class UserProjectsData
    {
        public static List<UserProjectsModel> GetList(int UserID)
        {
            var db = new Inscriptv4Entities();
            var model = db.UserProjectsGetList(UserID);
            return FillModelList(model);
        }

        public static UserProjectsModel Get(int ProjectID, int UserID)
        {
            var db = new Inscriptv4Entities();
            var model = db.UserProjectsGet(ProjectID, UserID).FirstOrDefault();
            return FillModel(model);
        }

        private static UserProjectsModel FillModel(UserProjectsGet_Result model)
        {
            if (model == null) return null;

            var itemModel = new UserProjectsModel
            {
                ProjectID = model.ProjectID,
                UserID = model.UserID,
                ProjectName = model.ProjectName,
                ProjectDocument = model.ProjectDocument

            };
            return itemModel;
        }

        private static List<UserProjectsModel> FillModelList(IEnumerable<UserProjectsGet_Result> models)
        {
            return models != null
               ? models.Select(FillModel).ToList()
               : new List<UserProjectsModel>();
        }

        public static UserProjectsModel Insert(UserProjectsModel model)
        {
            var db = new Inscriptv4Entities();
            var newID = new ObjectParameter("ProjectID", typeof(string));
            db.InsertUserProject(
                model.UserID,
                model.ProjectName
                );

            return model;
        }

        public static UserProjectsModel Remove(UserProjectsModel model)
        {
            var db = new Inscriptv4Entities();
            var newID = new ObjectParameter("ProjectID", typeof(string));
            db.InsertUserProject(
                model.UserID,
                model.ProjectName
                );

            return model;
        }

        public static void Update(UserProjectsModel model)
        {
            var db = new Inscriptv4Entities();
            db.UpdateProjectDocument(
                model.ProjectID,
                model.UserID,
                model.ProjectName,
                model.ProjectDocument
                );
        }
        public static void UpdateProjectName(UserProjectsModel model)
        {
            var db = new Inscriptv4Entities();
            db.UpdateProjectName(
                model.ProjectName,
                model.ProjectID
                );
        }

        public static void Delete(UserProjectsModel model)
        {
            var db = new Inscriptv4Entities();
            db.DeleteProject(
                model.ProjectID
                );
        }
    }
}