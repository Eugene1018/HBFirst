using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlowWeb.SysManage
{
    public partial class RoleList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected string InitData()
        {
            List<FlowModels.Sys_Role> list_Roles = FlowBLL.Sys_RoleManager.GetSubRoleByModel(null);
            string htmldata = string.Empty;
            int i = 1;
            foreach (FlowModels.Sys_Role model in list_Roles)
            {
                #region 动态生成td
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
                                            <span class='STYLE1'>" + model.FN_RoleName + @"</span></div>
                                    </td>
                                    <td height='20' bgcolor='#FFFFFF'>
                                        <div align='center'>
                                            <span class='STYLE1'>" + model.FN_Remark + @" </span>
                                        </div>
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