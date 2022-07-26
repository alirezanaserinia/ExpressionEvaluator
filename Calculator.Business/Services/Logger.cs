using Calculator.Business.Interfaces;
using Calculator.Business.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Business.Services
{
    public class Logger : ILogger
    {
        public void Info(string info)
        {
            File.AppendAllText(LogUtils.LOG_INFO_FILE_NAME, info);
        }

        public void Error(string error)
        {
            File.AppendAllText(LogUtils.LOG_ERROR_FILE_NAME, error);
        }

    }
}
