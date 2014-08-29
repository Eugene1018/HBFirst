using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FlowSQLServerDAL
{
    public class Flow_DefWorkFlowService : FlowIDAL.IFlow_DefWorkFlowService
    {

        public bool InsertDefWorkFlow(FlowModels.Flow_DefWorkFlow model)
        {
            string sql = @"BEGIN TRY
                                SET XACT_ABORT ON;
                                BEGIN TRANSACTION;";
            sql = DelFlow_DefWorkFlowSql(model, sql);
            sql = AddFlow_DefWorkFlowSql(model, sql);
            sql = AddFlow_DefWorkStepSql(model, sql);
            sql = AddFlow_DefWorkActionSql(model, sql);
            sql += @";COMMIT TRANSACTION;
	                print 1;
                END TRY
                BEGIN CATCH
	                print @@error
                    IF (XACT_STATE()) = -1
                    BEGIN        
                        ROLLBACK TRANSACTION;
                    END
	                IF (XACT_STATE()) = 1
                    BEGIN
                        COMMIT TRANSACTION;   
                    END
                  print -1;
                END CATCH";
           return DBHelper.ExecuteSql(sql) > 0;
        }

        private static string AddFlow_DefWorkFlowSql(FlowModels.Flow_DefWorkFlow model, string sql)
        {
            sql += string.Format(@"INSERT INTO [Flow_DefWorkFlow]
                                           ([FN_FlowID]
                                           ,[FN_FlowName]
                                           ,[FN_FlowType]
                                           ,[FN_FlowXML]
                                           ,[FN_CreateDate],[FN_Conditions])
                                         VALUES
                                           ('{0}',
                                            '{1}',
                                            '{2}',
                                            '{3}',
                                            '{4}','{5}');", model.FN_FlowID, model.FN_FlowName, model.FN_FlowType, model.FN_FlowXml, model.FN_CreateData,model.FN_Conditions);
            return sql;
        }

        private static string AddFlow_DefWorkActionSql(FlowModels.Flow_DefWorkFlow model, string sql)
        {
            foreach (FlowModels.Flow_DefWorkAction action in model.List_DefWorkActions)
            {
                sql += string.Format(@"INSERT INTO [Flow_DefWorkAction]
                                       ([FN_ActionID]
                                       ,[FN_ActionName]
                                       ,[FN_DefStepID]
                                       ,[FN_NextDefStepID]
                                       ,[FN_DefaultOpinion],[FN_DefaultPlugins])
                                 VALUES
                                       ('{0}'
                                       ,'{1}'
                                       ,'{2}'
                                       ,'{3}'
                                       ,'{4}','{5}');", action.FN_ActionID,
                                                  action.FN_ActionName,
                                                  action.FN_DefStepID,
                                                  action.FN_NextDefStepID,
                                                  action.FN_DefaultOpinion,action.FN_DefaultPlugins);
            }
            return sql;
        }

        private static string AddFlow_DefWorkStepSql(FlowModels.Flow_DefWorkFlow model, string sql)
        {
            foreach (FlowModels.Flow_DefWorkStep step in model.List_DefWorkSteps)
            {
                sql += string.Format(@"INSERT INTO [Flow_DefWorkStep]
                                                ([FN_StepID]
                                                ,[FN_DefFlowID]
                                                ,[FN_StepName]
                                                ,[FN_StepType],[FN_StepRole],[FN_UnionPass],[FN_Index])
                                             VALUES
                                                ('{0}',
                                                 '{1}',
                                                 '{2}',
                                                 '{3}','{4}','{5}','{6}');", step.FN_StepID, step.FN_DefFlowID, step.FN_StepName, step.FN_StepType,step.FN_StepRole,step.FN_UnionPass,step.FN_Index);
              
            }
            return sql;
        }

        public bool DeleteDefWorkFlow(FlowModels.Flow_DefWorkFlow model)
        {
            string sql = @"BEGIN TRY
                                SET XACT_ABORT ON;
                                BEGIN TRANSACTION;";
            sql = DelFlow_DefWorkFlowSql(model, sql);
            sql += @"COMMIT TRANSACTION;
	                print 1;
                END TRY
                BEGIN CATCH
	                print @@error
                    IF (XACT_STATE()) = -1
                    BEGIN        
                        ROLLBACK TRANSACTION;
                    END
	                IF (XACT_STATE()) = 1
                    BEGIN
                        COMMIT TRANSACTION;   
                    END
                  print -1;
                END CATCH";
            return DBHelper.ExecuteSql(sql) > 0;
        }

        private string DelFlow_DefWorkFlowSql(FlowModels.Flow_DefWorkFlow model, string sql)
        {
            sql += string.Format(@"IF (select count(-1) from dbo.Flow_DefWorkFlow where FN_FlowID='{0}')>0
	                                    BEGIN
		                                    DELETE FROM dbo.Flow_DefWorkAction where FN_DefStepID in (select FN_StepID from dbo.Flow_DefWorkStep where FN_DefFlowID='{0}')
                                            or FN_NextDefStepID in (select FN_StepID from dbo.Flow_DefWorkStep where FN_DefFlowID='{0}');
		                                    DELETE FROM dbo.Flow_DefWorkStep where FN_DefFlowID='{0}';
		                                    DELETE FROM dbo.Flow_DefWorkFlow where FN_FlowID='{0}';
	                                    END;", model.FN_FlowID);
            return sql;

        }

        public bool UpdateDefWorkFlow(FlowModels.Flow_DefWorkFlow model)
        {
            throw new NotImplementedException();
        }

        public List<FlowModels.Flow_DefWorkFlow> GetAllDefWorkFlows()
        {
            string sql = "select * from [dbo].[Flow_DefWorkFlow]";
            DataTable datable = DBHelper.Query(sql).Tables[0];
            List<FlowModels.Flow_DefWorkFlow> list = new List<FlowModels.Flow_DefWorkFlow>();
            FlowModels.Flow_DefWorkFlow defWorkFlow;
            foreach (DataRow item in datable.Rows)
            {
                defWorkFlow = new FlowModels.Flow_DefWorkFlow();
                defWorkFlow.FN_FlowName = item["Fn_FlowName"].ToString();
                defWorkFlow.FN_FlowID = item["Fn_FlowID"].ToString();
                defWorkFlow.FN_FlowType = item["Fn_FlowType"].ToString();
                defWorkFlow.FN_FlowXml = item["Fn_FlowXml"].ToString();
                defWorkFlow.FN_Conditions = item["FN_Conditions"].ToString();
                defWorkFlow.FN_CreateData = item["Fn_CreateDate"].ToString();
                list.Add(defWorkFlow);
            }
            return list;
        }

        public List<FlowModels.Flow_DefWorkFlow> GetSubDefWorkFlowByID(string FN_ID)
        {
            throw new NotImplementedException();
        }
    }
}
