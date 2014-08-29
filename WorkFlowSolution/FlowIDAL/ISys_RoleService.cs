using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowModels;

namespace FlowIDAL
{
    public interface ISys_RoleService
    {
        bool InsertRole(Sys_RoleModule model);
        bool DeleteRole(Sys_Role model);
        bool UpdateRole(Sys_RoleModule model);
        List<Sys_Role> GetSubRoleByModel(Sys_Role model);
        Sys_RoleModule GetSubRoleModuleByModel(FlowModels.Sys_Role model);
    }
}
