using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlowWeb.Flow
{
    public partial class FormAudit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["op"] != null && Request.QueryString["op"].ToString() == ((int)FlowModels.enAuditState.流程撤销).ToString())
            {
                string id = HttpUtility.UrlDecode(Request.QueryString["id"], System.Text.Encoding.GetEncoding("GB2312"));
                string formID = id.Split('|')[0];
                string flowID = id.Split('|')[1];
                if (FlowBLL.Flow_WorkFlowManager.DeleteFormFlow(formID, flowID))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "auditdel", "alert('流程撤销成功！');window.close();window.returnValue = 'ok';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "auditdel", "alert('流程撤销失败！');window.close();window.returnValue = 'error';", true);
                }
            }
        }

        protected void btnOperate_Click(object sender, ImageClickEventArgs e)
        {
            string id = Request.QueryString["id"].ToString();
            string FN_FlowID = id.Split('|')[0];
            string FN_DefFlowID = id.Split('|')[1];
            string FN_StepID = id.Split('|')[2];
            string FN_PreStepID=id.Split('|')[3];
            ImageButton btn = sender as ImageButton;
            if (btn.ID == "btnBack" && FN_PreStepID != "" && FN_PreStepID!=new Guid().ToString()) 
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "back", "workFlowDialog('Window_BackStep.aspx','" + HttpUtility.UrlEncode(id + "|" + this.Tb_HandleView.Text.Trim(), System.Text.Encoding.GetEncoding("GB2312")) + "',462,276)", true);
                return;
            }
            FlowModels.Flow_WorkAudit model = new FlowModels.Flow_WorkAudit()
            {
                FN_StepID = FN_StepID,
                FN_CheckerID = (Session["Sys_User"] as FlowModels.Sys_User).FN_ID,
                FN_CheckDate = DateTime.Now.ToString(),
                FN_HandleView = this.Tb_HandleView.Text.Trim(),
                FN_RevisionView = string.Empty,
                FN_BackNote=string.Empty
            };
            FlowModels.Flow_WorkStep step = new FlowModels.Flow_WorkStep()
            {
                FN_StepID = Guid.NewGuid().ToString(),
                FN_FlowID = FN_FlowID,
                FN_SendID = (Session["Sys_User"] as FlowModels.Sys_User).FN_ID,
                FN_SendDate = DateTime.Now.ToString()
            };
           
            bool result = (btn.ID == "btnBack")? FlowBLL.Flow_WorkFlowManager.RefuseAuditRecord(model) : FlowBLL.Flow_WorkFlowManager.ContinueAuditRecord(model, step);
            if (result)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "auditfinish", "alert('流程处理成功！');window.close();window.returnValue = 'ok';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "auditfinish", "alert('流程处理失败！');window.close();window.returnValue = '';", true);
            }

        }

    }
}