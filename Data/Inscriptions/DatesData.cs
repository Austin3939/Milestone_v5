using Inscript_v5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core.Objects;

namespace Inscript_v5.Data.Inscriptions
{
    public class DatesData
    {
        public static List<DatesModel> GetList()
        {
            var db = new Inscriptv4Entities();
            var model = db.DatesGetList();
            return FillModelList(model);
        }

        public static DatesModel Get(int DateID)
        {
            var db = new Inscriptv4Entities();
            var model = db.DatesGet(DateID).FirstOrDefault();
            return FillModel(model);
        }

        private static DatesModel FillModel(DatesGet_Result model)
        {
            if (model == null) return null;

            var itemModel = new DatesModel
            {
                DateID = model.DateID,
                Date = model.Date,
              

            };
            return itemModel;
        }

        private static List<DatesModel> FillModelList(IEnumerable<DatesGet_Result> models)
        {
            return models != null
               ? models.Select(FillModel).ToList()
               : new List<DatesModel>();
        }
    }
}