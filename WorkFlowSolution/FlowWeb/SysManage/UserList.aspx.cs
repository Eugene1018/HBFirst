using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlowWeb.SysManage
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected string InitData()
        {
            List<FlowModels.Sys_User> list_Users = FlowBLL.Sys_UserManager.GetAllUsers();
            string htmldata = string.Empty;
            int i = 1;
            foreach (FlowModels.Sys_User model in list_Users)
            {
                #region 动态生成td
                string IsLock = model.FN_IsLock== "1" ? "<font color='red'>是</font>" : "否";
                htmldata += @"<tr>
                                   
                                   <td height='20' bgcolor='#FFFFFF' style='display:none'><div align='center'>
                                                  <%-- <input type='checkbox' id='checkboxid'  value='" + model.FN_ID + @"' />--%>
                                                    <input type='hidden' id='hddata' value='" + model.FN_ID + @"' />
                                                </div>
                                    </td> 
                                    <td height='20' bgcolor='#FFFFFF'>
                                        <div align='center' class='STYLE1'>
                                            <div align='center'>
                                                " + (i++) + @"</div>
                                        </div>
                                    </td>
                                    <td height='20' bgcolor='#FFFFFF'>
                                        <div align='center'>
                                            <span class='STYLE1'>" + model.FN_UserName + @"</span></div>
                                    </td>
                                    <td height='20' bgcolor='#FFFFFF'>
                                        <div align='center'>
                                            <span class='STYLE1'>" + model.FN_RealName + @" </span>
                                        </div>
                                    </td>
                                    <td height='20' bgcolor='#FFFFFF'>
                                        <div align='center'>
                                            <span class='STYLE1'>" + model.Role.FN_RoleName + @" </span>
                                        </div>
                                    </td>
                                    <td bgcolor='#FFFFFF'>
                                        <div align='center'>
                                            <span class='STYLE1'>" + model.FN_Email + @"</span></div>
                                    </td>
                                    <td height='20' bgcolor='#FFFFFF'>
                                        <div align='center'>
                                            <span class='STYLE1'>" + model.FN_TelePhone + @"</span></div>
                                    </td>
                                     <td height='20' bgcolor='#FFFFFF'>
                                        <div align='center'>
                                         <span class='STYLE1'>" + IsLock + @"</span></div>
                                     </td>
                                     <td height='20' bgcolor='#FFFFFF'>
                                        <div align='center'>
                                         <span class='STYLE1'>" + FlowCommon.StringPlus.GetStrDate(model.FN_CreateDate) + @"</span></div>
                                     </td>
                                    <td height='20' bgcolor='#FFFFFF'>
                                        <div align='center'>
                                            <span class='STYLE4'>
                                                <img src='../Flow/images/edt.gif' width='16' height='16'  onclick='workFlowDialog(1)' style='cursor: hand' /> <span class='STYLE1' onclick='workFlowDialog(1)' style='cursor:hand'>编辑</span>&nbsp;
                                                &nbsp; <img src='../Flow/images/del.gif' width='16' height='16' onclick='workFlowDialog(2)' style='cursor: hand' />
                                                <span class='STYLE1'  onclick='workFlowDialog(2)' style='cursor:hand'>删除</span></div>
                                    </td>
                                </tr>";
                #endregion
            }
            return htmldata;
        }
    }
}