using Inscript_v5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace Inscript_v5.Data.Inscriptions
{
    public class LoginLogData
    {

        public static List<LoginLogModel> GetList()
        {
            var db = new Inscriptv4Entities();
            var model = db.LoginLogGetList();
            return FillModelList(model);
        }

        public static LoginLogModel Get(int LoginID)
        {
            var db = new Inscriptv4Entities();
            var model = db.LoginLogGet(LoginID).FirstOrDefault();
            return FillModel(model);
        }

        private static LoginLogModel FillModel(LoginLogGet_Result model)
        {
            if (model == null) return null;

            var itemModel = new LoginLogModel
            {
                LoginID = model.LoginID,
                Date = model.Date,
                Success = model.Success,
                Email = model.Email

            };
            return itemModel;
        }

        private static List<LoginLogModel> FillModelList(IEnumerable<LoginLogGet_Result> models)
        {
            return models != null
               ? models.Select(FillModel).ToList()
               : new List<LoginLogModel>();
        }

        

    }
}