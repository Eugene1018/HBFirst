using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowBLL
{
    public class Sys_ModuleManager
    {
        private static FlowIDAL.ISys_ModuleService ModuleService = FlowDALFactory.Factory.CreateInterfaceService<FlowIDAL.ISys_ModuleService>("Sys_ModuleService");
        public static List<FlowModels.Sys_Module> GetSubModuleByModel(FlowModels.Sys_Module model)
        {
            return ModuleService.GetSubModuleByModel(model);
        }
        public static bool InsertModule(FlowModels.Sys_Module model)
        {
            return ModuleService.InsertModule(model);
        }
        public static bool DeleteModule(FlowModels.Sys_Module model)
        {
            return ModuleService.DeleteModule(model);
        }
        public static bool UpdateModule(FlowModels.Sys_Module model)
        {
            return ModuleService.UpdateModule(model);
        }
        public static List<FlowModels.Sys_Module> GetSubModuleByRole(FlowModels.Sys_Role model)
        {
            return ModuleService.GetSubModuleByRole(model);
        }

    }
}
