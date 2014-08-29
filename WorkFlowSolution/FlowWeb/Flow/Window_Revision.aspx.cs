using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlowWeb.Flow
{
    public partial class Window_Revision : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            string id = Request.QueryString["id"].ToString();
            string FN_FlowID = id.Split('|')[0];
            string FN_DefFlowID = id.Split('|')[1];
            string FN_StepID = id.Split('|')[2];

            FlowModels.Flow_WorkAudit model = new FlowModels.Flow_WorkAudit()
            {
                FN_StepID = FN_StepID,
                FN_RevisionView = Tb_RevisionView.Text
            };
            FlowModels.Flow_WorkStep step = new FlowModels.Flow_WorkStep()
            {
                FN_FlowID = FN_FlowID,
            };
            if (FlowBLL.Flow_WorkFlowManager.RefuseRecordFinish(model,step))
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