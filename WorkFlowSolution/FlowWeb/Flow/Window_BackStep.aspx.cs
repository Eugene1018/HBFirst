using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlowWeb.Flow
{
    public partial class Window_BackStep : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                InitBackStep();
            }
        }

        private void InitBackStep()
        {
            string id =HttpUtility.UrlDecode(Request.QueryString["id"].ToString(),System.Text.Encoding.GetEncoding("GB2312"));
            string FN_StepID = id.Split('|')[2];
            NextStepList.DataSource = FlowBLL.Flow_WorkFlowManager.GetBackSubmitStep(new FlowModels.Flow_WorkStep() { FN_StepID = FN_StepID }); ;
            NextStepList.DataTextField = "FN_StepName";
            NextStepList.DataValueField = "FN_StepID";
            NextStepList.DataBind();
        }

        protected void btnOK_Click(object sender, ImageClickEventArgs e)
        {

            string id = HttpUtility.UrlDecode(Request.QueryString["id"].ToString(), System.Text.Encoding.GetEncoding("GB2312"));
            string FN_FlowID = id.Split('|')[0];
            string FN_StepID = id.Split('|')[2];
            string FN_HandleView = id.Split('|')[4];

            FlowModels.Flow_WorkAudit model = new FlowModels.Flow_WorkAudit()
            {
                FN_StepID = FN_StepID,
                FN_CheckerID = (Session["Sys_User"] as FlowModels.Sys_User).FN_ID,
                FN_CheckDate = DateTime.Now.ToString(),
                FN_HandleView = FN_HandleView,
                FN_RevisionView = string.Empty,
                FN_BackNote = NextStepSelectedList.Items[0].Value
            };
            FlowModels.Flow_WorkStep step = new FlowModels.Flow_WorkStep()
            {
                FN_StepID = Guid.NewGuid().ToString(),
                FN_FlowID = FN_FlowID,
                FN_SendID = (Session["Sys_User"] as FlowModels.Sys_User).FN_ID,
                FN_SendDate = DateTime.Now.ToString()
            };

            bool result = FlowBLL.Flow_WorkFlowManager.RefuseAuditRecord(model);
            if (result)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "auditfinish", "alert('流程处理成功！');window.close();window.returnValue = 'ok';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "auditfinish", "alert('流程处理失败！');window.close();window.returnValue = '';", true);
            }
        }

        protected void btnNextStepList_Click(object sender, ImageClickEventArgs e)
        {
            DoStepSelect(NextStepList, NextStepSelectedList);
        }

        protected void btnNextStepSelectedList_Click(object sender, ImageClickEventArgs e)
        {
            DoStepSelect(NextStepSelectedList, NextStepList);
        }
       
        private void DoStepSelect(ListBox listOne, ListBox listTwo)
        {
            if (listOne.SelectedIndex < 0) return;
            ListItem item = listOne.SelectedItem;
            item.Selected = false;
            if (listTwo.Items.Count > 0)
            {
                listOne.Items.Add(listTwo.Items[0]);
                listTwo.Items.Clear();
            }
            listTwo.Items.Add(item);
            listOne.Items.Remove(item);
            
        }
    }
}