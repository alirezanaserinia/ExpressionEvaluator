using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public static class Logger
    {
        public static void Write(string logFileName, string context)
        {
            File.AppendAllText(logFileName, context);
        }

        public static string Read(string logFileName)
        {
            return File.ReadAllText(logFileName);
        }
    }
}
