using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FlowCommon;
using FlowModels;
using FlowBLL;


namespace FlowWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_Sub_Click(object sender, EventArgs e)
        {
            var model = new Sys_User() { FN_ID = string.Empty, FN_UserName = txt_UserName.Text.Trim(), FN_UserPwd = txt_UserPwd.Text.Trim(),FN_IsLock="0" };
            if (Sys_UserManager.CheckLogin(model))
            {
                List<Sys_User> listUsers = Sys_UserManager.GetSubUserByModel(model);
                Session["Sys_User"] = listUsers[0];
                Response.Redirect("Main/Main.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error", "<script>alert('用户名或密码错误！');</script>");
                return;
            }
        }

    }
}