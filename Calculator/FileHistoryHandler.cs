using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class FileHistoryHandler
    {
        public static string FileName = "CalculatorLogger.txt";
        private string UserInput;
        private string CalculationResult;
        private string ErrorMessage;

        public FileHistoryHandler(string userInput, string calcResult, string errorMesssage)
        {
            UserInput = userInput;
            CalculationResult = calcResult;
            ErrorMessage = errorMesssage;
        }

        public void LogValidCalculation()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append(String.Format("User valid calculation at {0} :\n", DateTime.Now));
            sbuf.Append(UserInput);
            sbuf.Append(" = ");
            sbuf.Append(CalculationResult);
            sbuf.Append("\n\n");

            Logger.Write(FileName, sbuf.ToString());
        }

        public void LogInvalidCalculation()
        {
            StringBuilder sbuf = new StringBuilder();
            sbuf.Append(String.Format("User invalid input at {0} :\n", DateTime.Now));
            sbuf.Append(UserInput);
            sbuf.Append("\nThe error message : ");
            sbuf.Append(ErrorMessage);
            sbuf.Append("\n\n");

            Logger.Write(FileName, sbuf.ToString());
        }

        public string GetLogs()
        {
            return Logger.Read(FileName);
        }
    }
}
