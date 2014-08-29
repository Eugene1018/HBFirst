using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowDALFactory;

namespace FlowBLL
{
    public class Flow_DefWorkActionManager
    {
        private static FlowIDAL.IFlow_DefWorkActionService DefWorkActionService = Factory.CreateInterfaceService<FlowIDAL.IFlow_DefWorkActionService>("Flow_DefWorkActionService");
        public static List<FlowModels.Flow_DefWorkAction> GetSubDefActionByID(FlowModels.Flow_DefWorkAction model)
        {
            return DefWorkActionService.GetSubDefActionByID(model);
        }
        public  static bool CheckEndStep(string FlowID, string StepID)
        {
            return DefWorkActionService.CheckEndStep(FlowID, StepID);
        }
    }
}
