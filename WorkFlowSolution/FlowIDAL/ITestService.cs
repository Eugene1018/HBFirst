using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

/****************************************************
 * Copyright (C) 北京都宜环球科技发展有限责任公司
 * 版权所有： 都宜环球-陈永敬
 * 文件功能描述：流程测试接口类
 * **************************************************/
namespace FlowIDAL
{
   public interface ITestService
    {
        DataTable GetTestData();
    }
}
