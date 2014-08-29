using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace FlowWeb.Flow
{
    public partial class FlowTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string InitData()
        {
            DataTable table = FlowBLL.TestManager.GetTestData();
            string htmldata = string.Empty;
            foreach (DataRow item in table.Rows)
            {
                #region 动态生成td
                string flowState = item["FN_FlowState"].ToString() == "" ? "" : "[" + ((FlowModels.enAuditState)int.Parse(item["FN_FlowState"].ToString())).ToString() + "]";
                string paramID = HttpUtility.UrlEncode(item["FN_ID"].ToString() + "|" + item["FN_FlowID"].ToString() + "|" + item["FN_DefFlowID"].ToString() + "|" + item["FN_DefFlowName"].ToString() + "|" + item["FN_FlowState"].ToString(), System.Text.Encoding.GetEncoding("GB2312"));
                htmldata += @"<tr>
                                   
                                    <td height='20' bgcolor='#FFFFFF'><div align='center'>
                                                  <input type='checkbox' id='checkboxid' onclick='checkclick()'  value='" + paramID + @"' />
                                                </div>
                                    </td>
                                    <td height='20' bgcolor='#FFFFFF'>
                                        <div align='center' class='STYLE1'>
                                            <div align='center'>
                                                " + item["序号"].ToString() + @"</div>
                                        </div>
                                    </td>
                                    <td height='20' bgcolor='#FFFFFF'>
                                        <div align='center'>
                                            <span class='STYLE1'>" + item["FN_Telphone"].ToString() + @"</span></div>
                                    </td>
                                    <td height='20' bgcolor='#FFFFFF'>
                                        <div align='center'>
                                            <span class='STYLE1'>" + FlowCommon.StringPlus.GetStrDate(item["FN_SendTime"].ToString()) + @" </span>
                                        </div>
                                    </td>
                                    <td bgcolor='#FFFFFF'>
                                        <div align='center'>
                                            <span class='STYLE1'>" + item["FN_Email"].ToString() + @"</span></div>
                                    </td>
                                    <td height='20' bgcolor='#FFFFFF'>
                                        <div align='center'>
                                            <span class='STYLE1' title='" + item["FN_Content"].ToString() + "' >" + FlowCommon.StringPlus.CutString(item["FN_Content"].ToString(),35) + @"</span></div>
                                    </td>
                                    <td height='20' bgcolor='#FFFFFF'>
                                        <div align='center'>
                                           <span class='STYLE1' style='color:green' title='" + item["FN_DefFlowName"].ToString() + "' >" + FlowCommon.StringPlus.CutString(item["FN_DefFlowName"].ToString(), 35) + flowState + @"</span></div>
                                        </div>
                                    </td>
                                      <%--<td height='20' bgcolor='#FFFFFF'>
                                            <div align='center'>
                                              <span class='STYLE4'>
                                                <img src='images/edt.gif' width='16' height='16'  style='cursor: hand' />编辑&nbsp; &nbsp; <img src='images/tick.png' width='16' height='16' style='cursor: hand' onclick='workFlowDialog(12)' />
                                                <span class='STYLE1' onclick='workFlowDialog(12)' style='cursor:hand'>发起流程</span>
                                            </div>
                                        </td>--%>
                                </tr>";
                   //<span class='STYLE1' style='color:" + ReturnColor(int.Parse(item["FN_AuditState"].ToString())) + "'>" + ((FlowModels.enAuditState)int.Parse(item["FN_AuditState"].ToString())).ToString() + @"</span>
                #endregion
            }
            return htmldata;
        }

        private string ReturnColor(int AuditState)
        {
            string result = string.Empty;
            switch (AuditState)
            {
                case 0: result= "Black"; break;
                case 1: result = "Blue"; break;
                case 2: result = "Green"; break;
                case 3: result = "Red"; break;
                case 4: result = "lime"; break;
            }
            return result;
        }
    }
}