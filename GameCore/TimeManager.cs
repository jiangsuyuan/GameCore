using GameLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace GameCore
{
    /// <summary>
    /// 时间管理
    /// （一秒一分钟，一个月三十天，一年四个月，一百二十天。）
    /// </summary>
    public class TimeManager
    {
        #region 单例模式
        private static object _obj = new object();
        private static TimeManager _instance = null;
        public static TimeManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_obj)
                    {
                        if (_instance == null)
                        {
                            _instance = new TimeManager();
                        }
                    }
                }
                return _instance;
            }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        private TimeManager()
        {
            //每秒钟一次
            Timer timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();

        }

        private long CurrentTime = 0;

        #endregion

        //时间控制
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {

            }
            catch(Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
            }            
        }
        /// <summary>
        /// 继续时间步进
        /// </summary>
        public void TimeContinue()
        {

        }
        /// <summary>
        /// 暂停时间步进
        /// </summary>
        public void TimeSuspend()
        {

        }
        /// <summary>
        /// 设置当前时间
        /// </summary>
        public void SetCurrentTime()
        {

        }

        /// <summary>
        /// 时间向后跳转到当天某时间
        /// </summary>
        public void JumpToCurrentDaysTime()
        {

        }
        /// <summary>
        /// 增加时间
        /// </summary>
        public void TimeAppend()
        {

        }


    }
}
