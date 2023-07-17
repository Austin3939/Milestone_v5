using Inscript_v5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inscript_v5.Data.Inscriptions
{
    public class TranslationsData
    {
        public static List<TranslationsModel> GetList()
        {
            var db = new Inscriptv4Entities();
            var model = db.TranslationGetList();
            return FillModelList(model);
        }

        public static TranslationsModel Get(int TranslationID)
        {
            var db = new Inscriptv4Entities();
            var model = db.TranslationGet(TranslationID).FirstOrDefault();
            return FillModel(model);
        }

        private static TranslationsModel FillModel(TranslationGet_Result model)
        {
            if (model == null) return null;

            var itemModel = new TranslationsModel
            {
                TranslationID = model.TranslationID,
                InscriptionID = model.InscriptionID,
                Translator = model.Translator,
                Translation = model.Translation,
                Notes = model.Notes,


            };
            return itemModel;
        }

        private static List<TranslationsModel> FillModelList(IEnumerable<TranslationGet_Result> models)
        {
            return models != null
               ? models.Select(FillModel).ToList()
               : new List<TranslationsModel>();
        }
    }
}