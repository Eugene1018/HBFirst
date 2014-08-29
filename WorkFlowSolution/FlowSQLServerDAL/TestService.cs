using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FlowSQLServerDAL
{
    public class TestService : FlowIDAL.ITestService
    {
        public DataTable GetTestData()
        {
            string sql = @"SELECT t.*,a.FN_FlowID,d.FN_FlowID FN_DefFlowID,d.FN_FlowName FN_DefFlowName,w.FN_FlowState FROM 
                                (
                                SELECT ROW_NUMBER()  OVER(ORDER BY FN_ID DESC) 序号,* FROM dbo.Test
                                )t
                                left join
                                (select FN_FlowID,FN_FormID FROM dbo.Flow_WorkAttach where FN_IsCurrent='1') a
                                on t.FN_ID=a.FN_FormID
                                left join
                                (
                                select FN_DefFlowID,FN_FlowID,FN_FlowState from dbo.Flow_WorkFlow
                                )w
                                on a.FN_FlowID=w.FN_FlowID
                                left join
                                (
                                select * from  dbo.Flow_DefWorkFlow
                                )d
                                on w.FN_DefFlowID=d.FN_FlowID";
            return DBHelper.Query(sql).Tables[0];
        }
    }
}
