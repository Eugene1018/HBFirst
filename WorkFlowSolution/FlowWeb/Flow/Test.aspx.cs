using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace FlowWeb.Flow
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                InitData();
            }
        }
        protected void InitData()
        {
            string id = HttpUtility.UrlDecode(Request.QueryString["id"], System.Text.Encoding.GetEncoding("GB2312"));
            string FN_ID = id.Split('|')[0];
            string FN_FlowID = id.Split('|')[1];
            string FN_DefFlowID = id.Split('|')[2];
            string FN_DefFlowName = id.Split('|')[3];
            string FN_FlowState = id.Split('|')[4];
            hddata.Value = FN_FlowID + "|" + FN_DefFlowID;

            DataSet ds = FlowBLL.Flow_WorkFlowManager.GetSubWorkFlowByModel(new FlowModels.Flow_WorkFlow() { FN_FlowID = FN_FlowID });
            DataTable dt_step = ds.Tables[0];
            DataTable dt_role = ds.Tables[1];
            AddStepAndRole(dt_step, dt_role, FN_DefFlowID, FN_DefFlowName, FN_FlowState);

        }

        protected string InitHtmlData()
        {
            string id = HttpUtility.UrlDecode(Request.QueryString["id"], System.Text.Encoding.GetEncoding("GB2312"));
            string htmldata = string.Empty;
            DataTable table = FlowBLL.Flow_WorkFlowManager.GetWorkAuditRecord(new FlowModels.Flow_WorkFlow() { FN_FlowID=id.Split('|')[1] });
            int heightRow=0;
            foreach (DataRow item in table.Rows)
            {
                heightRow++;
                #region 动态生成td
                htmldata += @"<tr>
                                    <td height='20' bgcolor='#FFFFFF'>
                                        <div align='center'>
                                            <span class='STYLE1'>" + item["FN_CheckName"].ToString() + @"</span></div>
                                    </td>
                                    <td height='20' bgcolor='#FFFFFF'>
                                        <div align='center'>
                                            <span class='STYLE1'>" + FlowCommon.StringPlus.GetStrDate(item["FN_CheckDate"].ToString()) + @"</span></div>
                                    </td>
                                    <td height='20' bgcolor='#FFFFFF'>
                                        <div align='center'>
                                            <span class='STYLE1'title='" + item["FN_HandleView"].ToString() + "'>" + FlowCommon.StringPlus.CutString(item["FN_HandleView"].ToString(), 10) + @"</span></div>
                                    </td>
                                    <td height='20' bgcolor='#FFFFFF'>
                                        <div align='center'>
                                            <span class='STYLE1'title='" + item["FN_RevisionView"].ToString() + "'>" + FlowCommon.StringPlus.CutString(item["FN_RevisionView"].ToString(), 10) + @"</span></div>
                                    </td>
                                    <td height='20' bgcolor='#FFFFFF'>
                                        <div align='center'>
                                            <span class='STYLE1'title='" + item["FN_StepName"].ToString() + "'>" + FlowCommon.StringPlus.CutString(item["FN_StepName"].ToString(), 10) + @"</span></div>
                                    </td>
                                </tr>";
                #endregion
            }
            td_height.Height =(310- (heightRow * 21)).ToString();
            return htmldata;
        }

        private void AddStepAndRole(DataTable dt_step, DataTable dt_role, string FN_DefFlowID, string FN_DefFlowName, string FN_FlowState)
        {
            string stepRole = string.Empty;
            if (FN_FlowState != "" &&  FN_FlowState =="2")
            {
                FN_FlowState = "[" + ((FlowModels.enAuditState)int.Parse(FN_FlowState)).ToString() + "]";
            }
            else
            {
                FN_FlowState = "";
            }
            TreeNode nodeRoot = new TreeNode()
            {
                Text = FN_DefFlowName + FN_FlowState,
                Value = FN_DefFlowID,
                ImageUrl = "~/Flow/inc/dtree/img/flow.gif"
            };
            for (int i = 0; i < dt_step.Rows.Count; i++)
            {
                if (i != 0)
                {
                    stepRole += "&nbsp;&nbsp;&nbsp;";
                }
                if (dt_step.Rows[i]["FN_IsCurrent"].ToString() == "1")
                {
                    hddata.Value += "|" + dt_step.Rows[i]["FN_StepID"].ToString() + "|" + dt_step.Rows[i]["FN_PreStepID"].ToString();
                }
               
                stepRole += (i + 1) + "&nbsp;&nbsp;&nbsp;" + dt_step.Rows[i]["FN_StepName"].ToString();
                TreeNode nodeStep = new TreeNode()
                {
                    Text = dt_step.Rows[i]["FN_IsCurrent"].ToString()=="1" ? dt_step.Rows[i]["FN_StepName"].ToString() + " [←当前状态]": dt_step.Rows[i]["FN_StepName"].ToString(),
                    Value = dt_step.Rows[i]["FN_StepID"].ToString(),
                    ToolTip = dt_step.Rows[i]["FN_StepName"].ToString(),
                    ImageUrl = "~/Flow/inc/dtree/img/obj2.gif"
                };
                DataRow[] drs = dt_role.Select("FN_StepID='" + dt_step.Rows[i]["FN_StepID"].ToString() + "'");
                string role = string.Empty;
                foreach (DataRow item in drs)
                {
                    role += item["FN_RealName"].ToString() + ",";
                    TreeNode nodeRole = new TreeNode()
                    {
                        Text = item["FN_RealName"].ToString() + ReturnState(item["FN_Pass"].ToString()),
                        Value = item["FN_UserID"].ToString(),
                        ToolTip = item["FN_RealName"].ToString(),
                        ImageUrl = "~/Flow/inc/dtree/img/obj4.gif"
                    };
                    nodeStep.ChildNodes.Add(nodeRole);
                    if (dt_step.Rows[i]["FN_IsCurrent"].ToString() == "1" && nodeRole.Value == (Session["Sys_User"] as FlowModels.Sys_User).FN_ID)
                    {
                        if (dt_step.Rows[i]["FN_PreStepID"].ToString() == "")
                        {
                            this.td_not.Style.Add(HtmlTextWriterStyle.Display, "block");
                        }
                        else
                        {
                           
                            this.td_ok.Style.Add(HtmlTextWriterStyle.Display, "block");
                        }
                    }
                   
                }
               
                nodeRoot.ChildNodes.Add(nodeStep);
                stepRole += ":" + role.TrimEnd(',');
            }
            Lb_Role.Text = stepRole;
            this.tv_flow.Nodes.Add(nodeRoot);
            this.tv_flow.ExpandAll();
        }
       
        protected void tv_flow_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeNode node = tv_flow.SelectedNode;
        }

        private string ReturnState(string fn_pass)
        {
            string result = string.Empty;
            switch (fn_pass)
            {
                case "1": result = "[审批通过]"; break;
                case "3": result = "[退回修改]"; break;
                case "4": result = "[修改完成]"; break;
            }
            return result;
        }
    }
}