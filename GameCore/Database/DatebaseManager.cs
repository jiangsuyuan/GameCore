using System;
using System.Collections.Generic;
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



    }
}
