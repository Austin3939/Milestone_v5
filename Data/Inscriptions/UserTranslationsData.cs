using Inscript_v5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace Inscript_v5.Data.Inscriptions
{
    public class UserTranslationsData
    {

        public static List<UserTranslationsModel> GetList()
        {
            var db = new Inscriptv4Entities();
            var model = db.UserTranslationsGetList();
            return FillModelList(model);
        }

        private static UserTranslationsModel FillModel(UserTranslationsGetList_Result model)
        {
            if (model == null) return null;

            var itemModel = new UserTranslationsModel
            {
                TranslationID = model.TranslationID,
                CreatedByUserID = model.CreatedByUserID,
                InscriptionID = model.InscriptionID,
                InscriptionName = model.InscriptionName,
                TranslationName = model.TranslationName

            };
            return itemModel;
        }

        private static List<UserTranslationsModel> FillModelList(IEnumerable<UserTranslationsGetList_Result> models)
        {
            return models != null
               ? models.Select(FillModel).ToList()
               : new List<UserTranslationsModel>();
        }
    }
}