using Inscript_v5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace Inscript_v5.Data.Inscriptions
{
    public class TranslationTextData
    {

        public static List<TranslationTextModel> GetList(int TranslationID)
        {
            var db = new Inscriptv4Entities();
            var model = db.TranslationTextGetList(TranslationID);
            return FillModelList(model);
        }

        public static TranslationTextModel Get(int TextID)
        {
            var db = new Inscriptv4Entities();
            var model = db.TranslationTextGet(TextID).FirstOrDefault();
            return FillModel(model);
        }

        private static TranslationTextModel FillModel(TranslationTextGet_Result model)
        {
            if (model == null) return null;

            var itemModel = new TranslationTextModel
            {
                TextID = model.TextID,
                TranslationID = model.TranslationID,
                TranslationName = model.TranslationName,
                CreatedByUserID = model.CreatedByUserID,
                Text = model.Text,
                LineNumber = model.LineNumber,
                InscriptionID = model.InscriptionID
            };

            return itemModel;
        }

        private static List<TranslationTextModel> FillModelList(IEnumerable<TranslationTextGet_Result> models)
        {
            return models != null
               ? models.Select(FillModel).ToList()
               : new List<TranslationTextModel>();
        }

        public static TranslationTextModel Insert(TranslationTextModel model)
        {
            var db = new Inscriptv4Entities();
            var newID = new ObjectParameter("TextID", typeof(int));

            db.InsertTranslationText(
                model.TranslationID,
                model.LineNumber,
                model.Text,
                model.InscriptionID
            );

            return model;
        }


        public static void Update(List<TranslationTextModel> translationTextList)
        {
            using (var db = new Inscriptv4Entities())
            {
                foreach (var item in translationTextList)
                {
                    db.UpdateTranslationText(
                        item.TextID,
                        item.TranslationID,
                        item.Text,
                        item.LineNumber
                        );
                }
            }
        }

        public static void Delete(TranslationTextModel model)
        {
            var db = new Inscriptv4Entities();
            db.DeleteTranslationText(
                model.TranslationID
                );
        }

    }
}