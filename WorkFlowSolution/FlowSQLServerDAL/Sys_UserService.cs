using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using FlowModels;
using FlowIDAL;
namespace FlowSQLServerDAL
{
    public class Sys_UserService : ISys_UserService
    {

        // 检查登录用户
        public bool CheckLogin(Sys_User model)
        {
            string strSql = "select count(*) from Sys_User where FN_UserName=@UserName and FN_UserPwd=@UserPwd and FN_IsLock=0";
            #region 屏蔽不用
            //SqlParameter[] parameters = { new SqlParameter("@UserName", SqlDbType.NVarChar, 130), new SqlParameter("@UserPwd", SqlDbType.NVarChar, 150) };
            //parameters[0].Value = model.FN_UserName;
            //parameters[1].Value = model.FN_UserPwd;
            #endregion
            SqlParameter[] parameters = { DBHelper.MakeParameter("@UserName", SqlDbType.NVarChar, 230, model.FN_UserName), DBHelper.MakeParameter("@UserPwd", SqlDbType.NVarChar, 230, FlowCommon.DESEncrypt.Encrypt(model.FN_UserPwd)) };
            return DBHelper.Exists(strSql, parameters);
        }
        public bool InsertUser(Sys_User model)
        {
            string sql = @"BEGIN TRY
                                SET XACT_ABORT ON;
                                BEGIN TRANSACTION;";
            #region SQL
            sql += @"INSERT INTO [dbo].[Sys_User]
                           ([FN_ID]
                           ,[FN_RoleID]
                           ,[FN_UserName]
                           ,[FN_UserPwd]
                           ,[FN_RealName]
                           ,[FN_TelePhone]
                           ,[FN_Email]
                           ,[FN_IsLock]
                           ,[FN_CreateDate]
                          )
                     VALUES
                           (@FN_ID,
                           @FN_RoleID,
                           @FN_UserName,
                           @FN_UserPwd,
                           @FN_RealName,
                           @FN_TelePhone,
                           @FN_Email,
                           @FN_IsLock,
                           getdate());";
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
            SqlParameter[] paramaters = 
               {
                   DBHelper.MakeParameter("@FN_ID",SqlDbType.NVarChar,450,model.FN_ID),
                   DBHelper.MakeParameter("@FN_RoleID",SqlDbType.NVarChar,450,model.FN_RoleID),
                   DBHelper.MakeParameter("@FN_UserName",SqlDbType.NVarChar,450,model.FN_UserName),
                   DBHelper.MakeParameter("@FN_UserPwd",SqlDbType.NVarChar,450,FlowCommon.DESEncrypt.Encrypt(model.FN_UserPwd)),
                   DBHelper.MakeParameter("@FN_RealName",SqlDbType.NVarChar,450,model.FN_RealName),
                   DBHelper.MakeParameter("@FN_TelePhone",SqlDbType.NVarChar,450,model.FN_TelePhone),
                   DBHelper.MakeParameter("@FN_Email",SqlDbType.NVarChar,450,model.FN_Email),
                   DBHelper.MakeParameter("@FN_IsLock",SqlDbType.NVarChar,450,model.FN_IsLock),
               };
            return DBHelper.ExecuteSql(sql, paramaters) > 0;
        }

        public bool DeleteUser(Sys_User model)
        {
            string sql = @"BEGIN TRY
                                SET XACT_ABORT ON;
                                BEGIN TRANSACTION;";
            #region SQL
            sql += @"DELETE FROM  [dbo].[Sys_User] WHERE  FN_ID=@FN_ID;";
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

        public bool UpdateUser(Sys_User model)
        {
            string sql = @"BEGIN TRY
                                SET XACT_ABORT ON;
                                BEGIN TRANSACTION;";
            #region SQL
            sql += @"UPDATE [dbo].[Sys_User]
                      SET  [FN_RoleID] = @FN_RoleID, 
                           [FN_UserPwd] = @FN_UserPwd, 
                           [FN_RealName] = @FN_RealName, 
                           [FN_TelePhone] = @FN_TelePhone, 
                           [FN_Email] = @FN_Email, 
                           [FN_IsLock] = @FN_IsLock    
                     WHERE [FN_ID] = @FN_ID;";
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
            SqlParameter[] paramaters = 
               {
                   DBHelper.MakeParameter("@FN_ID",SqlDbType.NVarChar,450,model.FN_ID),
                   DBHelper.MakeParameter("@FN_RoleID",SqlDbType.NVarChar,450,model.FN_RoleID),
                   DBHelper.MakeParameter("@FN_UserPwd",SqlDbType.NVarChar,450,FlowCommon.DESEncrypt.Encrypt(model.FN_UserPwd)),
                   DBHelper.MakeParameter("@FN_RealName",SqlDbType.NVarChar,450,model.FN_RealName),
                   DBHelper.MakeParameter("@FN_TelePhone",SqlDbType.NVarChar,450,model.FN_TelePhone),
                   DBHelper.MakeParameter("@FN_Email",SqlDbType.NVarChar,450,model.FN_Email),
                   DBHelper.MakeParameter("@FN_IsLock",SqlDbType.NVarChar,450,model.FN_IsLock),
               };
            return DBHelper.ExecuteSql(sql, paramaters) > 0;
        }

        public List<Sys_User> GetAllUsers(params string[] sql)
        {
            DataTable dataTable = null;
            Sys_User User = null;
            List<Sys_User> list = new List<Sys_User>();
            if (sql != null && sql.Length > 0)
            {
                dataTable = DBHelper.Query(sql[0]).Tables[0];
                foreach (DataRow item in dataTable.Rows)
                {
                    User = new Sys_User();
                    User.FN_ID = item["FN_ID"].ToString();
                    list.Add(User);
                }
            }
            else
            {
                dataTable = DBHelper.Query(@"select U.*,R.FN_RoleName,FN_Remark from 
                                            (
                                            select row_number() over (order by fn_id) 序号,* from  dbo.Sys_User
                                            )U
                                            left join
                                            (
                                            select * from Sys_Role
                                            )R
                                            on U.FN_RoleID=R.FN_ID").Tables[0];
                foreach (DataRow item in dataTable.Rows)
                {
                    User = new Sys_User();
                    User.FN_ID = item["FN_ID"].ToString();
                    User.FN_UserName = item["FN_UserName"].ToString();
                    User.FN_UserPwd = FlowCommon.DESEncrypt.Decrypt(item["FN_UserPwd"].ToString());
                    User.FN_TelePhone = item["FN_TelePhone"].ToString();
                    User.FN_RoleID = item["FN_RoleID"].ToString();
                    User.FN_Email = item["FN_Email"].ToString();
                    User.FN_CreateDate = item["FN_CreateDate"].ToString();
                    User.FN_RealName = item["FN_RealName"].ToString();
                    User.FN_IsLock = item["FN_IsLock"].ToString();
                    User.Role = new Sys_Role()
                    {
                        FN_ID = item["FN_RoleID"].ToString(),
                        FN_RoleName = item["FN_RoleName"].ToString(),
                        FN_Remark = item["FN_Remark"].ToString()
                    };
                    list.Add(User);
                }

            }
            return list;
        }

        public List<Sys_User> GetSubUserByModel(Sys_User model)
        {
            string sql = string.Format(@"select U.*,R.FN_RoleName,FN_Remark from 
                                    (
                                    select * from dbo.Sys_User where FN_ID like @ID and FN_UserName like @UserName and FN_IsLock like @IsLock and FN_RoleID like @RoleID
                                    )U
                                    left join
                                    (
                                    select * from Sys_Role
                                    )R
                                    on U.FN_RoleID=R.FN_ID");
            SqlParameter[] parameters = 
            { 
                DBHelper.MakeParameter("@ID", SqlDbType.NVarChar, 250, "%" + model.FN_ID + "%"),
                DBHelper.MakeParameter("@UserName", SqlDbType.NVarChar, 250, "%" + model.FN_UserName + "%"),
                DBHelper.MakeParameter("@IsLock", SqlDbType.NVarChar, 250, "%" + model.FN_IsLock + "%"),
                DBHelper.MakeParameter("@RoleID", SqlDbType.NVarChar, 250, "%" + model.FN_RoleID + "%")
            };
            DataTable dt = DBHelper.Query(sql, parameters).Tables[0];
            List<Sys_User> list = new List<Sys_User>();
            Sys_User User = null;
            foreach (DataRow item in dt.Rows)
            {
                User = new Sys_User();
                User.FN_ID = item["FN_ID"].ToString();
                User.FN_RoleID = item["FN_RoleID"].ToString();
                User.FN_UserName = item["FN_UserName"].ToString();
                User.FN_UserPwd = FlowCommon.DESEncrypt.Decrypt(item["FN_UserPwd"].ToString());
                User.FN_RealName = item["FN_RealName"].ToString();
                User.FN_TelePhone = item["FN_TelePhone"].ToString();
                User.FN_Email = item["FN_Email"].ToString();
                User.FN_IsLock = item["FN_IsLock"].ToString();
                User.FN_CreateDate = item["FN_CreateDate"].ToString();
                User.Role = new Sys_Role()
                {
                    FN_ID = item["FN_RoleID"].ToString(),
                    FN_RoleName = item["FN_RoleName"].ToString(),
                    FN_Remark = item["FN_Remark"].ToString()
                };
                list.Add(User);
            }
            return list;
        }
    }
}
