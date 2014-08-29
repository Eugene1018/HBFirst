using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Configuration;

namespace FlowAccessDAL
{
    public class DBHelper
    {
        public DBHelper() { }
        /// <summary>
        /// 功能描述：打开数据库
        /// </summary>
        /// <returns></returns>
        public static OleDbConnection Getconn()
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data source=" + ConfigurationManager.ConnectionStrings["AccessDBConnectionString"].ConnectionString);
            if (conn.State.Equals(ConnectionState.Closed))
            {
                conn.Open();
            }
            return conn;

        }
        /// <summary>
        /// 功能描述：关闭数据库
        /// </summary>
        private static void closeConnection()
        {
            OleDbConnection conn = Getconn();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
            }
        }
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sql">sql语句</param>
        public static int ExecuteSql(string sql)
        {
            int i = 0;
            try
            {
                OleDbConnection conn = Getconn();
                OleDbCommand com = new OleDbCommand(sql, conn);
                i = com.ExecuteNonQuery();
                com.Dispose();
            }
            catch (Exception e)
            {
                i = 0;
                throw new Exception(e.Message);
            }
            finally
            {
                closeConnection();
            }
            return i;
        }
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sql">sql语句</param>
        public static int ExecuteSql(string sql, OleDbParameter[] param, CommandType cmdType)
        {
            int i = 0;
            try
            {
                OleDbConnection conn = Getconn();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.CommandType = cmdType;
                if (param != null)
                {
                    cmd.Parameters.AddRange(param);
                }
                i = cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                i = 0;
                throw new Exception(e.Message);
            }
            finally
            {
                closeConnection();
            }
            return i;
        }
        /// <summary>
        /// 功能描述：获取DATASET
        /// </summary>
        /// <param name="sql">输入参数：sql，查询的SQL语句</param>
        /// <returns>返回值：DataSet</returns>
        public static DataSet GetDataSet(string sql)
        {
            try
            {
                OleDbConnection conn = Getconn();
                OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp.Fill(ds, "ds");
                return ds;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                closeConnection();
            }
        }
        /// <summary>
        /// 功能描述：获取DATASET
        /// </summary>
        /// <param name="sql">输入参数：sql，查询的SQL语句</param>
        /// <param name="tableName">表名</param>
        /// <returns>返回值：DataSet</returns>
        public static DataSet GetDataSet(string sql, string tableName)
        {
            try
            {
                OleDbConnection conn = Getconn();
                OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp.Fill(ds, tableName);
                return ds;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                closeConnection();
            }
        }
        /// <summary>
        /// 功能描述：获取DATASET
        /// </summary>
        /// <param name="sql">输入参数：sql，查询的SQL语句</param>
        /// <param name="tableName">表名</param>
        /// <returns>返回值：DataSet</returns>
        public static DataSet GetDataSet(string sql, OleDbParameter[] param, string tableName)
        {
            try
            {
                OleDbConnection conn = Getconn();
                OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
                if (param != null)
                {
                    adp.SelectCommand.Parameters.AddRange(param);
                }
                DataSet ds = new DataSet();
                adp.Fill(ds, tableName);
                return ds;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                closeConnection();
            }
        }
        /// <summary>
        /// 得到单行单列数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetScalar(string sql)
        {
            try
            {
                OleDbConnection conn = Getconn();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.Open();
                object obj = cmd.ExecuteScalar();
                return obj;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                closeConnection();
            }

        }
        /// <summary>
        /// 功能描述：获取DATASET
        /// </summary>
        /// <param name="sql">输入参数：sql，查询的SQL语句</param>
        /// <returns>返回值：DataTable</returns>
        public static DataTable GetDataTable(string sql)
        {
            try
            {
                OleDbConnection conn = Getconn();
                OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                adp.Fill(dt, "dt");
                return dt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                closeConnection();
            }
        }
        public static OleDbDataReader GetReader(string sql)
        {
            OleDbConnection conn = Getconn();
            try
            {
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader dr = cmd.ExecuteReader();

                return dr;
            }
            catch (Exception e)
            {
                conn.Close();
                throw new Exception(e.Message);
            }
            finally
            {
            }
        }
        /// <summary>
        /// 功能描述：获取DATASET1
        /// </summary>
        /// <param name="sql">输入参数：sql，查询的SQL语句</param>
        /// <param name="tablename">指定表名</param>
        /// <returns>返回值：DataSet</returns>
        public static DataSet Select(string sql, string tablename)
        {
            try
            {
                OleDbConnection conn = Getconn();
                OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp.Fill(ds, tablename);
                return ds;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
            finally
            {
                closeConnection();
            }
        }
        /// <summary>
        /// 功能描述：获取某个字段
        /// </summary>
        /// <param name="sql">输入参数：sql，查询的SQL语句</param>
        /// <returns>返回值：FS</returns>
        public static string FindString(string sql)
        {
            try
            {
                OleDbConnection conn = Getconn();
                OleDbCommand com = new OleDbCommand(sql, conn);
                string fs = Convert.ToString(com.ExecuteScalar());
                return fs;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                closeConnection();
            }
        }
    }
}
