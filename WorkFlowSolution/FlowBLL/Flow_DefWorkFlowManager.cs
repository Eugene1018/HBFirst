using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowDALFactory;

namespace FlowBLL
{
    public class Flow_DefWorkFlowManager
    {
        private static FlowIDAL.IFlow_DefWorkFlowService DefWorkFlowService = Factory.CreateInterfaceService<FlowIDAL.IFlow_DefWorkFlowService>("Flow_DefWorkFlowService");
        public  static bool InsertDefWorkFlow(string flowXml,enXmlOpState enXml)
        {
            FlowModels.Flow_DefWorkFlow model = AnalysisFlowXml.GeneralFlow(flowXml, enXml);
            return DefWorkFlowService.InsertDefWorkFlow(model);
        }
        public static bool DeleteDefWorkFlow(string flowXml,enXmlOpState enXml)
        {
            FlowModels.Flow_DefWorkFlow model = AnalysisFlowXml.GeneralFlow(flowXml,enXml);
            return DefWorkFlowService.DeleteDefWorkFlow(model);
        }
        public static List<FlowModels.Flow_DefWorkFlow> GetAllDefWorkFlows()
        {
            return DefWorkFlowService.GetAllDefWorkFlows();
        }

    }
}
