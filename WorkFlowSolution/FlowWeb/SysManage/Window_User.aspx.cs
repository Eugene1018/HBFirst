using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.MobileControls;

namespace FlowWeb.SysManage
{
    public partial class Window_User : System.Web.UI.Page
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
                    Tb_LoginName.BorderStyle = BorderStyle.None;
                    Tb_LoginName.ReadOnly = true;
                    InitData();
                }
                else if (Request.QueryString["op"] == "2")
                {
                    if (FlowBLL.Sys_UserManager.DeleteUser(new FlowModels.Sys_User() { FN_ID = Request.QueryString["id"] }))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "userdel", "alert('用户信息处理成功！');window.close();window.returnValue = 'ok';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "userdel", "alert('用户信息处理失败！');window.close();window.returnValue = 'error';", true);
                    }
                }
            }
        }

        private void AddData()
        {
            List<FlowModels.Sys_Role> list_Roles = FlowBLL.Sys_RoleManager.GetSubRoleByModel(null);
            foreach (FlowModels.Sys_Role Role in list_Roles)
            {
                ListItem item = new ListItem(Role.FN_RoleName, Role.FN_ID);
                Lb_Role.Items.Add(item);
            }
        }

        private void InitData()
        {
            List<FlowModels.Sys_User> list_Users = FlowBLL.Sys_UserManager.GetSubUserByModel(new FlowModels.Sys_User() { FN_ID = Request.QueryString["id"] });
            string RoleID = string.Empty;
            if (list_Users.Count > 0)
            {
                var model = list_Users[0];
                Tb_LoginName.Text = model.FN_UserName;
                Tb_LoginPwd.Text = model.FN_UserPwd;
                Tb_LoginPwd.Attributes.Add("value", model.FN_UserPwd);
                Tb_RealName.Text = model.FN_RealName;
                Tb_Telphone.Text = model.FN_TelePhone;
                Tb_Email.Text = model.FN_Email;
                Rbl_IsLock.Items[int.Parse(model.FN_IsLock)].Selected = true;
                RoleID = model.FN_RoleID;
            }
            List<FlowModels.Sys_Role> list_Roles = FlowBLL.Sys_RoleManager.GetSubRoleByModel(null);
            foreach (FlowModels.Sys_Role Role in list_Roles)
            {
                ListItem item = new ListItem(Role.FN_RoleName, Role.FN_ID);
                if (string.IsNullOrEmpty(RoleID) == false && Role.FN_ID == RoleID)
                {
                    item.Selected = true;
                }
                Lb_Role.Items.Add(item);
            }

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            FlowModels.Sys_User User = new FlowModels.Sys_User();
            
            User.FN_UserPwd = Tb_LoginPwd.Text.Trim();
            User.FN_RealName = Tb_RealName.Text.Trim();
            User.FN_RoleID = Lb_Role.SelectedItem.Value;
            User.FN_TelePhone = Tb_Telphone.Text.Trim();
            User.FN_Email = Tb_Email.Text.Trim();
            User.FN_IsLock = Rbl_IsLock.SelectedItem.Value;
            bool result = false;
            if (Request.QueryString["op"] == "0")
            {
                User.FN_ID = Guid.NewGuid().ToString();
                User.FN_UserName = Tb_LoginName.Text.Trim();
                 result=FlowBLL.Sys_UserManager.InsertUser(User);
            }
            else if (Request.QueryString["op"] == "1")
            {
                User.FN_ID = Request.QueryString["id"];
                result=FlowBLL.Sys_UserManager.UpdateUser(User);
            }
            if (result)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "useredit", "alert('用户信息处理成功！');window.close();window.returnValue = 'ok';", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "useredit", "alert('用户信息处理失败！');window.close();window.returnValue = 'error';", true);
            }
        }
    }
}