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
        #endregion

        /// <summary>
        /// 当前时间（分钟）
        /// </summary>
        private long CurrentTime = 0;
        /// <summary>
        /// 时间步进委托
        /// </summary>
        /// <param name="CurrentTime"></param>
        public delegate void GameTimeTick(long CurrentTime);
        /// <summary>
        /// 时间步进事件
        /// </summary>
        public event GameTimeTick timeTickEvent;

        /// <summary>
        /// 是否允许时间步进
        /// </summary>
        private bool isAllowTick = false;

        //时间控制
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (isAllowTick)
                {
                    CurrentTime++;
                    timeTickEvent(CurrentTime);
                    //Console.WriteLine("当前时间" + CurrentTime);
                }
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
            }            
        }
        /// <summary>
        /// 继续时间步进
        /// </summary>
        public void TimeContinue()
        {
            try
            {
                isAllowTick = true;
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
            }
        }
        /// <summary>
        /// 暂停时间步进
        /// </summary>
        public void TimeSuspend()
        {
            try
            {
                isAllowTick = false;
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
            }
        }
        /// <summary>
        /// 设置当前时间
        /// </summary>
        public void SetCurrentTime(long CurrentTime)
        {
            try
            {
                this.CurrentTime = CurrentTime;
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
            }
        }
        /// <summary>
        /// 获取当前时间
        /// </summary>
        /// <returns></returns>
        public long GetCurrentTime()
        {
            return this.CurrentTime;
        }

        /// <summary>
        /// 时间向后跳转到当天某时间
        /// </summary>
        public void JumpToCurrentDaysTime()
        {
            try
            {
                //TODO:

            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
            }
        }
        /// <summary>
        /// 增加时间
        /// </summary>
        public void TimeAppend(long time)
        {
            try
            {
                CurrentTime += time;
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
            }
        }
        /// <summary>
        /// 获取日期
        /// </summary>
        public int GetDate()
        {
            try
            {
                return (int)Math.Floor(CurrentTime / (float)1440);
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
                return -1;
            }
        }
        /// <summary>
        /// 获取日期字符串
        /// </summary>
        public string GetDateStr()
        {
            try
            {
                return "年" + "月" + "日";
            }
            catch (Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
                return "日期错误";
            }            
        }

    }
}
