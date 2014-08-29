using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlowWeb.Main
{
    public partial class Top : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false && Session["Sys_User"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
        }
        protected string GetCurrentDate()
        {
            FlowCommon.ChineseCalendar calender = new FlowCommon.ChineseCalendar(DateTime.Now);
            return calender.DateString + "&nbsp;" + calender.WeekDayStr + "&nbsp;" +calender.ChineseMonthString + calender.ChineseDayString + calender.ChineseTwentyFourDay + "&nbsp;&nbsp;<font color='red' style='font-size:12.5px'>" + calender.DateHoliday + "&nbsp;" + calender.ChineseCalendarHoliday + "</font>";
        }
        protected string InitUserName()
        {
            string UserName = string.Empty;
            if (Session["Sys_User"] != null)
            {

                UserName = (Session["Sys_User"] as FlowModels.Sys_User).FN_RealName;
            }
            return UserName;
        }
    }
}