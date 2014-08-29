using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowModels;
using System.Data;
using System.Data.SqlClient;

namespace FlowSQLServerDAL
{
    public class Sys_ModuleService:FlowIDAL.ISys_ModuleService
    {
        public bool InsertModule(FlowModels.Sys_Module model)
        {
            string sql = @"BEGIN TRY
                                SET XACT_ABORT ON;
                                BEGIN TRANSACTION;";
            #region SQL
            sql += @"INSERT INTO [dbo].[Sys_Module]
                       ([FN_ID]
                       ,[FN_ParentID]
                       ,[FN_ModuleName]
                       ,[FN_ModuleUrl]
                       ,[FN_Order]
                       ,[FN_Remark])
                 VALUES
                       (@FN_ID, 
                        @FN_ParentID, 
                        @FN_ModuleName,
                        @FN_ModuleUrl,
                        @FN_Order,
                        @FN_Remark);";
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
            System.Data.SqlClient.SqlParameter[] paramaters = 
               {
                   DBHelper.MakeParameter("@FN_ID",SqlDbType.NVarChar,450,model.FN_ID),
                   DBHelper.MakeParameter("@FN_ParentID",SqlDbType.NVarChar,450,model.FN_ParentID),
                   DBHelper.MakeParameter("@FN_ModuleName",SqlDbType.NVarChar,450,model.FN_ModuleName),
                   DBHelper.MakeParameter("@FN_ModuleUrl",SqlDbType.NVarChar,450,model.FN_ModuleUrl),
                   DBHelper.MakeParameter("@FN_Order",SqlDbType.NVarChar,450,model.FN_Order),
                   DBHelper.MakeParameter("@FN_Remark",SqlDbType.NVarChar,450,model.FN_Remark),
               };
            return DBHelper.ExecuteSql(sql, paramaters) > 0;
        }

        public bool DeleteModule(FlowModels.Sys_Module model)
        {
            string sql = @"BEGIN TRY
                                SET XACT_ABORT ON;
                                BEGIN TRANSACTION;";
            #region SQL
            sql += @"DECLARE @ParentID varchar(100);
                    SELECT @ParentID=FN_ParentID from  dbo.Sys_Module where FN_ID=@FN_ID
                    DELETE FROM  dbo.Sys_Module where FN_ID=@FN_ID;
                    DELETE FROM  dbo.Sys_RoleModule where FN_ModuleID=@FN_ID;
                    IF (select count(-1) from   dbo.Sys_Module where FN_ParentID=@ParentID)=0
                    BEGIN
                    DELETE FROM  dbo.Sys_Module where FN_ID=@ParentID;
                    DELETE FROM  dbo.Sys_RoleModule where FN_ModuleID=@ParentID;
                    END;";
            
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
            SqlParameter[] paramaters = { DBHelper.MakeParameter("@FN_ID", SqlDbType.NVarChar, 450, model.FN_ID) };
            return DBHelper.ExecuteSql(sql, paramaters) > 0;
        }

        public bool UpdateModule(FlowModels.Sys_Module model)
        {
            string sql = @"BEGIN TRY
                                SET XACT_ABORT ON;
                                BEGIN TRANSACTION;";
            #region SQL
            sql += @"UPDATE [dbo].[Sys_Module]
                       SET [FN_ParentID] = @FN_ParentID,
                           [FN_ModuleName] = @FN_ModuleName, 
                           [FN_ModuleUrl] = @FN_ModuleUrl, 
                           [FN_Order] = @FN_Order,
                           [FN_Remark] = @FN_Remark
                     WHERE [FN_ID]=@FN_ID;";
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
             System.Data.SqlClient.SqlParameter[] paramaters = 
               {
                   DBHelper.MakeParameter("@FN_ID",SqlDbType.NVarChar,450,model.FN_ID),
                   DBHelper.MakeParameter("@FN_ParentID",SqlDbType.NVarChar,450,model.FN_ParentID),
                   DBHelper.MakeParameter("@FN_ModuleName",SqlDbType.NVarChar,450,model.FN_ModuleName),
                   DBHelper.MakeParameter("@FN_ModuleUrl",SqlDbType.NVarChar,450,model.FN_ModuleUrl),
                   DBHelper.MakeParameter("@FN_Order",SqlDbType.NVarChar,450,model.FN_Order),
                   DBHelper.MakeParameter("@FN_Remark",SqlDbType.NVarChar,450,model.FN_Remark),
               };
            return DBHelper.ExecuteSql(sql, paramaters) > 0;
        }

        public List<FlowModels.Sys_Module> GetSubModuleByModel(FlowModels.Sys_Module model)
        {
            string sql = "select * from Sys_Module  where FN_ID like @FN_ID and FN_ParentID like @FN_ParentID and FN_ModuleName like @FN_ModuleName order by FN_Order,FN_ParentID;";
            System.Data.SqlClient.SqlParameter[] parameters =
            { 
                DBHelper.MakeParameter("@FN_ID", SqlDbType.NVarChar, 250, "%" +(model==null?"": model.FN_ID) + "%"),
                DBHelper.MakeParameter("@FN_ParentID", SqlDbType.NVarChar, 250, "%" +(model==null?"": model.FN_ParentID) + "%"),
                DBHelper.MakeParameter("@FN_ModuleName", SqlDbType.NVarChar, 250, "%" +(model==null?"": model.FN_ModuleName) + "%")
            };
            List<Sys_Module> list = new List<Sys_Module>();
            Sys_Module module = null;
            foreach (DataRow item in DBHelper.Query(sql,parameters).Tables[0].Rows)
            {
                module = new Sys_Module();
                module.FN_ID = item["FN_ID"].ToString();
                module.FN_ParentID = item["FN_ParentID"].ToString();
                module.FN_ModuleName = item["FN_ModuleName"].ToString();
                module.FN_ModuleUrl = item["FN_ModuleUrl"].ToString();
                module.FN_Order = item["FN_Order"].ToString();
                module.FN_Remark = item["FN_Remark"].ToString();
                list.Add(module);
            }
            return list;
        }

        public List<FlowModels.Sys_Module> GetSubModuleByRole(FlowModels.Sys_Role model)
        {
            string sql = "SELECT  * FROM SYS_MODULE WHERE FN_ID IN (SELECT  FN_MODULEID FROM SYS_ROLEMODULE WHERE FN_ROLEID=@FN_ROLEID) ORDER BY FN_ORDER;";
            System.Data.SqlClient.SqlParameter[] parameters =
            { 
                DBHelper.MakeParameter("@FN_ROLEID", SqlDbType.NVarChar, 250,model.FN_ID),
            };
            List<Sys_Module> list = new List<Sys_Module>();
            Sys_Module module = null;
            foreach (DataRow item in DBHelper.Query(sql, parameters).Tables[0].Rows)
            {
                module = new Sys_Module();
                module.FN_ID = item["FN_ID"].ToString();
                module.FN_ParentID = item["FN_ParentID"].ToString();
                module.FN_ModuleName = item["FN_ModuleName"].ToString();
                module.FN_ModuleUrl = item["FN_ModuleUrl"].ToString();
                module.FN_Order = item["FN_Order"].ToString();
                module.FN_Remark = item["FN_Remark"].ToString();
                list.Add(module);
            }
            return list;
        }
    }
}
