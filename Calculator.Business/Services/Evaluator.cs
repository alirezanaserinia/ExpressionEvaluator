using Calculator.Business.Interfaces;
using Calculator.Business.Utils;
using Calculator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Business.Services
{
    public class Evaluator
    {
        private readonly ILogger _logger;
        private readonly IHistory _history;

        private List<double> values;
        private List<char> operators;

        public Evaluator(ILogger logger, IHistory history)
        {
            _logger = logger;
            _history = history;
        }

        public string GetHistory()
        {
            return _history.GetHistory();
        }

        public double Calculate(Expression expression)
        {
            values = new List<double>(expression.Values);
            operators = new List<char>(expression.Operators);

            while (operators.Count > 0)
            {
                while (operators.IndexOf('*') != -1)
                {
                    applyProduct(operators.IndexOf('*'));
                }
                while (operators.IndexOf('/') != -1)
                {
                    applyDivide(operators.IndexOf('/'));
                }
                while (operators.IndexOf('-') != -1)
                {
                    applySubtract(operators.IndexOf('-'));
                }
                while (operators.IndexOf('+') != -1)
                {
                    applyAdd(operators.IndexOf('+'));
                }
            }
            double result = values[0];
            string infoLogMessage = LogUtils.GetInfoLogMessage(expression.InputExpression, result.ToString());
            _logger.Info(infoLogMessage);
            return result;
        }

        private void applyProduct(int operatorIndex)
        {
            int firstOperandIndex = operatorIndex;
            int secondOperandIndex = operatorIndex + 1;

            values[firstOperandIndex] = values[firstOperandIndex] * values[secondOperandIndex];
            values.RemoveAt(secondOperandIndex);

            operators.RemoveAt(operatorIndex);
        }

        private void applyDivide(int operatorIndex)
        {
            int firstOperandIndex = operatorIndex;
            int secondOperandIndex = operatorIndex + 1;

            values[firstOperandIndex] = values[firstOperandIndex] / values[secondOperandIndex];
            values.RemoveAt(secondOperandIndex);

            operators.RemoveAt(operatorIndex);
        }

        private void applyAdd(int operatorIndex)
        {
            int firstOperandIndex = operatorIndex;
            int secondOperandIndex = operatorIndex + 1;

            values[firstOperandIndex] = values[firstOperandIndex] + values[secondOperandIndex];
            values.RemoveAt(secondOperandIndex);

            operators.RemoveAt(operatorIndex);
        }

        private void applySubtract(int operatorIndex)
        {
            int firstOperandIndex = operatorIndex;
            int secondOperandIndex = operatorIndex + 1;

            values[firstOperandIndex] = values[firstOperandIndex] - values[secondOperandIndex];
            values.RemoveAt(secondOperandIndex);

            operators.RemoveAt(operatorIndex);
        }
    }
}
