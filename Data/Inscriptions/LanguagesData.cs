using Inscript_v5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inscript_v5.Data.Inscriptions
{
    public class LanguagesData
    {
        public static List<LanguagesModel> GetList()
        {
            var db = new Inscriptv4Entities();
            var model = db.LanguageGetList();
            return FillModelList(model);
        }

        public static LanguagesModel Get(int LanguageID)
        {
            var db = new Inscriptv4Entities();
            var model = db.LanguageGet(LanguageID).FirstOrDefault();
            return FillModel(model);
        }

        private static LanguagesModel FillModel(LanguageGet_Result model)
        {
            if (model == null) return null;

            var itemModel = new LanguagesModel
            {
                LanguageID = model.LanguageID,
                Language = model.Language,


            };
            return itemModel;
        }

        private static List<LanguagesModel> FillModelList(IEnumerable<LanguageGet_Result> models)
        {
            return models != null
               ? models.Select(FillModel).ToList()
               : new List<LanguagesModel>();
        }
    }
}