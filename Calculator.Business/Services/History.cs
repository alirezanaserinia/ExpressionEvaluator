using Calculator.Business.Interfaces;
using Calculator.Business.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Business.Services
{
    public class History : IHistory
    {
        public string GetHistory()
        {
            string infos = GetInfos();
            string errors = GetErrors();
            string history = infos + errors;
            return history;
        }

        private string GetInfos()
        {
            string[] infoLines = File.ReadAllLines(LogUtils.LOG_INFO_FILE_NAME);
            StringBuilder infos = new StringBuilder();
            infos.Append("Infos :\n");
            foreach (string info in infoLines)
            {
                infos.Append("\t" + info + "\n");
            }
            infos.Append("\n");
            return infos.ToString();
        }

        private string GetErrors()
        {
            string[] errorLines = File.ReadAllLines(LogUtils.LOG_ERROR_FILE_NAME);
            StringBuilder errors = new StringBuilder();
            errors.Append("Errors :\n");
            foreach (string error in errorLines)
            {
                errors.Append("\t" + error + "\n");
            }
            errors.Append("\n");
            return errors.ToString();
        }

    }
}
