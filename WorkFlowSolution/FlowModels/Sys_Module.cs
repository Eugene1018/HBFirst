using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowModels
{
    [Serializable]
    public class Sys_Module
    {
        /// <summary>
        /// GUID
        /// </summary>
        public string FN_ID { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        public string FN_ParentID { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string FN_ModuleName { get; set; }

        /// <summary>
        /// 模块地址
        /// </summary>
        public string FN_ModuleUrl { get; set; }

        /// <summary>
        /// 模块排序
        /// </summary>
        public string FN_Order { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string FN_Remark { get; set; }

       
    }
}
