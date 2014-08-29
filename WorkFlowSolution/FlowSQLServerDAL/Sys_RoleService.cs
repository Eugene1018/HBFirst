using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowModels;
using System.Data;

namespace FlowSQLServerDAL
{
    class Sys_RoleService : FlowIDAL.ISys_RoleService
    {
        public bool InsertRole(FlowModels.Sys_RoleModule model)
        {
            string sql = @"BEGIN TRY
                                SET XACT_ABORT ON;
                                BEGIN TRANSACTION;";
            #region SQL
            sql += @"INSERT INTO [dbo].[Sys_Role]
                        ([FN_ID],
                         [FN_RoleName],
                         [FN_Remark])
                     VALUES
                        (@FN_ID,
                         @FN_RoleName, 
                         @FN_Remark);
                     ";
            System.Data.SqlClient.SqlParameter[] paramaters = 
             { 
                DBHelper.MakeParameter("@FN_ID", SqlDbType.NVarChar, 300, model.List_Roles[0].FN_ID),
                DBHelper.MakeParameter("@FN_RoleName", SqlDbType.NVarChar, 300, model.List_Roles[0].FN_RoleName),
                DBHelper.MakeParameter("@FN_Remark", SqlDbType.NVarChar, 300, model.List_Roles[0].FN_Remark),
             };
            foreach (Sys_Module item in model.List_Modules)
            {
                sql += @"INSERT   INTO dbo.Sys_RoleModule values (newid(),'" + model.List_Roles[0].FN_ID + "','" + item.FN_ID + "');";
            }
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

            return DBHelper.ExecuteSql(sql, paramaters) > 0;
        }

        public bool DeleteRole(FlowModels.Sys_Role model)
        {
            string sql = @"BEGIN TRY
                                SET XACT_ABORT ON;
                                BEGIN TRANSACTION;";
            #region SQL
            sql += @"DELETE   FROM dbo.Sys_Role WHERE FN_ID=@RoleID;
                     DELETE   FROM dbo.Sys_RoleModule WHERE FN_RoleID=@RoleID;";
            System.Data.SqlClient.SqlParameter[] paramaters = 
            { 
               DBHelper.MakeParameter("@RoleID", SqlDbType.NVarChar, 300, model.FN_ID),
            };

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

            return DBHelper.ExecuteSql(sql, paramaters) > 0;
        }

        public bool UpdateRole(FlowModels.Sys_RoleModule model)
        {
            string sql = @"BEGIN TRY
                                SET XACT_ABORT ON;
                                BEGIN TRANSACTION;";
            #region SQL
            sql += @"UPDATE   dbo.Sys_Role SET FN_RoleName=@RoleName,FN_Remark=@Remark WHERE FN_ID=@RoleID;
                     DELETE   FROM dbo.Sys_RoleModule WHERE FN_RoleID=@RoleID;";
            System.Data.SqlClient.SqlParameter[] paramaters = 
             { 
                DBHelper.MakeParameter("@RoleID", SqlDbType.NVarChar, 300, model.List_Roles[0].FN_ID),
                DBHelper.MakeParameter("@RoleName", SqlDbType.NVarChar, 300, model.List_Roles[0].FN_RoleName),
                DBHelper.MakeParameter("@Remark", SqlDbType.NVarChar, 300, model.List_Roles[0].FN_Remark),
             };
            foreach (Sys_Module item in model.List_Modules)
            {
                sql += @"INSERT   INTO dbo.Sys_RoleModule values (newid(),'" + model.List_Roles[0].FN_ID + "','" + item.FN_ID + "');";
            }

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

            return DBHelper.ExecuteSql(sql, paramaters) > 0;
        }

        public List<FlowModels.Sys_Role> GetSubRoleByModel(FlowModels.Sys_Role model)
        {
            string sql = "select * from Sys_Role where FN_ID like @ID and FN_RoleName like @RoleName";
            System.Data.SqlClient.SqlParameter[] parameters =
            { 
                DBHelper.MakeParameter("@ID", SqlDbType.NVarChar, 250, "%" +(model==null?"": model.FN_ID) + "%"),
                DBHelper.MakeParameter("@RoleName", SqlDbType.NVarChar, 250, "%" +(model==null?"": model.FN_RoleName) + "%")
            };
            List<Sys_Role> list = new List<Sys_Role>();
            Sys_Role role = null;
            foreach (DataRow item in DBHelper.Query(sql, parameters).Tables[0].Rows)
            {
                role = new Sys_Role()
                {
                    FN_ID = item["FN_ID"].ToString(),
                    FN_RoleName = item["FN_RoleName"].ToString(),
                    FN_Remark = item["FN_Remark"].ToString()
                };

                list.Add(role);
            }
            return list;
        }

        public Sys_RoleModule GetSubRoleModuleByModel(FlowModels.Sys_Role model)
        {
            string sql = @"select R.*,M.* from 
                            (
                            select * from  dbo.Sys_RoleModule  where FN_RoleID like @RoleID 
                            )RM
                            right join
                            (
                            select FN_ID FN_RoleID,FN_RoleName,FN_Remark from dbo.Sys_Role  where FN_ID like @RoleID
                            )R on RM.FN_RoleID=R.FN_RoleID
                            left join
                            (
                            select FN_ID FN_ModuleID,FN_ParentID,FN_ModuleName from  dbo.Sys_Module
                            )M on RM.FN_ModuleID=M.FN_ModuleID";
            System.Data.SqlClient.SqlParameter[] parameters =
            { 
                DBHelper.MakeParameter("@RoleID", SqlDbType.NVarChar, 250, "%" +(model==null?"": model.FN_ID) + "%"),
            };
            List<Sys_RoleModule> list = new List<Sys_RoleModule>();
            Sys_RoleModule RoleModule = new Sys_RoleModule(); ;
            foreach (DataRow item in DBHelper.Query(sql, parameters).Tables[0].Rows)
            {
                RoleModule.List_Roles.Add(new Sys_Role() { FN_ID = item["FN_RoleID"].ToString(), FN_RoleName = item["FN_RoleName"].ToString(), FN_Remark = item["FN_Remark"].ToString() });
                RoleModule.List_Modules.Add(new Sys_Module() { FN_ID = item["FN_ModuleID"].ToString(), FN_ParentID = item["FN_ParentID"].ToString(), FN_ModuleName = item["FN_ModuleName"].ToString() });
            }
            return RoleModule;
        }
    }
}
