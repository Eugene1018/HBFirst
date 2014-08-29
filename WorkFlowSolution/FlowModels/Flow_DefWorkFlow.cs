using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/****************************************************
 * Copyright (C) 北京都宜环球科技发展有限责任公司
 * 版权所有： 都宜环球-陈永敬
 * 文件功能描述：流程信息实体类
 * **************************************************/

namespace FlowModels
{
    [Serializable]
    public class Flow_DefWorkFlow
    {
        /// <summary>
        /// GUID
        /// </summary>
        public string FN_FlowID { get; set; }

        /// <summary>
        /// 流程名称
        /// </summary>
        public string FN_FlowName { get; set; }

        /// <summary>
        /// 流程分类
        /// </summary>
        public string FN_FlowType { get; set; }

        /// <summary>
        /// 流程Xml
        /// </summary>
        public string FN_FlowXml { get; set; }


        /// <summary>
        /// 启动条件
        /// </summary>
        public string FN_Conditions { get; set; }

        /// <summary>
        /// 流程新建时间
        /// </summary>
        public string FN_CreateData { get; set; }

        private List<Flow_DefWorkStep> list_DefWorkSteps;
        public  List<Flow_DefWorkStep> List_DefWorkSteps
        {
            get
            {
                if (list_DefWorkSteps == null)
                {
                    list_DefWorkSteps = new List<Flow_DefWorkStep>();
                }
                return this.list_DefWorkSteps;
            }
            set
            {
                list_DefWorkSteps = value;
            }
        }

        private List<Flow_DefWorkAction> list_DefWorkActions;
        public  List<Flow_DefWorkAction> List_DefWorkActions
        {
            get
            {
                if (list_DefWorkActions == null)
                {
                    list_DefWorkActions = new List<Flow_DefWorkAction>();
                }
                return list_DefWorkActions;
            }
            set
            {
                list_DefWorkActions = value;
            }
        }

    }
}
