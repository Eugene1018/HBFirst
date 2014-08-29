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
    public class Flow_DefWorkAction
    {
        /// <summary>
        /// 动作ID
        /// </summary>
        public string FN_ActionID { get; set; }

        /// <summary>
        /// 动作名称
        /// </summary>
        public string FN_ActionName { get; set; }

        /// <summary>
        /// 步骤ID
        /// </summary>
        public string FN_DefStepID { get; set; }

        /// <summary>
        /// 下一步骤ID
        /// </summary>
        public string FN_NextDefStepID { get; set; }

        /// <summary>
        /// 默认意见
        /// </summary>
        public string FN_DefaultOpinion { get; set; }

        /// <summary>
        /// 插件
        /// </summary>
        public string FN_DefaultPlugins { get; set; }
    }
}
