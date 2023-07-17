using Inscript_v5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core.Objects;

namespace Inscript_v5.Data.Inscriptions
{
    public class LocationsData
    {
        public static List<LocationsModel> GetList()
        {
            var db = new Inscriptv4Entities();
            var model = db.LocationGetList();
            return FillModelList(model);
        }

        public static LocationsModel Get(int LocationID)
        {
            var db = new Inscriptv4Entities();
            var model = db.LocationGet(LocationID).FirstOrDefault();
            return FillModel(model);
        }

        private static LocationsModel FillModel(LocationGet_Result model)
        {
            if (model == null) return null;

            var itemModel = new LocationsModel
            {
                LocationID = model.LocationID,
                Location = model.Location,


            };
            return itemModel;
        }

        private static List<LocationsModel> FillModelList(IEnumerable<LocationGet_Result> models)
        {
            return models != null
               ? models.Select(FillModel).ToList()
               : new List<LocationsModel>();
        }
    }
}