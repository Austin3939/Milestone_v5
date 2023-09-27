using Inscript_v5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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
            public static List<TranslationsModel> PublicGetList()
            {
                var db = new Inscriptv4Entities();
                var model = db.TranslationPublicGetList();
                return FillModelList(model);
            }
            public static TranslationsModel GetById(int TranslationID)
            {
                var db = new Inscriptv4Entities();
                var model = db.TranslationGetById(TranslationID).FirstOrDefault();
                return FillModel(model);
            }

            public static List<TranslationsModel> Filter(string searchText)
            {
                var db = new Inscriptv4Entities();
                var model = db.FilterTranslation(searchText);
                return FillModelList(model);
            }
    
            private static TranslationsModel FillModel(TranslationGetById_Result model)
        {
            if (model == null) return null;

            var itemModel = new TranslationsModel
            {
                TranslationID = model.TranslationID,
                CreatedByUserID = model.CreatedByUserID,
                UserName = model.UserName,
                PublicView = model.PublicView,
                InscriptionID = model.InscriptionID,
                InscriptionName = model.InscriptionName,
                TranslationText = model.TranslationText,
                TranslationName = model.TranslationName,
                Notes = model.Notes,



            };
            return itemModel;
            }

            public static TranslationsModel Get(int InscriptionID, int TranslationID)
            {
                var db = new Inscriptv4Entities();
                var model = db.TranslationGet(InscriptionID, TranslationID).FirstOrDefault();
                return FillModel(model);
            }

            public static TranslationsModel GetDefault(int InscriptionID)
            {
                var db = new Inscriptv4Entities();
                var model = db.TranslationDefaultGet(InscriptionID).FirstOrDefault();
                return FillModel(model);
            }

        private static TranslationsModel FillModel(TranslationGet_Result model)
            {
                if (model == null) return null;

                var itemModel = new TranslationsModel
                {
                    TranslationID = model.TranslationID,
                    CreatedByUserID = model.CreatedByUserID,
                    UserName = model.UserName,
                    PublicView = model.PublicView,
                    InscriptionID = model.InscriptionID,
                    InscriptionName = model.InscriptionName,
                    TranslationName = model.TranslationName,
                    TranslationText = model.TranslationText,
                    Notes = model.Notes,



                };
                return itemModel;
            }

            public static TranslationsModel Insert(TranslationsModel model)
            {
                    var db = new Inscriptv4Entities();
                    var newID = new ObjectParameter("InscriptionID", typeof(string));
                    db.InsertTranslation(
                        model.PublicView,
                        model.InscriptionID,
                        model.CreatedByUserID,
                        model.TranslationName,
                        model.TranslationText,
                        model.Notes
                        );

                    return model;
            }

        private static List<TranslationsModel> FillModelList(IEnumerable<TranslationGet_Result> models)
            {
                return models != null
                   ? models.Select(FillModel).ToList()
                   : new List<TranslationsModel>();
            }

        
        public static void Update(TranslationsModel model)
        {
            var db = new Inscriptv4Entities();
            db.UpdateTranslation(
                        model.InscriptionID,
                        model.PublicView,
                        model.TranslationName,
                        model.TranslationText,
                        model.Notes,
                        model.TranslationID
                );
   
        }
        
        
        public static void Delete(TranslationsModel model)
        {
            
        var db = new Inscriptv4Entities();
        db.DeleteTranslation(
            model.TranslationID
            );
            
        }

    }
}