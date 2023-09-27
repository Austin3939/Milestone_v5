using Inscript_v5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace Inscript_v5.Data.Inscriptions
{
    public class ProjectInscriptionsData
    {

        public static List<ProjectInscriptionsModel> GetList()
        {
            var db = new Inscriptv4Entities();
            var model = db.ProjectInscriptionsGetList();
            return FillModelList(model);
        }

        public static ProjectInscriptionsModel Get(int ProjectInscriptionID)
        {
            var db = new Inscriptv4Entities();
            var model = db.ProjectInscriptionsGet(ProjectInscriptionID).FirstOrDefault();
            return FillModel(model);
        }


        private static ProjectInscriptionsModel FillModel(ProjectInscriptionsGet_Result model)
        {
            if (model == null) return null;

            var itemModel = new ProjectInscriptionsModel
            {
                ProjectInscriptionID = model.ProjectInscriptionID,
                ProjectID = model.ProjectID,
                UserInscriptionsID = model.UserInscriptionsID,
                InscriptionID = model.InscriptionID,
                InscriptionName = model.InscriptionName

            };
            return itemModel;
        }

        private static List<ProjectInscriptionsModel> FillModelList(IEnumerable<ProjectInscriptionsGet_Result> models)
        {
            return models != null
               ? models.Select(FillModel).ToList()
               : new List<ProjectInscriptionsModel>();
        }
        public static ProjectInscriptionsModel Add(ProjectInscriptionsModel model)
        {
            var db = new Inscriptv4Entities();
            var newID = new ObjectParameter("ProjectInscriptionID", typeof(string));
            db.AddToProject(
                model.ProjectID,
                model.UserInscriptionsID
                );

            return model;

        }
        public static void Remove(ProjectInscriptionsModel model)
        {
            var db = new Inscriptv4Entities();
            db.RemoveProjectInscription(
                model.ProjectInscriptionID
                );
        }

    }
}