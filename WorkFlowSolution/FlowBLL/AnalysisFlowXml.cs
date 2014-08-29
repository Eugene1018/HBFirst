using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowModels;
using System.Xml;

namespace FlowBLL
{
    internal sealed class AnalysisFlowXml
    {
        public static Flow_DefWorkFlow GeneralFlow(string flowXml, enXmlOpState enXml)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(flowXml);
            Flow_DefWorkFlow DefWorkFlow = new Flow_DefWorkFlow();
            XmlNodeList nodes = xml.SelectNodes("/WebFlow/FlowConfig/BaseProperties");
            DefWorkFlow.FN_FlowID = nodes[0].Attributes["flowId"].Value.Trim('$').Replace('$', '-');
            DefWorkFlow.FN_FlowName = nodes[0].Attributes["flowText"].Value;
            DefWorkFlow.FN_FlowType = "";
            DefWorkFlow.FN_FlowXml = (flowXml.StartsWith("<?xml version") ? flowXml : "<?xml version=\"1.0\" encoding=\"GBK\"?>" + flowXml).Replace("'","$");
            DefWorkFlow.FN_Conditions = nodes[0].Attributes["flowConditions"].Value;
            DefWorkFlow.FN_CreateData = DateTime.Now.ToShortDateString();
            if (enXml == enXmlOpState.Delete)
            {
                return DefWorkFlow;
            }
            XmlNodeList Steps = xml.SelectNodes("/WebFlow/Steps/Step");
            Flow_DefWorkStep DefWorkStep = null;
            foreach (XmlNode step in Steps)
            {
                DefWorkStep = new Flow_DefWorkStep();
                XmlNode basePropertiesNode = step.SelectSingleNode("BaseProperties");
                DefWorkStep.FN_DefFlowID = DefWorkFlow.FN_FlowID;
                DefWorkStep.FN_StepID = basePropertiesNode.Attributes["id"].Value.Trim('$').Replace('$', '-');
                DefWorkStep.FN_StepName = basePropertiesNode.Attributes["text"].Value;
                DefWorkStep.FN_StepType = basePropertiesNode.Attributes["stepType"].Value;
                DefWorkStep.FN_Index = basePropertiesNode.Attributes["stepIndex"].Value;
                DefWorkStep.FN_UnionPass = basePropertiesNode.Attributes["unionPass"].Value;
                DefWorkStep.FN_StepRole = step.SelectSingleNode("FlowProperties").Attributes["people"].Value.Replace("$","'").Replace("'","''");
                DefWorkFlow.List_DefWorkSteps.Add(DefWorkStep);
            }

            XmlNodeList Actions = xml.SelectNodes("/WebFlow/Actions/Action");
            Flow_DefWorkAction DefWorkAction = null;
            foreach (XmlNode action in Actions)
            {
                DefWorkAction = new Flow_DefWorkAction();
                XmlNode basePropertiesNode = action.SelectSingleNode("BaseProperties");
                DefWorkAction.FN_ActionID = basePropertiesNode.Attributes["id"].Value.Trim('$').Replace('$', '-');
                DefWorkAction.FN_ActionName = basePropertiesNode.Attributes["text"].Value;
                DefWorkAction.FN_DefStepID = basePropertiesNode.Attributes["from"].Value.Trim('$').Replace('$', '-');
                DefWorkAction.FN_NextDefStepID = basePropertiesNode.Attributes["to"].Value.Trim('$').Replace('$', '-');
                DefWorkAction.FN_DefaultOpinion = basePropertiesNode.Attributes["opinion"].Value;
                DefWorkAction.FN_DefaultPlugins = action.SelectSingleNode("FlowProperties").Attributes["plugin"].Value;

                DefWorkFlow.List_DefWorkActions.Add(DefWorkAction);
            }
            return DefWorkFlow;
        }

    }

}
