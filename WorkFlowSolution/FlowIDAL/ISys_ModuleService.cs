using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowIDAL
{
    public interface ISys_ModuleService
    {
        bool InsertModule(FlowModels.Sys_Module model);
        bool DeleteModule(FlowModels.Sys_Module model);
        bool UpdateModule(FlowModels.Sys_Module model);
        List<FlowModels.Sys_Module> GetSubModuleByModel(FlowModels.Sys_Module model);
        List<FlowModels.Sys_Module> GetSubModuleByRole(FlowModels.Sys_Role model);
    }
}
