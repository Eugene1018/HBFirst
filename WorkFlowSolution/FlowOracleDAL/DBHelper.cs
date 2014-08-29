using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;

namespace FlowOracleDAL
{
    public class DBHelper
    {
        private static string connString = ConfigurationManager.ConnectionStrings["OrcleConnectionString"].ConnectionString;
        /// <summary>
        /// 执行查询操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public static DataTable ExecuteSelect(string sql, OracleParameter[] param, string tableName)
        {
            OracleDataAdapter da = new OracleDataAdapter(sql, connString);
            DataTable dt = new DataTable(tableName);
            if (param != null)
            {
                da.SelectCommand.Parameters.AddRange(param);
            }
            da.Fill(dt);
            return dt;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public static bool ExecuteNonQuery(string sql, OracleParameter[] para)
        {
            OracleConnection conn = new OracleConnection(connString);
            OracleCommand cmd = new OracleCommand(sql, conn);
            if (para != null)
            {
                cmd.Parameters.AddRange(para);
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            return i > 0 ? true : false;
        }
    }
}
