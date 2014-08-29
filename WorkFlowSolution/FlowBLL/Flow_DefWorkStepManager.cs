using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowDALFactory;
using System.Data;

namespace FlowBLL
{
    public class Flow_DefWorkStepManager
    {
        private static FlowIDAL.IFlow_DefWorkStepService DefWorkStepService = Factory.CreateInterfaceService<FlowIDAL.IFlow_DefWorkStepService>("Flow_DefWorkStepService");
        public static DataSet GetSubDefWorkStepInfo(string FN_FlowID, string FN_StepID, bool IsBegin)
        {
          return  DefWorkStepService.GetSubDefWorkStepInfo(FN_FlowID,FN_StepID,IsBegin);
        }
    }
}
