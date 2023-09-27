using Inscript_v5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace Inscript_v5.Data.Inscriptions
{
    public class InscriptionTextData
    {
        public static List<InscriptionTextModel> GetList(int InscriptionID)
        {
            var db = new Inscriptv4Entities();
            var model = db.InscriptionTextGetList(InscriptionID);
            return FillModelList(model);
        }

        public static InscriptionTextModel Get(int TextID)
        {
            var db = new Inscriptv4Entities();
            var model = db.InscriptionTextGet(TextID).FirstOrDefault();
            return FillModel(model);
        }

        private static InscriptionTextModel FillModel(InscriptionTextGet_Result model)
        {
            if (model == null) return null;

            var itemModel = new InscriptionTextModel
            {
                TextID = model.TextID,
                InscriptionID = model.InscriptionID,
                InscriptionName = model.InscriptionName,
                Text = model.Text,
                LineNumber= model.LineNumber,
            };

            return itemModel;
        }

        private static List<InscriptionTextModel> FillModelList(IEnumerable<InscriptionTextGet_Result> models)
        {
            return models != null
               ? models.Select(FillModel).ToList()
               : new List<InscriptionTextModel>();
        }

        public static InscriptionTextModel Insert(InscriptionTextModel model)
        {
            var db = new Inscriptv4Entities();
            var newID = new ObjectParameter("TextID", typeof(int));

                db.InsertInscriptionText(
                    model.InscriptionID,
                    model.LineNumber,
                    model.Text
                );

            return model;
        }


        public static void Update(InscriptionTextModel model)
        {
            var db = new Inscriptv4Entities();
            db.UpdateInscriptionText(
                model.TextID,
                model.InscriptionID,
                model.Text,
                model.LineNumber
                );
        }

        public static void Delete(InscriptionTextModel model)
        {
            var db = new Inscriptv4Entities();
            db.DeleteInscriptionText(
                model.TextID
                );
        }
    }
}