using Inscript_v5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Inscript_v5.Data.Inscriptions
{
    
    public class UsersData
    {

        public static List<UsersModel> GetList()
        {
            var db = new Inscriptv4Entities();
            var model = db.UserGetList();
            return FillModelList(model);
        }

        public static UsersModel Get(int UserID)
        {
            var db = new Inscriptv4Entities();
            var model = db.UserGet(UserID).FirstOrDefault();
            return FillModel(model);
        }

        public static List<UsersModel> Filter(string searchText)
        {
            var db = new Inscriptv4Entities();
            var model = db.FilterUsers(searchText);
            return FillModelList(model);
        }


        private static UsersModel FillModel(UserGet_Result model)
        {
            if (model == null) return null;

            var itemModel = new UsersModel
            {
                UserID = model.UserID,
                UserName = model.UserName,
                Email = model.Email,
                Password = model.Password,
                RoleID = model.RoleID,
                Role = model.Role,
                FirstName = model.FirstName,
                LastName = model.LastName
                
                

            };
            return itemModel;
        }

        private static List<UsersModel> FillModelList(IEnumerable<UserGet_Result> models)
        {
            return models != null
               ? models.Select(FillModel).ToList()
               : new List<UsersModel>();
        }

        public static UsersModel Insert(UsersModel model)
        {
            var db = new Inscriptv4Entities();
            var newID = new ObjectParameter("UserID", typeof(string));
            db.InsertUser(
                model.UserName,
                model.Email,
                model.Password,
                model.RoleID,
                model.FirstName,
                model.LastName
                );
            

            return model;
        }

        public static void Update(UsersModel model)
        {
            var db = new Inscriptv4Entities();
            db.UpdateUser(
                model.UserID,
                model.UserName,
                model.Email,
                model.Password,
                model.RoleID,
                model.FirstName,
                model.LastName
                );
        }

        public static void Delete(UsersModel model)
        {
            var db = new Inscriptv4Entities();
            db.DeleteUser(
                model.UserID
                );
        }
    }
}
    
