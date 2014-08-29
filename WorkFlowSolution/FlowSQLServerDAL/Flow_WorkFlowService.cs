using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FlowSQLServerDAL
{
    public class Flow_WorkFlowService : FlowIDAL.IFlow_WorkFlowService
    {
        public bool InsertWorkFlow(FlowModels.Flow_WorkFlow model)
        {
            string sql = @"BEGIN TRY
                                SET XACT_ABORT ON;
                                BEGIN TRANSACTION;";
            #region Sql
            if (model.FN_CreateType == "1")
            {
                sql = AddFlow_WorkFlowByEveryOne(model, sql);
            }
            else if (model.FN_CreateType == "2")
            {
                sql = AddFlow_WorkFlowSql(model, sql);

                sql = AddFlow_WorkStepSql(model, sql);

                sql = AddFlow_WorkUserSql(model, sql);
            }
            #endregion
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

        private string AddFlow_WorkFlowSql(FlowModels.Flow_WorkFlow model, string sql)
        {
            sql += string.Format(@"INSERT INTO [Flow_WorkFlow]
                       ([FN_FlowID],
                        [FN_DefFlowID],
                        [FN_FlowState],
                        [FN_CreateDate])
		            VALUES
                       ('{0}',
                        '{1}',
                        '{2}',
                        '{3}');", model.FN_FlowID, model.FN_DefFlowID, (int)model.FN_FlowState, model.FN_CreateDate);

            foreach (var form in model.List_Forms)
            {
                sql += string.Format(@"INSERT INTO [Flow_WorkAttach] ([FN_FormID],[FN_FlowID],[FN_IsCurrent]) VALUES ('{0}','{1}','1');", form, model.FN_FlowID);
            }

            return sql;
        }

        private string AddFlow_WorkStepSql(FlowModels.Flow_WorkFlow model, string sql)
        {
            foreach (FlowModels.Flow_WorkStep step in model.List_WorkSteps)
            {

                sql += string.Format(@"INSERT INTO [Flow_WorkStep]
                           ([FN_StepID]
                           ,[FN_PreStepID]
                           ,[FN_FlowID]
                           ,[FN_DefStepID]
                           ,[FN_DefActionID]
                           ,[FN_SendID]
                           ,[FN_SendDate]
                           ,[FN_Index],[FN_IsCurrent])
                     VALUES
                           ('{0}',{1},'{2}',{3} ,{4},'{5}','{6}','{7}','{8}');",
                            step.FN_StepID,
                            step.FN_PreStepID,
                            step.FN_FlowID,
                            step.FN_DefStepID,
                            step.FN_DefActionID,
                            step.FN_SendID,
                            step.FN_SendDate,
                            step.FN_Index, step.FN_IsCurrent);

            }
            return sql;
        }

        private string AddFlow_WorkUserSql(FlowModels.Flow_WorkFlow model, string sql)
        {
            foreach (var item in model.List_WorkUsers)
            {
                sql += string.Format(@"INSERT INTO [Flow_WorkUser]
                                       ([FN_StepID]
                                       ,[FN_UserID]
                                       ,[FN_Pass]
                                       ,[FN_ActionID]
                                       ,[FN_Note])
                                    VALUES
                                      ('{0}','{1}',{2},{3},'{4}');", item.FN_StepID, item.FN_UserID, item.FN_Pass, item.FN_Action, item.FN_Note);
            }
            return sql;
        }

        private string AddFlow_WorkFlowByEveryOne(FlowModels.Flow_WorkFlow model, string sql)
        {
            foreach (var form in model.List_Forms)
            {
                string flowid = Guid.NewGuid().ToString();
                model.FN_FlowID = flowid;
                sql += string.Format(@"INSERT INTO [Flow_WorkFlow]
                       ([FN_FlowID],
                        [FN_DefFlowID],
                        [FN_FlowState],
                        [FN_CreateDate])
		            VALUES
                       ('{0}',
                        '{1}',
                        '{2}',
                        '{3}');", model.FN_FlowID, model.FN_DefFlowID, (int)model.FN_FlowState, model.FN_CreateDate);

                sql += string.Format(@"INSERT INTO [Flow_WorkAttach] ([FN_FormID],[FN_FlowID],[FN_IsCurrent]) VALUES ('{0}','{1}','1');", form, model.FN_FlowID);
                FlowModels.Flow_WorkFlow newModel = model;
                sql = AddFlow_WorkStepByEveryOne(newModel, sql);
            }
            return sql;
        }

        private string AddFlow_WorkStepByEveryOne(FlowModels.Flow_WorkFlow model, string sql)
        {
            foreach (FlowModels.Flow_WorkStep step in model.List_WorkSteps)
            {
                string stepid = Guid.NewGuid().ToString();
                foreach (var item in model.List_WorkUsers)
                {
                    if (item.FN_StepID == step.FN_StepID)
                    {
                        item.FN_StepID = stepid;
                    }
                }
                step.FN_StepID = stepid;
                sql += string.Format(@"INSERT INTO [Flow_WorkStep]
                           ([FN_StepID]
                           ,[FN_PreStepID]
                           ,[FN_FlowID]
                           ,[FN_DefStepID]
                           ,[FN_DefActionID]
                           ,[FN_SendID]
                           ,[FN_SendDate]
                           ,[FN_Index],[FN_IsCurrent])
                     VALUES
                           ('{0}',{1},'{2}',{3} ,{4},'{5}','{6}','{7}','{8}');",
                            step.FN_StepID,
                            step.FN_PreStepID,
                            model.FN_FlowID,
                            step.FN_DefStepID,
                            step.FN_DefActionID,
                            step.FN_SendID,
                            step.FN_SendDate,
                            step.FN_Index,
                            step.FN_IsCurrent);

            }
            sql = AddFlow_WorkUserSql(model, sql);
            return sql;
        }

        public DataSet GetSubWorkFlowByModel(FlowModels.Flow_WorkFlow model)
        {
            string sql = @"Select WorkStep.*,DefWorkstep.FN_StepName from 
                            (
                            select * from Flow_WorkStep where FN_FlowID=@FN_FlowID
                            )WorkStep
                            left join
                            (
                            select * from Flow_DefWorkstep
                            )DefWorkstep
                            on  WorkStep.FN_DefStepID=DefWorkstep.FN_StepID order by FN_Index;

                            SELECT W.*,U.FN_RealName FROM 
                            (
                            select * from Flow_WorkUser where  FN_StepID in(select FN_StepID from Flow_WorkStep WHERE FN_FlowID=@FN_FlowID)
                            )W left join
                            (
                            Select FN_ID,FN_RealName from Sys_User
                            )U on  W.FN_UserID=U.FN_ID";
            System.Data.SqlClient.SqlParameter[] parameters =
            { 
                DBHelper.MakeParameter("@FN_FlowID", SqlDbType.NVarChar, 250,model.FN_FlowID),
            };
            DataSet ds = DBHelper.Query(sql, parameters);
            return ds;
        }

        public bool ContinueAuditRecord(FlowModels.Flow_WorkAudit model, FlowModels.Flow_WorkStep step)
        {
            string sql = @"BEGIN TRY
                                SET XACT_ABORT ON;
                                BEGIN TRANSACTION;";
            #region SQL
            sql += string.Format(@"INSERT INTO [Flow_WorkAudit]
                           ([FN_StepID]
                           ,[FN_CheckerID]
                           ,[FN_CheckDate]
                           ,[FN_HandleView]
                           ,[FN_RevisionView])
                            VALUES
                            ('{0}',
                            '{1}',
                            '{2}',
                            '{3}',
                            '{4}');", model.FN_StepID, model.FN_CheckerID, model.FN_CheckDate, model.FN_HandleView, model.FN_RevisionView);

            sql += string.Format(@"UPDATE dbo.Flow_WorkUser SET FN_Pass='1' where FN_StepID='{0}' and FN_UserID='{1}';",
                                    model.FN_StepID,
                                    model.FN_CheckerID);

            sql += string.Format(@"Declare @index int,@nextdefstep nvarchar(500),@defstep nvarchar(500),@actionid nvarchar(500);
                            Select @index=FN_Index,@defstep=FN_StepID from Flow_DefWorkstep where FN_StepID=(Select FN_DefStepID from Flow_WorkStep where FN_StepID='{0}');
                            Select @nextdefstep=FN_StepID from Flow_DefWorkstep where FN_Index>@index and FN_StepType!='EndStep';
                            Select @actionid=FN_ActionID from dbo.Flow_DefWorkAction where FN_NextDefStepID=@nextdefstep and FN_DefStepID=@defstep;
                            if(@nextdefstep!='')
                            begin
                                UPDATE  Flow_WorkStep SET FN_IsCurrent='0' where FN_FlowID='{2}';
                                INSERT INTO [Flow_WorkStep]
                                    ([FN_StepID]
                                    ,[FN_PreStepID]
                                    ,[FN_FlowID]
                                    ,[FN_DefStepID]
                                    ,[FN_DefActionID]
                                    ,[FN_SendID]
                                    ,[FN_SendDate]
                                    ,[FN_Index]
                                    ,[FN_IsCurrent])
                                VALUES
                               ('{1}','{0}','{2}',@nextdefstep,@actionid,'{3}','{4}',@index,'1'); 
                            end
                            else if (Select count(*) from Flow_DefWorkstep where FN_Index>@index and FN_StepType='EndStep')=1
                            begin
                                Update   Flow_workflow set FN_FlowState=2 Where FN_FlowID='{2}';
                            end", model.FN_StepID, step.FN_StepID, step.FN_FlowID, step.FN_SendID, step.FN_SendDate);

            #endregion
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
            bool result = DBHelper.ExecuteSql(sql) > 0;

            if (result == true && step != null)
            {
                DataSet ds = new Flow_DefWorkStepService().GetSubDefWorkStepInfo("", step.FN_StepID, false);
                DataTable dt_role = ds.Tables["dt_role"];
                string roleText = string.Empty;
                string roleValue = string.Empty;
                sql = string.Empty;
                if (dt_role == null) return result;
                foreach (DataRow item in dt_role.Rows)
                {
                    sql += string.Format(@"INSERT INTO [Flow_WorkUser]
                                       ([FN_StepID]
                                       ,[FN_UserID]
                                       ,[FN_Pass]
                                       ,[FN_ActionID]
                                       ,[FN_Note])
                                    VALUES
                                      ('{0}','{1}',{2},{3},'{4}');",
                                       step.FN_StepID,
                                       item["FN_ID"].ToString(),
                                       "NULL", "(Select FN_DefActionID from Flow_workStep where FN_StepID='" + step.FN_StepID + "')", "");
                }
                result = DBHelper.ExecuteSql(sql) > 0;
            }
            return result;

        }

        public DataTable GetWorkAuditRecord(FlowModels.Flow_WorkFlow model)
        {
            string sql = string.Format(@" 
                           select A.FN_StepID,FN_CheckName ,FN_CheckDate,FN_HandleView,FN_RevisionView,FN_StepName from 
                          (
                              select * from Flow_workAudit where FN_StepID in (select FN_StepID from Flow_WorkStep where FN_FlowID='{0}')
                           )A 
                           left join
                           (
                            Select FN_ID,FN_RealName FN_CheckName from Sys_User
                           )U on  A.FN_CheckerID=U.FN_ID
                           left join
                           (
                            select FN_StepID,FN_DefStepID from Flow_WorkStep
                           )S on A.FN_StepID=S.FN_StepID
                           
                           left join
                           (
                            select FN_StepID,FN_StepName from Flow_DefWorkStep
                           )D on S.FN_DefStepID=D.FN_StepID order by FN_CheckDate;", model.FN_FlowID);
            return DBHelper.Query(sql).Tables[0];

        }

        public DataSet GetFlowPreData(string flowID, string defFlowID)
        {
            string sql = string.Format(@"Select FN_FlowXml from dbo.Flow_DefWorkFlow where FN_FlowID='{0}';
                                         Select FN_DefStepID,FN_IsCurrent from dbo.Flow_WorkStep 
                                        where  FN_FlowID='{1}';", defFlowID, flowID);
            return DBHelper.Query(sql);
        }

        public bool DeleteFormFlow(string formID, string flowID)
        {
            string sql = @"BEGIN TRY
                                SET XACT_ABORT ON;
                                BEGIN TRANSACTION;";
            #region sql语句
            sql += string.Format(@"DELETE FROM dbo.Flow_WorkAttach Where FN_FlowID='{0}' and  FN_FormID='{1}';
                                DELETE FROM dbo.Flow_WorkFlow   Where  FN_FlowID='{0}';
                                DELETE FROM dbo.Flow_WorkUser   WHERE FN_StepID in (select FN_StepID from dbo.Flow_WorkStep Where FN_FlowID='{0}');
                                DELETE FROM dbo.Flow_WorkAudit  WHERE FN_StepID in (select FN_StepID from dbo.Flow_WorkStep Where FN_FlowID='{0}');
                                DELETE FROM dbo.Flow_WorkStep   Where FN_FlowID='{0}';", flowID, formID);
            #endregion
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

        //退回修改
        public bool RefuseAuditRecord(FlowModels.Flow_WorkAudit model)
        {
            string sql = @"BEGIN TRY
                                SET XACT_ABORT ON;
                                BEGIN TRANSACTION;";
            #region SQL
            sql += string.Format(@"INSERT INTO [Flow_WorkAudit]
                           ([FN_StepID]
                           ,[FN_CheckerID]
                           ,[FN_CheckDate]
                           ,[FN_HandleView]
                           ,[FN_RevisionView]
                           ,[FN_BackNote])
                            VALUES
                            ('{0}',
                            '{1}',
                            '{2}',
                            '{3}',
                            '{4}',
                            '{5}');", model.FN_StepID, model.FN_CheckerID, model.FN_CheckDate, model.FN_HandleView, model.FN_RevisionView,model.FN_BackNote);

            sql += string.Format(@"Update dbo.Flow_WorkUser SET FN_Pass='3' where FN_StepID='{0}' and FN_UserID='{1}';
                                   Update dbo.Flow_WorkStep SET FN_IsCurrent='0' where FN_StepID='{0}';
                                   Declare @index int,@defstep nvarchar(500),@nextdefstep nvarchar(500);
                                   Select  @index=FN_Index,@defstep=FN_StepID from Flow_DefWorkstep where FN_StepID=(Select FN_DefStepID from Flow_WorkStep where FN_StepID='{0}');
                                   Select  @nextdefstep=fn_nextDefStepID from dbo.Flow_DefWorkAction where FN_NextDefStepID in (Select FN_StepID from Flow_DefWorkstep where FN_Index<@index) and FN_DefStepID=@defstep;
                                   Update  Flow_WorkStep SET FN_IsCurrent='1' where FN_DefStepID=@nextdefstep;", model.FN_StepID, model.FN_CheckerID);

            #endregion
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

        //修改完成
        public bool RefuseRecordFinish(FlowModels.Flow_WorkAudit model, FlowModels.Flow_WorkStep step)
        {
            string sql = @"BEGIN TRY
                                SET XACT_ABORT ON;
                                BEGIN TRANSACTION;";
            #region SQL
            sql += string.Format(@"Update dbo.Flow_WorkStep  set FN_IsCurrent='0' where FN_StepID='{0}';
                                   Update dbo.Flow_WorkUser  set FN_Pass='4' where FN_StepID='{0}';
                                   Declare @index nvarchar(500);
                                   Select  @index=Max(FN_Index) from dbo.Flow_WorkStep where FN_FlowID='{2}';
                                   Update  dbo.Flow_WorkAudit set  FN_RevisionView='{1}' where FN_StepID=(select FN_StepID from dbo.Flow_WorkStep where FN_FlowID='{2}' and FN_Index=@index);
                                   Update  dbo.Flow_WorkStep set FN_IsCurrent='1' where FN_StepID=(select FN_StepID from dbo.Flow_WorkStep where FN_FlowID='{2}' and FN_Index=@index);", model.FN_StepID, model.FN_RevisionView, step.FN_FlowID);
            #endregion
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

        public DataTable GetBackSubmitStep(FlowModels.Flow_WorkStep step)
        {
            string sql=string.Format(@"declare @defflowid nvarchar(300),@index int;
                                    select @defflowid=FN_DefFlowID,@index=Fn_index from dbo.Flow_DefWorkStep where FN_StepID=(select FN_DefStepID from flow_workstep where FN_StepID='{0}');
                                    select * from   dbo.Flow_DefWorkStep where FN_DefFlowID=@defflowid  and FN_Index!=0 and FN_Index!=1 and  FN_index<=@index", step.FN_StepID);
            return DBHelper.Query(sql).Tables[0];
        }

    }
}
