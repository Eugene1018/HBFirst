using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlowWeb.SysManage
{
    public partial class Window_Role : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
            {
                if (Request.QueryString["op"] == "0")
                {
                    AddData();
                }
                else if (Request.QueryString["op"] == "1")
                {
                    InitData();
                }
                else if (Request.QueryString["op"] == "2")
                {
                    if (FlowBLL.Sys_RoleManager.DeleteRole(new FlowModels.Sys_Role() { FN_ID = Request.QueryString["id"] }))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "roledel", "alert('角色信息处理成功！');window.close();window.returnValue = 'ok';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "roledel", "alert('角色信息处理失败！');window.close();window.returnValue = 'error';", true);
                    }
                }
            }
        }

        private void AddData()
        {
            List<FlowModels.Sys_Module> list_Modules = FlowBLL.Sys_ModuleManager.GetSubModuleByModel(null);
            TreeNode nodeParent = null;
            TreeNode nodeChild = null;
            foreach (FlowModels.Sys_Module parent in list_Modules.FindAll(m => m.FN_ParentID == new Guid().ToString()))
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
                        nodeChild.Text = child.FN_ModuleName;
                        nodeChild.Value = child.FN_ID;
                        nodeChild.ImageUrl = "../Flow/inc/dtree/img/obj2.gif";
                        nodeParent.ChildNodes.Add(nodeChild);
                    }
                }
                tv_menu.Nodes.Add(nodeParent);
            }
        }
        private void InitData()
        {
            FlowModels.Sys_RoleModule RoleModule = FlowBLL.Sys_RoleManager.GetSubRoleModuleByModel(new FlowModels.Sys_Role() { FN_ID = Request.QueryString["id"] });
            this.Tb_RoelName.Text = RoleModule.List_Roles[0].FN_RoleName;
            this.Tb_Remark.Text = RoleModule.List_Roles[0].FN_Remark;

            List<FlowModels.Sys_Module> list_Modules = FlowBLL.Sys_ModuleManager.GetSubModuleByModel(null);
            TreeNode nodeParent = null;
            TreeNode nodeChild = null;
            foreach (FlowModels.Sys_Module parent in list_Modules.FindAll(m => m.FN_ParentID == new Guid().ToString()))
            {
                nodeParent = new TreeNode();
                nodeParent.Text = parent.FN_ModuleName;
                nodeParent.Value = parent.FN_ID;
                nodeParent.ImageUrl = "../Flow/inc/dtree/img/flow.gif";
                nodeParent.ShowCheckBox = false;
                List<FlowModels.Sys_Module> list_Child = list_Modules.FindAll(m => m.FN_ParentID == parent.FN_ID);
                if (list_Child.Count > 0)
                {
                    foreach (FlowModels.Sys_Module child in list_Child)
                    {
                        nodeChild = new TreeNode();
                        nodeChild.Text = child.FN_ModuleName;
                        nodeChild.Value = child.FN_ID;
                        nodeChild.ImageUrl = "../Flow/inc/dtree/img/obj2.gif";
                        if (RoleModule.List_Modules.Where(m => m.FN_ID == child.FN_ID && m.FN_ParentID == child.FN_ParentID).Count() > 0)
                        {
                            nodeChild.Checked = true;
                        }
                        nodeParent.ChildNodes.Add(nodeChild);
                    }
                }
                tv_menu.Nodes.Add(nodeParent);
            }
        }
        protected void btnOK_Click(object sender, ImageClickEventArgs e)
        {
            FlowModels.Sys_RoleModule model = new FlowModels.Sys_RoleModule();
            model.List_Roles.Add(new FlowModels.Sys_Role() { FN_ID = Request.QueryString["id"], FN_Remark = Tb_Remark.Text.Trim(), FN_RoleName = Tb_RoelName.Text.Trim() });
            foreach (TreeNode item in tv_menu.CheckedNodes)
            {
                if (model.List_Modules.Count(m => m.FN_ID == item.Parent.Value) <= 0)
                {
                    model.List_Modules.Add(new FlowModels.Sys_Module() { FN_ID = item.Parent.Value });
                }
                model.List_Modules.Add(new FlowModels.Sys_Module() { FN_ID = item.Value });
            };
            bool result = false;
            if (Request.QueryString["op"] == "0")
            {
                model.List_Roles[0].FN_ID = Guid.NewGuid().ToString();
                result = FlowBLL.Sys_RoleManager.InsertRole(model);
            }
            else if (Request.QueryString["op"] == "1")
            {
                result = FlowBLL.Sys_RoleManager.UpdateRole(model);
            }
            if (result)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "useredit", "alert('角色信息处理成功！');window.close();window.returnValue = 'ok';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "useredit", "alert('角色信息处理失败！');window.close();window.returnValue = 'error';", true);
            }
        }
    }
}