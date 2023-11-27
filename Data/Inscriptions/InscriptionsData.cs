using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inscript_v5.Models;
using System.Data.Entity.Core.Objects;

namespace Inscript_v5.Data.Inscriptions
{
    public static class InscriptionsData
    {
        public static List<InscriptionsModel> GetList()
        {
            var db = new Inscriptv4Entities();
            var model = db.InscriptionGetList();
            return FillModelList(model);
        }

        public static InscriptionsModel Get(int InscriptionID)
        {
            var db = new Inscriptv4Entities();
            var model = db.InscriptionsGet(InscriptionID).FirstOrDefault();
            return FillModel(model);
        }

        

        private static InscriptionsModel FillModel(InscriptionsGet_Result model)
        {
            if (model == null) return null;

            var itemModel = new InscriptionsModel
            {
                InscriptionID = model.InscriptionID,
                InscriptionName = model.InscriptionName,
                DateID = model.DateID,
                Date = model.Date,
                LocationID = model.LocationID,
                Location = model.Location,
                LanguageID = model.LanguageID,
                Language = model.Language,
                Notes = model.Notes

            };
            return itemModel;
        }

        private static List<InscriptionsModel> FillModelList(IEnumerable<InscriptionsGet_Result> models)
        {
            return models != null
               ? models.Select(FillModel).ToList()
               : new List<InscriptionsModel>();
        }

        public static InscriptionsModel Insert(InscriptionsModel model)
        {
            var db = new Inscriptv4Entities();
            var newID = new ObjectParameter("InscriptionID", typeof(string));
            db.InsertInscription(
                model.InscriptionName,
                model.Date,
                model.Location,
                model.Language,
                model.Notes,
                newID
                );
            model.InscriptionID = (int)newID.Value;

            return model;
        }

        public static void Update(InscriptionsModel model)
        {
            var db = new Inscriptv4Entities();
            db.UpdateInscriptions(
                model.InscriptionID,
                model.InscriptionName,
                model.Notes,
                model.Date,
                model.DateID,
                model.Location,
                model.LocationID,
                model.Language,     
                model.LanguageID
                );
        }

        public static void Delete(InscriptionsModel model)
        {
            var db = new Inscriptv4Entities();
            db.DeleteInscription(
                model.InscriptionID
                );
        }

        public static void CancelInscription(InscriptionsModel model)
        {
            var db = new Inscriptv4Entities();
            db.CancelInscription(
                model.InscriptionID,
                model.DateID,
                model.LanguageID,
                model.LocationID
                );
        }

        public static List<InscriptionsModel> SelectRecent()
        {
            var db = new Inscriptv4Entities();
            var model = db.SelectRecent();
            return FillModelList(model);
        }
    }
}