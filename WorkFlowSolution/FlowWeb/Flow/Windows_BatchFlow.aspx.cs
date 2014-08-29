using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace FlowWeb.Flow
{
    public partial class Windows_BatchFlow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                InitAllFlows();
            }
        }
        private void InitAllFlows()
        {
            if (this.tv_flow.Nodes.Count > 0)
            {
                this.tv_flow.Nodes.Clear();
            }
            List<FlowModels.Flow_DefWorkFlow> list_flows = FlowBLL.Flow_DefWorkFlowManager.GetAllDefWorkFlows();
            TreeNode nodeRoot = new TreeNode() { Text = "流程管理", Value = "0", ImageUrl = "~/Flow/inc/dtree/img/flow.gif" };
            TreeNode nodeChild;
            foreach (var item in list_flows)
            {
                nodeChild = new TreeNode() { Text = item.FN_FlowName, Value = item.FN_FlowID, ToolTip = item.FN_FlowName, ImageUrl = "~/Flow/inc/dtree/img/obj2.gif" };
                nodeRoot.ChildNodes.Add(nodeChild);
            }
            this.tv_flow.Nodes.Add(nodeRoot);
            this.tv_flow.ExpandAll();
            this.tv_flow.Nodes[0].ChildNodes[0].Selected = true;
            tv_flow_SelectedNodeChanged(this.tv_flow, null);
        }

        protected void btnOK_Click(object sender, ImageClickEventArgs e)
        {
            string FlowID = Tb_FlowNameValue.Value;
            string PeopleID = Request.Form["Tb_FlowPeopleValue"].ToString();
            string Type = Rbl_Type.SelectedValue;
            FlowModels.Flow_WorkFlow model = new FlowModels.Flow_WorkFlow();
            model.FN_FlowID = Guid.NewGuid().ToString();
            model.FN_DefFlowID = FlowID;
            model.FN_FlowState = FlowModels.enAuditState.审批中;
            model.FN_CreateDate = DateTime.Now.ToString();
            model.FN_CreateType = Rbl_Type.SelectedItem.Value;
            string[] paramIds = HttpUtility.UrlDecode(Request.QueryString["id"].ToString(), System.Text.Encoding.GetEncoding("GB2312")).TrimEnd('$').Split('$');
            foreach (string formid in paramIds)
            {
                model.List_Forms.Add(formid.Split('|')[0]); 
            }
           
            model.List_WorkSteps.Add(new FlowModels.Flow_WorkStep()
            {
                FN_StepID = Guid.NewGuid().ToString(),
                FN_SendID = (Session["Sys_User"] as FlowModels.Sys_User).FN_ID,
                FN_SendDate = DateTime.Now.ToString(),
                FN_Index = "0",
                FN_PreStepID = "NULL",
                FN_FlowID = model.FN_FlowID,
                FN_DefStepID = "(Select FN_StepID from dbo.Flow_DefWorkStep where fn_defflowid='" + FlowID + "' and FN_Index=1)",
                FN_DefActionID = "'" + new Guid().ToString() + "'",
                FN_IsCurrent="0"
            });
            model.List_WorkSteps.Add(new FlowModels.Flow_WorkStep()
            {
                FN_StepID = Guid.NewGuid().ToString(),
                FN_SendID = (Session["Sys_User"] as FlowModels.Sys_User).FN_ID,
                FN_SendDate = DateTime.Now.ToString(),
                FN_Index = "1",
                FN_PreStepID = "'" + new Guid().ToString() + "'",
                FN_FlowID = model.FN_FlowID,
                FN_DefStepID = "'" + this.Lb_StepValue.Value + "'",
                FN_DefActionID = "(Select FN_ActionID from dbo.Flow_DefWorkAction where  FN_DefStepID=(select FN_StepID from dbo.Flow_DefWorkStep  where FN_DefFlowID='" + FlowID + "' and FN_StepType='BeginStep'))",
                FN_IsCurrent = "1"
            });
            model.List_WorkUsers.Add(new FlowModels.Flow_WorkUser()
            {
                FN_StepID = model.List_WorkSteps[0].FN_StepID,
                FN_UserID = (Session["Sys_User"] as FlowModels.Sys_User).FN_ID,
                FN_Note = "",
                FN_Action = "'" + new Guid().ToString() + "'",
                FN_Pass = "NULL"
            });

            foreach (string p in PeopleID.Split(','))
            {
                model.List_WorkUsers.Add(new FlowModels.Flow_WorkUser()
               {
                   FN_StepID = model.List_WorkSteps[1].FN_StepID,
                   FN_UserID = p,
                   FN_Note = "",
                   FN_Action = "(Select FN_ActionID from dbo.Flow_DefWorkAction where  FN_DefStepID=(select FN_StepID from dbo.Flow_DefWorkStep  where FN_DefFlowID='" + FlowID + "' and FN_StepType='BeginStep'))",
                   FN_Pass = "NULL"
               });
            }
            bool result = FlowBLL.Flow_WorkFlowManager.InsertWorkFlow(model);
            if (result)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "audit", "alert('流程发起成功！');window.close();window.returnValue = 'ok';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "audit", "alert('流程发起失败，请稍后再试！');window.close();window.returnValue = 'no';", true);
            }
        }

        protected void btnPreview_Click(object s, ImageClickEventArgs e)
        {
            if (string.IsNullOrEmpty(Tb_FlowName.Text))
            {
                Tb_FlowName.Text = "请先选择流程！";

            }
            else if (Tb_FlowName.Text != "请先选择流程！")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "preview", "preFlowDialog('FlowPreview.aspx','" + Tb_FlowNameValue.Value + "',926,540)", true);
            }
        }

        protected void btnSelect_Click(object s, ImageClickEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "workflow", "selectUserDialog('Window_Users.aspx','',470,480)", true);
        }

        protected void tv_flow_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeNode node = tv_flow.SelectedNode;
            if (node.Value == "0") return;
            Tb_FlowName.Text = node.Text;
            Tb_FlowNameValue.Value = node.Value;

            DataSet ds = FlowBLL.Flow_DefWorkStepManager.GetSubDefWorkStepInfo(node.Value, "", true);
            Lb_Step.Text = ds.Tables["dt_step"].Rows[0]["FN_StepName"].ToString();
            Lb_StepValue.Value = ds.Tables["dt_step"].Rows[0]["FN_StepID"].ToString();
            Tb_FlowPeople.Text = Tb_FlowPeopleValue.Value = string.Empty;
            if (ds.Tables.Count > 1)
            {
                DataTable dt_role = ds.Tables["dt_role"];
                string roleText = string.Empty;
                string roleValue = string.Empty;
                foreach (DataRow item in dt_role.Rows)
                {
                    roleText += item["FN_RealName"].ToString() + ",";
                    roleValue += item["FN_ID"].ToString() + ",";
                }
                Tb_FlowPeople.Text = roleText.TrimEnd(',');
                Tb_FlowPeopleValue.Value = roleValue.TrimEnd(',');
            }
        }

    }
}