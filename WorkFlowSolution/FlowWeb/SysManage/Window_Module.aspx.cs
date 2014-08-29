using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlowWeb.SysManage
{
    public partial class Window_Module : System.Web.UI.Page
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
                    if (FlowBLL.Sys_ModuleManager.DeleteModule(new FlowModels.Sys_Module() { FN_ID = Request.QueryString["id"] }))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "moduledel", "alert('模块信息处理成功！');window.close();window.returnValue = 'ok';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "moduledel", "alert('模块信息处理失败！');window.close();window.returnValue = 'error';", true);
                    }
                }
            }
        }

        private void AddData()
        {
            List<FlowModels.Sys_Module> list_ParentModules = FlowBLL.Sys_ModuleManager.GetSubModuleByModel(new FlowModels.Sys_Module() { FN_ParentID = new Guid().ToString() });
            Lst_Menu.Items.Add(new ListItem("[顶级模块]", new Guid().ToString()));
            foreach (FlowModels.Sys_Module Module in list_ParentModules)
            {
                ListItem item = new ListItem(Module.FN_ModuleName, Module.FN_ID);
                Lst_Menu.Items.Add(item);
            }
        }
        private void InitData()
        {
            List<FlowModels.Sys_Module> list_Modules = FlowBLL.Sys_ModuleManager.GetSubModuleByModel(new FlowModels.Sys_Module() { FN_ID = Request.QueryString["id"] });
            string ParentID = string.Empty;
            if (list_Modules.Count > 0)
            {
                var model = list_Modules[0];
                Tb_ModuleName.Text = model.FN_ModuleName;
                Tb_ModuleUrl.Text = model.FN_ModuleUrl;
                Tb_Order.Text = model.FN_Order;
                Tb_Remark.Text = model.FN_Remark;
                ParentID = model.FN_ParentID;
            }
            List<FlowModels.Sys_Module> list_ParentModules = FlowBLL.Sys_ModuleManager.GetSubModuleByModel(new FlowModels.Sys_Module() { FN_ParentID = new Guid().ToString() });
            Lst_Menu.Items.Add(new ListItem("[顶级模块]", new Guid().ToString()));
            foreach (FlowModels.Sys_Module Module in list_ParentModules)
            {
                ListItem item = new ListItem(Module.FN_ModuleName, Module.FN_ID);
                if (string.IsNullOrEmpty(ParentID) == false && Module.FN_ID == ParentID)
                {
                    item.Selected = true;
                }
                Lst_Menu.Items.Add(item);
            }
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            FlowModels.Sys_Module Module = new FlowModels.Sys_Module() { FN_ParentID=Lst_Menu.SelectedItem.Value,FN_ModuleName = Tb_ModuleName.Text.Trim(), FN_ModuleUrl = Tb_ModuleUrl.Text.Trim(), FN_Order = Tb_Order.Text.Trim(), FN_Remark = Tb_Remark.Text.Trim() };
            bool result = false;
            if (Request.QueryString["op"] == "0")
            {
                Module.FN_ID = Guid.NewGuid().ToString();
                result = FlowBLL.Sys_ModuleManager.InsertModule(Module);
            }
            else if (Request.QueryString["op"] == "1")
            {
                Module.FN_ID = Request.QueryString["id"];
                result = FlowBLL.Sys_ModuleManager.UpdateModule(Module);
            }
            if (result)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "useredit", "alert('模块信息处理成功！');window.close();window.returnValue = 'ok';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "useredit", "alert('模块信息处理失败！');window.close();window.returnValue = 'error';", true);
            }
        }
    }
}