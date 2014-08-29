using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlowWeb.Main
{
    public partial class Left : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false && Session["Sys_User"]==null)
            {
                Response.Redirect("/Login.aspx");
            }
        }

        public string InitData()
        {
            FlowModels.Sys_User User = Session["Sys_User"] as FlowModels.Sys_User;
            List<FlowModels.Sys_Module> list_Modules = FlowBLL.Sys_ModuleManager.GetSubModuleByRole(new FlowModels.Sys_Role() { FN_ID = User.FN_RoleID });
            string htmldata = string.Empty;
            int i = 0;
            foreach (FlowModels.Sys_Module parent in list_Modules.FindAll(m => m.FN_ParentID == new Guid().ToString()))
            {
                i++;
                htmldata += @"<tr>
        <td><table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
          <tr>
            <td height=""23"" background=""images/main_47.gif"" id=""imgmenu"+i+@""" class=""menu_title"" onMouseOver=""this.className='menu_title2';"" onClick=""showsubmenu(" +i+ @")"" onMouseOut=""this.className='menu_title';"" style=""cursor:hand""><table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
              <tr>
                <td width=""18%"">&nbsp;</td>
                <td width=""82%"" class=""STYLE1"">" +parent.FN_ModuleName+@"</td>
              </tr>
            </table></td>
          </tr>
          <tr>
            <td background=""images/main_51.gif"" id=""submenu"+i+@""">
			 <div class=""sec_menu"" >  
			<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
              <tr>
                <td><table width=""90%"" border=""0"" align=""center"" cellpadding=""0"" cellspacing=""0"">";

                List<FlowModels.Sys_Module> list_Child = list_Modules.FindAll(m => m.FN_ParentID == parent.FN_ID);
                foreach (FlowModels.Sys_Module child in list_Child)
                {
                    #region 动态生成td
                    htmldata += @" <tr>
                    <td width=""16%"" height=""25""><div align=""center""><img src=""images/left.gif"" width=""10"" height=""10"" /></div></td>
                    <td width=""84%"" height=""23""><table width=""95%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                        <tr>
                          <td height=""20""  onclick=""changepage('"+child.FN_ModuleUrl+@"')"" style=""cursor:hand"" onmouseover=""this.style.borderStyle='solid';this.style.borderWidth='1';borderColor='#7bc4d3'; ""onmouseout=""this.style.borderStyle='none'"" ><span class=""STYLE3"">"+child.FN_ModuleName+@"</span></td>
                        </tr>
                    </table></td>
                  </tr>";

                    #endregion
                }
                htmldata += @" </table></td>
                              </tr>
                              <tr>
                                <td height=""5""><img src=""images/main_52.gif"" width=""151"" height=""5"" /></td>
                              </tr>
                                </table></div></td>
                                 </tr>
                                </table></td>
                              </tr>";
            }

            return htmldata;
        }
    }
}