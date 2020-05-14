using GameLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCore
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            TimeManager.Instance.timeTickEvent += Instance_timeTickEvent;
            TimeManager.Instance.TimeContinue();

            Console.ReadKey();
            Console.WriteLine("运行结束!");
            
        }
        /// <summary>
        /// 时间变化
        /// </summary>
        /// <param name="CurrentTime"></param>
        private static void Instance_timeTickEvent(long CurrentTime)
        {
            try
            {
                Console.WriteLine("当前时间：" + TimeManager.Instance.GetCurrentTime());
            }
            catch(Exception ex)
            {
                ExceptionLog.Instance.Write(ex);
            }      
        }
    }
}
