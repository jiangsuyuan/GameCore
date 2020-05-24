using GameCore.DataStructs;
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
    public class DatabaseManager
    {
        #region 单例模式
        private static object _obj = new object();
        private static DatabaseManager _instance = null;
        public static DatabaseManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_obj)
                    {
                        if (_instance == null)
                        {
                            _instance = new DatabaseManager();
                        }
                    }
                }
                return _instance;
            }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        private DatabaseManager()
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
                return "GameData.db";//ControlDataConfig.Instance.GetSQLiteConnectionString();
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
        public bool CreateTables()
        {
            try
            {
                //TODO:创建数据文件路径

                //创建数据文件
                if (!File.Exists(DataFilePath))
                {
                    SQLiteConnection.CreateFile(DataFilePath);
                }
                //删除数据表
                ExecutedSQL("drop table if exists NPC");
                ExecutedSQL("drop table if exists Story");
                ExecutedSQL("drop table if exists StoryTree");

                //创建数据表
                ExecutedSQL("create table NPC(id varchar(32) primary key, name varchar(32), sex varchar(2), description text)");
                ExecutedSQL("create table Story(id varchar(32) primary key, npcID varchar(32),storyName text, playerSex varchar(2), beginTime int, endTime int, beginFavorable int, endFavorable int, beginFavorableType int, endFavorableType int)");
                ExecutedSQL("create table StoryTree(id varchar(32) primary key, DialogueID varchar(32), parentID varchar(32), talkerID varchar(32), content text)");

                return true;
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
                return false;
            }
        }
        /// <summary>
        /// 插入NPC
        /// </summary>
        /// <param name="npc"></param>
        /// <returns></returns>
        public bool InsertNPC(NPC npc)
        {
            try
            {
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append("insert into NPC values('");
                sbSql.Append(npc.ID);
                sbSql.Append("','");
                sbSql.Append(npc.NPCName);
                sbSql.Append("','");
                sbSql.Append(npc.NPCSex);
                sbSql.Append("','");
                sbSql.Append(npc.description);
                sbSql.Append("')");

                return ExecutedSQL(sbSql.ToString());
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
                return false;
            }
        }
        /// <summary>
        /// 获取NPC列表
        /// </summary>
        /// <returns></returns>
        public List<NPC> GetNPCs()
        {
            List<NPC> result = new List<NPC>();
            try
            {
                string sql = "select * from NPC";

                DataTable dt = GetDataTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    NPC npc = new NPC();
                    npc.ID = dt.Rows[i]["id"].ToString();
                    npc.NPCName = dt.Rows[i]["name"] == null ? "" : dt.Rows[i]["name"].ToString();
                    npc.NPCSex = dt.Rows[i]["sex"] == null ? "男" : dt.Rows[i]["sex"].ToString();
                    npc.description = dt.Rows[i]["description"] == null ? "" : dt.Rows[i]["description"].ToString();
                    result.Add(npc);
                }
                return result;
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
                return result;
            }
        }
        /// <summary>
        /// 插入故事
        /// </summary>
        /// <param name="story"></param>
        public bool InsertStory(Story story)
        {
            try
            {
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append("insert into Story values('");
                sbSql.Append(story.ID);
                sbSql.Append("','");
                sbSql.Append(story.NPCID);
                sbSql.Append("','");
                sbSql.Append(story.storyName);
                sbSql.Append("','");
                sbSql.Append(story.playerSex);
                sbSql.Append("',");
                sbSql.Append(story.beginTime);
                sbSql.Append(",");
                sbSql.Append(story.endTime);
                sbSql.Append(",");
                sbSql.Append(story.beginFavorable);
                sbSql.Append(",");
                sbSql.Append(story.endFavorable);
                sbSql.Append(",");
                sbSql.Append(story.beginFavorableType);
                sbSql.Append(",");
                sbSql.Append(story.endFavorableType);
                sbSql.Append(")");

                return ExecutedSQL(sbSql.ToString());
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
                return false;
            }
        }
        /// <summary>
        /// 插入故事条目
        /// </summary>
        /// <param name="story"></param>
        public bool InsertStoryTree(StoryTree storyTree)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("insert into Story values('");
                sb.Append(storyTree.ID);
                sb.Append("','");
                sb.Append(storyTree.DialogueID);
                sb.Append("','");
                sb.Append(storyTree.parentID);
                sb.Append("','");
                sb.Append(storyTree.TalkerID);
                sb.Append("','");
                sb.Append(storyTree.Content);
                sb.Append("')");

                return ExecutedSQL(sb.ToString());
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
                return false;
            }
        }
        /// <summary>
        /// 根据ID获取对话列表
        /// </summary>
        /// <param name="npcID"></param>
        /// <returns></returns>
        public List<Story> GetStorysByID(string npcID)
        {
            List<Story> result = new List<Story>();
            try
            {
                string sql = "select * from story where npcID = '" + npcID + "'";

                DataTable dt = GetDataTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Story story = new Story();
                    story.ID = dt.Rows[i]["id"].ToString();
                    story.NPCID = dt.Rows[i]["npcID"] == null ? "" : dt.Rows[i]["npcID"].ToString();
                    story.storyName = dt.Rows[i]["storyName"] == null ? "" : dt.Rows[i]["storyName"].ToString();
                    story.beginTime = dt.Rows[i]["beginTime"] == null ? -1 : Convert.ToInt32(dt.Rows[i]["beginTime"]);
                    story.endTime = dt.Rows[i]["endTime"] == null ? -1 : Convert.ToInt32(dt.Rows[i]["endTime"]);
                    story.beginFavorable = dt.Rows[i]["beginFavorable"] == null ? -1 : Convert.ToInt32(dt.Rows[i]["beginFavorable"]);
                    story.endFavorable = dt.Rows[i]["endFavorable"] == null ? -1 : Convert.ToInt32(dt.Rows[i]["endFavorable"]);
                    story.beginFavorableType = dt.Rows[i]["beginFavorableType"] == null ? -1 : Convert.ToInt32(dt.Rows[i]["beginFavorableType"]);
                    story.endFavorableType = dt.Rows[i]["endFavorableType"] == null ? -1 : Convert.ToInt32(dt.Rows[i]["endFavorableType"]);
                    result.Add(story);
                }
                return result;
            }
            catch(Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
                return result;
            }
        }
    }
}