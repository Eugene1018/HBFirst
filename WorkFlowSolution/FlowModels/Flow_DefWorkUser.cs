using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/****************************************************
 * Copyright (C) 北京都宜环球科技发展有限责任公司
 * 版权所有： 都宜环球-陈永敬
 * 文件功能描述：动作实体类
 * **************************************************/

namespace FlowModels
{
    [Serializable]
    public class Flow_DefWorkUser
    {
        /// <summary>
        /// GUID
        /// </summary>
        public string FN_ID { get; set; }

        /// <summary>
        /// 步骤ID
        /// </summary>
        public string FN_StepID { get; set; }

        /// <summary>
        /// 步骤参与人员ID
        /// </summary>
        public string FN_UserID { get; set; }
    }
}
