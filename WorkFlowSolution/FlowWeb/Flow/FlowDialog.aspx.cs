using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace FlowWeb
{
    public partial class FlowDialog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string GetGuid()
        {
            return "$" + Guid.NewGuid().ToString().Replace("-", "$");
        }
    }
}