using Inscript_v5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace Inscript_v5.Data.Inscriptions
{
    public class UserInscriptionsData
    {

        public static List<UserInscriptionsModel> GetList()
        {
            var db = new Inscriptv4Entities();
            var model = db.UserInscriptionsGetList();
            return FillModelList(model);
        }
        /*
        public static UserModel Get(int UserID)
        {
            var db = new Inscriptv4Entities();
            var model = db.UserGet(UserID).FirstOrDefault();
            return FillModel(model);
        }
        */

        private static UserInscriptionsModel FillModel(UserInscriptionsGetList_Result model)
        {
            if (model == null) return null;

            var itemModel = new UserInscriptionsModel
            {
                UserInscriptionsID = model.UserInscriptionsID,
                UserID = model.UserID,
                InscriptionID = model.InscriptionID,
                InscriptionName = model.InscriptionName

            };
            return itemModel;
        }

        private static List<UserInscriptionsModel> FillModelList(IEnumerable<UserInscriptionsGetList_Result> models)
        {
            return models != null
               ? models.Select(FillModel).ToList()
               : new List<UserInscriptionsModel>();
        }
        
        public static void Insert(int UserID, int InscriptionID)
        {
            var db = new Inscriptv4Entities();
            db.InsertUserInscriptions(
                UserID,
                InscriptionID
                );

            return;
          
        }
        public static void Remove(int UserID, int InscriptionID)
        {
            var db = new Inscriptv4Entities();
            db.RemoveSavedInscription(
                UserID,
                InscriptionID
                );
        }

        /*
        public static void Update(UserModel model)
        {
            var db = new Inscriptv4Entities();
            db.UpdateUser(
                model.UserID,
                model.Name,
                model.Email,
                model.Password,
                model.RoleID
                );
        }

        public static void Delete(UserModel model)
        {
            var db = new Inscriptv4Entities();
            db.DeleteUser(
                model.UserID
                );
        }
        */
    }

}