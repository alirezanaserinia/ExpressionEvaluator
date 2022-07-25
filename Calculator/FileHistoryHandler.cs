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


        public FileHistoryHandler(MathematicalExpression mathExpr)
        {
            FileName = "CalculatorLogger.txt";


        }

        public void HandleLog(MathematicalExpression mathExpr)
        {

        }
        public static void LogValidCalculation(string input, string result)
        {
            File.AppendAllText(FileName, String.Format("User valid calculation at {0} :\n", DateTime.Now));
            File.AppendAllText(FileName, input);
            File.AppendAllText(FileName, " = ");
            File.AppendAllText(FileName, result);
            File.AppendAllText(FileName, "\n\n");
        }

        public static void LogInvalidCalculation(string input, string errorMessage)
        {
            File.AppendAllText(FileName, String.Format("User invalid input at {0} :\n", DateTime.Now));
            File.AppendAllText(FileName, input);
            File.AppendAllText(FileName, "\nThe error message : ");
            File.AppendAllText(FileName, errorMessage);
            File.AppendAllText(FileName, "\n\n");
        }
    }
}
