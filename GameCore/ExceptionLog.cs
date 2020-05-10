using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GameLogger
{
    //运行错误日志
    public class ExceptionLog
    {
        #region 单例模式
        private static object _obj = new object();
        private static ExceptionLog _instance = null;
        public static ExceptionLog Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_obj)
                    {
                        if (_instance == null)
                        {
                            _instance = new ExceptionLog();
                        }
                    }
                }
                return _instance;
            }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        private ExceptionLog()
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }

            if (_logWriter == null)
            {
                _logWriter = new StreamWriter(_filePath, true);
                _logWriter.AutoFlush = true;
            }
        }
        #endregion

        private static string _directoryPath = Path.Combine(Application.StartupPath, @"log");
        private static string _filePath = Path.Combine(_directoryPath, @"Exception.log");
        private StreamWriter _logWriter = null;

        /// <summary>
        /// 是否开启写日志
        /// </summary>
        private bool _isOn = true;
        /// <summary>
        /// 是否开启写日志
        /// </summary>
        public bool IsOn
        {
            get
            {
                return _isOn;
            }
            set
            {
                _isOn = value;
            }
        }

        /// <summary>
        /// 写异常信息
        /// </summary>
        /// <param name="ex"></param>
        public void Write(Exception ex)
        {
            if (!_isOn)
            {
                return;
            }
            lock (_logWriter)
            {
                if (ex is System.Threading.ThreadAbortException)
                {
                    return;
                }
                _logWriter.WriteLine(DateTime.Now.ToString());
                _logWriter.WriteLine(ex.ToString());
            }
        }
        /// <summary>
        /// 写字符串
        /// </summary>
        /// <param name="str"></param>
        public void Write(string str)
        {
            if (!_isOn)
            {
                return;
            }
            lock (_logWriter)
            {
                _logWriter.WriteLine(DateTime.Now.ToString());
                _logWriter.WriteLine(str);
            }
        }

    }
}
