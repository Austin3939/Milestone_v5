using Inscript_v5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace Inscript_v5.Data.Inscriptions
{
    
       public class UserData
    {

        public static List<UserModel> GetList()
        {
            var db = new Inscriptv4Entities();
            var model = db.UserGetList();
            return FillModelList(model);
        }

        public static UserModel Get(int UserID)
        {
            var db = new Inscriptv4Entities();
            var model = db.UserGet(UserID).FirstOrDefault();
            return FillModel(model);
        }

        private static UserModel FillModel(UserGet_Result model)
        {
            if (model == null) return null;

            var itemModel = new UserModel
            {
                UserID = model.UserID,
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                RoleID = model.RoleID,
                
                

            };
            return itemModel;
        }

        private static List<UserModel> FillModelList(IEnumerable<UserGet_Result> models)
        {
            return models != null
               ? models.Select(FillModel).ToList()
               : new List<UserModel>();
        }

        public static UserModel Insert(UserModel model)
        {
            var db = new Inscriptv4Entities();
            var newID = new ObjectParameter("UserID", typeof(string));
            db.InsertUser(
                model.Name,
                model.Email,
                model.Password,
                model.RoleID
                );
            

            return model;
        }

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
    }
}
    
