using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowModels;
using System.Data;

/****************************************************
 * Copyright (C) 北京都宜环球科技发展有限责任公司
 * 版权所有： 都宜环球-陈永敬
 * 文件功能描述：步骤接口类
 * **************************************************/

namespace FlowIDAL
{
    public interface IFlow_DefWorkStepService
    {
        bool InsertDefWorkStep(Flow_DefWorkStep model);
        bool DeleteDefWorkStep(Flow_DefWorkStep model);
        bool UpdateDefWorkStep(Flow_DefWorkStep model);
        List<Flow_DefWorkStep> GetAllDefWorkSteps();
        List<Flow_DefWorkStep> GetSubDefWorkStepByFlowID(string FlowID);
        DataSet GetSubDefWorkStepInfo(string FN_FlowID, string FN_StepID, bool IsBegin);
    }
}
