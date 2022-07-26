using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Business.Utils
{
    public static class LogUtils
    {
        internal const string LOG_INFO_FILE_NAME = "CalculatorLogger_Info.txt";
        internal const string LOG_ERROR_FILE_NAME = "CalculatorLogger_Error.txt";
        public static string GetInfoLogMessage(string userInput, string calculationResult)
        {
            StringBuilder message = new StringBuilder();
            message.Append(String.Format("User valid input at {0} :\n", DateTime.Now));
            message.Append(userInput + " = " + calculationResult + "\n\n");

            return message.ToString();
        }

        public static string GetErrorLogMessage(string userInput, string errorMessage)
        {
            StringBuilder message = new StringBuilder();
            message.Append(String.Format("User invalid input at {0} :\n", DateTime.Now));
            message.Append(userInput + "\n");
            message.Append("The error message : " + errorMessage + "\n\n");

            return message.ToString();
        }
    }
}
