using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FlowBLL
{
    public class Flow_WorkFlowManager
    {
        private static FlowIDAL.IFlow_WorkFlowService WorkFlowService = FlowDALFactory.Factory.CreateInterfaceService<FlowIDAL.IFlow_WorkFlowService>("Flow_WorkFlowService");
        public static bool InsertWorkFlow(FlowModels.Flow_WorkFlow model)
        {
            return WorkFlowService.InsertWorkFlow(model);
        }
        public static DataSet GetSubWorkFlowByModel(FlowModels.Flow_WorkFlow model)
        {
            return WorkFlowService.GetSubWorkFlowByModel(model);
        }
        public static bool ContinueAuditRecord(FlowModels.Flow_WorkAudit model, FlowModels.Flow_WorkStep step)
        {
            return WorkFlowService.ContinueAuditRecord(model, step);
        }
        public static DataTable GetWorkAuditRecord(FlowModels.Flow_WorkFlow model)
        {
            return WorkFlowService.GetWorkAuditRecord(model);
        }
        public static DataSet GetFlowPreData(string flowID, string defFlowID)
        {
            return WorkFlowService.GetFlowPreData(flowID, defFlowID);
        }
        public static bool DeleteFormFlow(string formID, string flowID)
        {
            return WorkFlowService.DeleteFormFlow(formID, flowID);
        }
        public static bool RefuseAuditRecord(FlowModels.Flow_WorkAudit model)
        {
            return WorkFlowService.RefuseAuditRecord(model);
        }
        public static bool RefuseRecordFinish(FlowModels.Flow_WorkAudit model, FlowModels.Flow_WorkStep step)
        {
            return WorkFlowService.RefuseRecordFinish(model, step);
        }
        public static DataTable GetBackSubmitStep(FlowModels.Flow_WorkStep step)
        {
            return WorkFlowService.GetBackSubmitStep(step);
        }
    }
}
