using Inscript_v5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace Inscript_v5.Data.Inscriptions
{
    public static class SiteUpdatesData
    {
        public static List<SiteUpdatesModel> GetList()
        {
            var db = new Inscriptv4Entities();
            var model = db.SiteUpdatesGetList();
            return FillModelList(model);
        }

        public static SiteUpdatesModel Get(int UpdateID)
        {
            var db = new Inscriptv4Entities();
            var model = db.SiteUpdatesGet(UpdateID).FirstOrDefault();
            return FillModel(model);
        }

        private static SiteUpdatesModel FillModel(SiteUpdatesGet_Result model)
        {
            if (model == null) return null;

            var itemModel = new SiteUpdatesModel
            {
                UpdateID = model.UpdateID,
                UpdateName = model.UpdateName,
                Date = model.Date,
                Text = model.Text,
                UserID = model.UserID,
                UserName = model.UserName


            };
            return itemModel;
        }

        private static List<SiteUpdatesModel> FillModelList(IEnumerable<SiteUpdatesGet_Result> models)
        {
            return models != null
               ? models.Select(FillModel).ToList()
               : new List<SiteUpdatesModel>();
        }

        public static SiteUpdatesModel Insert(SiteUpdatesModel model)
        {
            var db = new Inscriptv4Entities();
            var newID = new ObjectParameter("UpdateID", typeof(string));
            db.InsertSiteUpdate(
                model.UpdateName,
                model.Date,
                model.Text,
                model.UserID
                );

            return model;
        }

        public static void Update(SiteUpdatesModel model)
        {
            var db = new Inscriptv4Entities();
            db.UpdateSiteUpdate(
                model.UpdateID,
                model.UpdateName,
                model.Date,
                model.Text,
                model.UserID
                );
        }

        public static void Delete(SiteUpdatesModel model)
        {
            var db = new Inscriptv4Entities();
            db.DeleteSiteUpdate(
                model.UpdateID
                );
        }

        public static List<SiteUpdatesModel> SelectRecentSiteUpdates()
        {
            var db = new Inscriptv4Entities();
            var model = db.SelectRecentSiteUpdates();
            return FillModelList(model);
        }
    }
}