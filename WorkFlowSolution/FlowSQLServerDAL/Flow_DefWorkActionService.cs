using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowSQLServerDAL
{
    class Flow_DefWorkActionService : FlowIDAL.IFlow_DefWorkActionService
    {
        public bool InsertDefAction(FlowModels.Flow_DefWorkAction model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDefAction(FlowModels.Flow_DefWorkAction model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDefAction(FlowModels.Flow_DefWorkAction model)
        {
            throw new NotImplementedException();
        }

        public List<FlowModels.Flow_DefWorkAction> GetAllDefActions()
        {
            throw new NotImplementedException();
        }

        public List<FlowModels.Flow_DefWorkAction> GetSubDefActionByID(FlowModels.Flow_DefWorkAction model)
        {
            List<FlowModels.Flow_DefWorkAction> list = new List<FlowModels.Flow_DefWorkAction>();
            string sql = @"SELECT * FROM DBO.FLOW_DEFWORKACTION WHERE FN_FRONTSTEPID=@StepID";
            //System.Data.DataTable dt = DBHelper.Query(sql, new System.Data.SqlClient.SqlParameter[] { DBHelper.MakeParameter("StepID", System.Data.SqlDbType.NVarChar, 200, model.FN_FrontStepID) }).Tables[0];
            //FlowModels.Flow_DefWorkAction workAction = null;
            //foreach (System.Data.DataRow item in dt.Rows)
            //{
            //    workAction = new FlowModels.Flow_DefWorkAction();
            //    workAction.FN_ActionID = item["FN_ActionID"].ToString();
            //    workAction.FN_ActionName = item["FN_ActionName"].ToString();
            //    //workAction.FN_FrontStepID = item["FN_FrontStepID"].ToString();
            //    //workAction.FN_BehindStepID = item["FN_BehindStepID"].ToString();
            //   // workAction.FN_Condition = item["FN_Condition"].ToString();
            //    list.Add(workAction);
            //}
            return list;
        }
        public bool CheckEndStep(string FlowID, String StepID)
        {
            string sql = string.Format(@"select count(-1) from dbo.Flow_DefWorkStep where fn_flowid='{0}'
                            and FN_StepType='EndStep' and FN_StepID=(select FN_BehindStepID from dbo.Flow_DefWorkAction where FN_FrontStepID='{1}');", FlowID, StepID);
            return int.Parse(DBHelper.GetSingle(sql).ToString()) == 1;
        }
    }
}
