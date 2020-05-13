using System;
using System.Collections.Generic;
using System.Linq;
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


            Console.WriteLine("运行结束!");
            Console.ReadKey();
        }
        /// <summary>
        /// 时间变化
        /// </summary>
        /// <param name="CurrentTime"></param>
        private static void Instance_timeTickEvent(long CurrentTime)
        {
            throw new NotImplementedException();
        }
    }
}
