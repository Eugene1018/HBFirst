using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowModels;
using System.Data;

/****************************************************
 * Copyright (C) 北京都宜环球科技发展有限责任公司
 * 版权所有： 都宜环球-陈永敬
 * 文件功能描述：流程接口类
 * **************************************************/

namespace FlowIDAL
{
    public interface IFlow_WorkFlowService
    {
        bool InsertWorkFlow(FlowModels.Flow_WorkFlow model);
        DataSet GetSubWorkFlowByModel(FlowModels.Flow_WorkFlow model);
        bool ContinueAuditRecord(FlowModels.Flow_WorkAudit model, FlowModels.Flow_WorkStep step);
        DataTable GetWorkAuditRecord(FlowModels.Flow_WorkFlow model);
        DataSet GetFlowPreData(string flowID, string defFlowID);
        bool DeleteFormFlow(string formID, string flowID);
        bool RefuseAuditRecord(FlowModels.Flow_WorkAudit model);
        bool RefuseRecordFinish(FlowModels.Flow_WorkAudit model, FlowModels.Flow_WorkStep step);
        DataTable GetBackSubmitStep(FlowModels.Flow_WorkStep step);
    }
}