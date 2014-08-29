using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlowWeb.SysManage
{
    public partial class ModuleList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
            {
                InitData();
            }
        }

        private void InitData()
        {
            List<FlowModels.Sys_Module> list_Modules = FlowBLL.Sys_ModuleManager.GetSubModuleByModel(null);
            TreeNode nodeParent = null;
            TreeNode nodeChild = null;
            foreach (FlowModels.Sys_Module parent in list_Modules.FindAll(m => m.FN_ParentID ==new Guid().ToString()))
            {
                nodeParent = new TreeNode();
                nodeParent.Text = parent.FN_ModuleName;
                nodeParent.Value = parent.FN_ID;
                nodeParent.ImageUrl = "../Flow/inc/dtree/img/flow.gif";
                List<FlowModels.Sys_Module> list_Child = list_Modules.FindAll(m => m.FN_ParentID == parent.FN_ID);
                if (list_Child.Count > 0)
                {
                    foreach (FlowModels.Sys_Module child in list_Child)
                    {
                        nodeChild = new TreeNode();
                        nodeChild.Text = child.FN_ModuleName + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + child.FN_ModuleUrl;
                        nodeChild.Value = child.FN_ID;
                        nodeChild.ImageUrl = "../Flow/inc/dtree/img/obj2.gif";
                        nodeParent.ChildNodes.Add(nodeChild);
                    }
                }
                tv_menu.Nodes.Add(nodeParent);
            }
            tv_menu.ExpandAll();
        }
    }
}