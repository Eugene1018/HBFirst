using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowDALFactory;

namespace FlowBLL
{
    public class Sys_RoleManager
    {
        private static FlowIDAL.ISys_RoleService RoleService = Factory.CreateInterfaceService<FlowIDAL.ISys_RoleService>("Sys_RoleService");
        public static List<FlowModels.Sys_Role> GetSubRoleByModel(FlowModels.Sys_Role model)
        {
            return RoleService.GetSubRoleByModel(model);
        }
        public static FlowModels.Sys_RoleModule GetSubRoleModuleByModel(FlowModels.Sys_Role model)
        {
            return RoleService.GetSubRoleModuleByModel(model);
        }
        public static bool InsertRole(FlowModels.Sys_RoleModule model)
        {
            return RoleService.InsertRole(model);
        }

        public static bool UpdateRole(FlowModels.Sys_RoleModule model)
        {
            return RoleService.UpdateRole(model);
        }

        public static bool DeleteRole(FlowModels.Sys_Role model)
        {
            return RoleService.DeleteRole(model);
        }
    }
}
