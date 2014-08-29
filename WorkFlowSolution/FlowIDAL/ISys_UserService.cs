using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowModels;

/****************************************************
 * Copyright (C) 北京都宜环球科技发展有限责任公司
 * 版权所有： 都宜环球-陈永敬
 * 文件功能描述：系统用户接口类
 * **************************************************/

namespace FlowIDAL
{
    public interface ISys_UserService
    {
        bool InsertUser(Sys_User model);
        bool DeleteUser(Sys_User model);
        bool UpdateUser(Sys_User model);
        bool CheckLogin(Sys_User model);
        List<Sys_User> GetAllUsers(params string[] sql);
        List<Sys_User> GetSubUserByModel(Sys_User model);

    }
}
