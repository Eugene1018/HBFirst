using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;

namespace FlowWeb.Flow
{
    public partial class FlowPreview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"].ToLower();
                if (string.IsNullOrEmpty(id) == false)
                {
                    if (id.Contains("|") == false)
                    {
                        FlowModels.Flow_DefWorkFlow model = FlowBLL.Flow_DefWorkFlowManager.GetAllDefWorkFlows().Find(m => m.FN_FlowID == id);
                        ScriptManager.RegisterStartupScript(this, Page.GetType(), "loadxml", "document.getElementById('FlowXML').value='" + model.FN_FlowXml + "'", true);
                    }
                    else
                    {
                        DataSet ds = FlowBLL.Flow_WorkFlowManager.GetFlowPreData(id.Split('|')[0], id.Split('|')[1]);
                        DataTable dataTable = ds.Tables[1];
                        if (ds.Tables.Count> 0)
                        {
                            string flowXml = ds.Tables[0].Rows[0]["FN_FlowXml"].ToString();
                            XmlDocument xml = new XmlDocument();
                            xml.LoadXml(flowXml);
                            XmlNodeList Steps = xml.SelectNodes("/WebFlow/Steps/Step");
                            string currentStep = dataTable.Select("FN_IsCurrent='1'")[0]["FN_DefStepID"].ToString();
                            foreach (XmlNode step in Steps)
                            {
                                string stepID = step.SelectSingleNode("BaseProperties").Attributes["id"].Value.Trim('$').Replace('$', '-');                                
                                XmlAttribute attr = attr = xml.CreateAttribute("stepColor1");
                                DataRow[] drs = dataTable.Select("FN_DefStepID='" + stepID + "'");
                                string text = step.SelectSingleNode("BaseProperties").Attributes["text"].Value;
                                if (text == "开 始")
                                {
                                    attr.Value = "green";
                                }
                                else if (drs != null && drs.Length > 0 && stepID != currentStep)
                                {
                                    attr.Value = "green";
                                    step.SelectSingleNode("BaseProperties").Attributes["text"].Value = text;
                                }
                                else if (stepID == currentStep)
                                {
                                    attr.Value = "red";
                                    step.SelectSingleNode("BaseProperties").Attributes["text"].Value = text + "   [ 当前状态 ]";
                                }
                                else
                                {
                                    attr.Value = "#7FFF00";
                                
                                }
                                step.SelectSingleNode("VMLProperties").Attributes.SetNamedItem(attr);
                            }

                            ScriptManager.RegisterStartupScript(this, Page.GetType(), "loadxml", "document.getElementById('FlowXML').value='" + xml.OuterXml + "'", true);
                        }
                    }
                }
            }
        }
    }
}