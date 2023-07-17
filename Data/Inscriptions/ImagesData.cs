using Inscript_v5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inscript_v5.Data.Inscriptions
{
    public class ImagesData
    {
        public static List<ImagesModel> GetList()
        {
            var db = new Inscriptv4Entities();
            var model = db.ImagesGetList();
            return FillModelList(model);
        }

        public static ImagesModel Get(int ImageID)
        {
            var db = new Inscriptv4Entities();
            var model = db.ImagesGet(ImageID).FirstOrDefault();
            return FillModel(model);
        }

        private static ImagesModel FillModel(ImagesGet_Result model)
        {
            if (model == null) return null;

            var itemModel = new ImagesModel
            {
                ImageID = model.ImageID,
                InscriptionID = model.InscriptionID,
                Image = model.Image,
                


            };
            return itemModel;
        }

        private static List<ImagesModel> FillModelList(IEnumerable<ImagesGet_Result> models)
        {
            return models != null
               ? models.Select(FillModel).ToList()
               : new List<ImagesModel>();
        }
    }
}