using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowModels;

/****************************************************
 * Copyright (C) 北京都宜环球科技发展有限责任公司
 * 版权所有： 都宜环球-陈永敬
 * 文件功能描述：动作接口类
 * **************************************************/

namespace FlowIDAL
{
   
    public interface IFlow_DefWorkActionService
    {
        bool InsertDefAction(Flow_DefWorkAction model);
        bool DeleteDefAction(Flow_DefWorkAction model);
        bool UpdateDefAction(Flow_DefWorkAction model);
        List<Flow_DefWorkAction> GetAllDefActions();
        List<Flow_DefWorkAction> GetSubDefActionByID(FlowModels.Flow_DefWorkAction model);
        bool CheckEndStep(string FlowID, String StepID);
    }
}
