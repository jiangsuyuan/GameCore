using GameLogger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.Database
{
    /// <summary>
    /// 数据库
    /// </summary>
    public class DatebaseManager
    {
        #region 单例模式
        private static object _obj = new object();
        private static DatebaseManager _instance = null;
        public static DatebaseManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_obj)
                    {
                        if (_instance == null)
                        {
                            _instance = new DatebaseManager();
                        }
                    }
                }
                return _instance;
            }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        private DatebaseManager()
        {

        }
        #endregion

        #region 连接与查询
        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string DataFilePath
        {
            get
            {
                return "";//ControlDataConfig.Instance.GetSQLiteConnectionString();
            }
        }

        /// <summary>
        /// 创建一个SQLite连接
        /// </summary>
        /// <param name="filePath">连接字符串</param>
        /// <returns>SQLite连接</returns>
        private static SQLiteConnection CreateSQLiteConnection()
        {
            SQLiteConnectionStringBuilder build = new SQLiteConnectionStringBuilder();
            build.DataSource = DataFilePath;
            SQLiteConnection conn = new SQLiteConnection(build.ToString());
            return conn;
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sqlString">sql语句</param>
        /// <returns>是否成功</returns>
        private static bool ExecutedSQL(string sqlString)
        {
            try
            {
                using (SQLiteConnection con = CreateSQLiteConnection())
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }

                    SQLiteCommand com = new SQLiteCommand(sqlString, con);
                    com.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
                return false;
            }
        }

        /// <summary>
        /// 执行select语句，并返回数据表
        /// </summary>
        /// <param name="sqlSeletedString">select语句</param>
        /// <returns>表</returns>
        private static DataTable GetDataTable(string sqlSeletedString)
        {
            try
            {
                using (SQLiteConnection con = CreateSQLiteConnection())
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    DataTable dt = new DataTable();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(sqlSeletedString, con);
                    da.Fill(dt);
                    con.Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
                return null;
            }
        }
        #endregion

        /// <summary>
        /// 创建数据表
        /// </summary>
        public void CreateTables()
        {
            try
            {
                //创建数据文件
                if(!File.Exists(DataFilePath))
                {
                    SQLiteConnection.CreateFile("XXXX.db");
                }


                //删除数据表

                string sql = "drop table if exists NPC";


                //创建数据表




            }
            catch(Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
            }
        }

    }
}
