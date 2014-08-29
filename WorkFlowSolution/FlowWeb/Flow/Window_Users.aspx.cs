using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlowWeb.Flow
{
    public partial class Window_Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                InitRoles();
            }
        }
        private void InitRoles()
        {
            List<FlowModels.Sys_Role> list_Roles = FlowBLL.Sys_RoleManager.GetSubRoleByModel(null);
            NextStepList.DataSource = list_Roles;
            NextStepList.DataTextField = "FN_RoleName";
            NextStepList.DataValueField = "FN_ID";
            NextStepList.DataBind();
        }

        protected void btnOK_Click(object sender, ImageClickEventArgs e)
        {
            string text =string.Empty;
            string value = string.Empty;
            foreach (ListItem item in NextWorkUserSelectedList.Items)
            {
                text += item.Text + ",";
                value += item.Value.Split('|')[0] + ",";
            }
            string result = HttpUtility.UrlDecode(text.TrimEnd(',')+"|"+value.TrimEnd(','), System.Text.Encoding.GetEncoding("GB2312"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "audit", "window.close();window.returnValue = '"+result.TrimEnd('$')+"';", true);
        }


        protected void btnNextStepList_Click(object sender, ImageClickEventArgs e)
        {
            DoStepSelect(NextStepList, NextStepSelectedList);
        }

        protected void btnNextStepSelectedList_Click(object sender, ImageClickEventArgs e)
        {
            DoStepSelect(NextStepSelectedList, NextStepList);
        }

        protected void btnNextWorkUserList_Click(object sender, ImageClickEventArgs e)
        {
            DoStepSelect(NextWorkUserList, NextWorkUserSelectedList);
        }

        protected void btnNextWorkUserSelectedList_Click(object sender, ImageClickEventArgs e)
        {
            DoStepSelect(NextWorkUserSelectedList, NextWorkUserList);
        }
        private void DoStepSelect(ListBox listOne, ListBox listTwo)
        {
            if (listOne.SelectedIndex < 0) return;
            ListItem item = listOne.SelectedItem;
            item.Selected = false;
            if (listTwo.Items.Contains(item) == false)
            {
                listTwo.Items.Add(item);
            }
            listOne.Items.Remove(item);
            if (listOne.ID == "NextStepList")
            {
                List<FlowModels.Sys_User> list_Users = FlowBLL.Sys_UserManager.GetSubUserByModel(new FlowModels.Sys_User() { FN_RoleID = item.Value });
                foreach (FlowModels.Sys_User user in list_Users)
                {
                    ListItem itemUser = new ListItem(user.FN_RealName, user.FN_ID + "|" + item.Value);
                    NextWorkUserList.Items.Add(itemUser);
                }
            }
            if (listOne.ID == "NextStepSelectedList")
            {
                RemoveUser(item, NextWorkUserList);
                RemoveUser(item, NextWorkUserSelectedList);
            }
        }

        private void RemoveUser(ListItem itemRole, ListBox lstWorkUser)
        {
            List<ListItem> listUser = new List<ListItem>();
            foreach (ListItem itemUser in lstWorkUser.Items)
            {
                if (itemUser.Value.Split('|')[1] != itemRole.Value)
                {
                    listUser.Add(itemUser);
                }
            }
            lstWorkUser.Items.Clear();
            lstWorkUser.DataSource = listUser;
            lstWorkUser.DataTextField = "Text";
            lstWorkUser.DataValueField = "Value";
            lstWorkUser.DataBind();
        }
    }
}