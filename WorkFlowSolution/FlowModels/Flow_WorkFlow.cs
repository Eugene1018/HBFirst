using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowModels
{
   public class Flow_WorkFlow
    {
       /// <summary>
       /// 流程ID
       /// </summary>
       public string FN_FlowID { get; set; }

       /// <summary>
       /// 流程模板
       /// </summary>
       public string FN_DefFlowID { get; set; }

       /// <summary>
       /// 流程状态
       /// </summary>
       public enAuditState FN_FlowState { get; set; }

       /// <summary>
       /// 流程发起时间
       /// </summary>
       public string FN_CreateDate { get;set;}

       /// <summary>
       /// 流程发起方式（1，逐条发起，2,打包发起）
       /// </summary>
       public string FN_CreateType { get; set; }

       private List<Flow_WorkStep> list_WorkSteps;
       public  List<Flow_WorkStep> List_WorkSteps
       {
           get
           {
               if (list_WorkSteps == null)
               {
                   list_WorkSteps = new List<Flow_WorkStep>();
               }
               return this.list_WorkSteps;
           }
           set
           {
               list_WorkSteps = value;
           }
       }
       private List<Flow_WorkUser> list_WorkUsers;
       public List<Flow_WorkUser> List_WorkUsers
       {
           get
           {
               if (list_WorkUsers == null)
               {
                   list_WorkUsers = new List<Flow_WorkUser>();
               }
               return list_WorkUsers;
           }
           set
           {
               list_WorkUsers = value;
           }
       }
       private List<Flow_WorkAudit> list_WorkAudits;
       public List<Flow_WorkAudit> List_WorkAudits
       {
           get
           {
               if (list_WorkAudits == null)
               {
                   list_WorkAudits = new List<Flow_WorkAudit>();
               }
               return list_WorkAudits;
           }
           set
           {
               list_WorkAudits = value;
           }
       } 

       private List<string> list_forms;
       public  List<string> List_Forms
       {
           get
           {
               if (list_forms == null)
               {
                   list_forms = new List<string>();
               }
               return list_forms;
           }
           set
           {
               list_forms = value;
           }
       }
      

    }
}
