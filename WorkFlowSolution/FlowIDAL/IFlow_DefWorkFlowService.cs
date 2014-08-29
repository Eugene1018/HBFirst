using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowModels;

/****************************************************
 * Copyright (C) 北京都宜环球科技发展有限责任公司
 * 版权所有： 都宜环球-陈永敬
 * 文件功能描述：流程接口类
 * **************************************************/

namespace FlowIDAL
{
    public interface IFlow_DefWorkFlowService
    {
        bool InsertDefWorkFlow(FlowModels.Flow_DefWorkFlow model);
        bool DeleteDefWorkFlow(Flow_DefWorkFlow model);
        bool UpdateDefWorkFlow(Flow_DefWorkFlow model);
        List<Flow_DefWorkFlow> GetAllDefWorkFlows();
        List<Flow_DefWorkFlow> GetSubDefWorkFlowByID(string FN_ID);
    }
}
