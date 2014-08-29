using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlowWeb.Flow
{
    public partial class FlowStart : System.Web.UI.Page
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
            TreeNode nodeRoot = new TreeNode() { Text = "流程定义", Value = "0", ImageUrl = "~/Flow/inc/dtree/img/flow.gif"};
            TreeNode nodeChild;
            foreach (var item in list_flows)
            {
                nodeChild = new TreeNode() { Text = item.FN_FlowName, Value = item.FN_FlowXml, ToolTip = item.FN_FlowName, ImageUrl = "~/Flow/inc/dtree/img/obj2.gif"};
                nodeRoot.ChildNodes.Add(nodeChild);
            }
            this.tv_flow.Nodes.Add(nodeRoot);
            this.tv_flow.ExpandAll();
        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            string xml = Request.Form["FlowXML"].Trim();
            if (FlowBLL.Flow_DefWorkFlowManager.InsertDefWorkFlow(xml, FlowBLL.enXmlOpState.Create))
            {
                InitAllFlows();
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "insert", "<script>alert('流程保存成功！');</script>");
            }

        }

        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            string xml = Request.Form["FlowXML"].Trim();
            if (FlowBLL.Flow_DefWorkFlowManager.DeleteDefWorkFlow(xml, FlowBLL.enXmlOpState.Delete))
            {
                InitAllFlows();
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "delete", "<script>alert('流程删除成功！');</script>");
            }
        }

        protected void tv_flow_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeNode selNode = this.tv_flow.SelectedNode;
            if (selNode != null && selNode.Value != "0")
            {
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "loadxml", "document.getElementById('FlowXML').value='" + selNode.Value + "'", true);
                this.tv_flow.SelectedNode.Selected = false;
            }
        }
    }
}