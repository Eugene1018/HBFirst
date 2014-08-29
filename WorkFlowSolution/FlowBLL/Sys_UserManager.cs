using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowDALFactory;
using FlowModels;
using FlowCommon;

namespace FlowBLL
{

    public class Sys_UserManager
    {
        private static FlowIDAL.ISys_UserService UserService = Factory.CreateInterfaceService<FlowIDAL.ISys_UserService>("Sys_UserService");
        public static bool CheckLogin(Sys_User model)
        {
            return UserService.CheckLogin(model);
        }
        public static bool InsertUser(Sys_User model)
        {
            return UserService.InsertUser(model);
        }
        public static List<Sys_User> GetAllUsers(params string[] sql)
        {
            return UserService.GetAllUsers(sql);
        }
        public static List<Sys_User> GetSubUserByModel(Sys_User model)
        {
            return UserService.GetSubUserByModel(model);
        }
         public static bool UpdateUser(Sys_User model)
         {
             return UserService.UpdateUser(model);
         }
         public static bool DeleteUser(Sys_User model)
         {
             return UserService.DeleteUser(model);
         }

    }
}
