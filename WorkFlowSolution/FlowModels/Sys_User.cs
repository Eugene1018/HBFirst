using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/****************************************************
 * Copyright (C) 北京都宜环球科技发展有限责任公司
 * 版权所有： 都宜环球-陈永敬
 * 文件功能描述：用户信息实体类
 * **************************************************/

namespace FlowModels
{

    [Serializable]
    public class Sys_User
    {

        /// <summary>
        ///  GUID
        /// </summary>
        public string FN_ID { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public string FN_RoleID { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string FN_UserName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string FN_UserPwd { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string FN_RealName { get; set; }


        /// <summary>
        /// 电话
        /// </summary>
        public string FN_TelePhone { get; set; }

        /// <summary>
        /// Emial
        /// </summary>
        public string FN_Email { get; set; }

        /// <summary>
        /// 是否锁定
        /// </summary>
        public string FN_IsLock { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string FN_CreateDate { get; set; }

        /// <summary>
        /// 角色信息
        /// </summary>
        public Sys_Role Role { get; set; }
    }
}
