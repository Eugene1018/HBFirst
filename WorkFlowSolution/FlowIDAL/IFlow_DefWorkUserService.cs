using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowModels;

/****************************************************
 * Copyright (C) 北京都宜环球科技发展有限责任公司
 * 版权所有： 都宜环球-陈永敬
 * 文件功能描述：流程用户接口类
 * **************************************************/


namespace FlowIDAL
{
    public interface IFlow_DefWorkUserService
    {
        bool InsertDefWorkUser(Flow_DefWorkUser model);
        bool DeleteDefWorkUser(Flow_DefWorkUser model);
        bool UpdateDefWorkUser(Flow_DefWorkUser model);
        List<Flow_DefWorkUser> GetAllDefWorkUsers();
        List<Flow_DefWorkUser> GetDefWorkUserByStepID(string FN_StepID);
    }
}
