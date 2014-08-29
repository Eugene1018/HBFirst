using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/****************************************************
 * Copyright (C) 北京都宜环球科技发展有限责任公司
 * 版权所有： 都宜环球-陈永敬
 * 文件功能描述：步骤信息实体类
 * **************************************************/

namespace FlowModels
{
    public class Flow_DefWorkStep
    {
        /// <summary>
        ///  GUID
        /// </summary>
        public string FN_StepID { get; set; }

        /// <summary>
        /// 流程ID
        /// </summary>
        public string FN_DefFlowID { get; set; }


        /// <summary>
        /// 步骤名称
        /// </summary>
        public string FN_StepName { get; set; }

        /// <summary>
        /// 步骤类型 （开始步骤、中间步骤、结束步骤）
        /// </summary>
        public string FN_StepType { get; set; }


        /// <summary>
        /// 参与角色（可以是关键字 如：项目经理，可以是Sql语句）
        /// </summary>
        public string FN_StepRole { get; set; }


        /// <summary>
        /// 多人同时审批通过
        /// </summary>
        public string FN_UnionPass { get; set; }

        /// <summary>
        /// 节点排序
        /// </summary>
        public string FN_Index { get; set; }


    }
}
