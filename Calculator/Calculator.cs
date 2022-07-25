using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        private List<double> values;
        private List<char> operators;
        public Calculator()
        {

        }


        public double Calc(MathematicalExpression expr)
        {
            values = new List<double>(expr.values);
            operators = new List<char>(expr.operators);

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
                while (operators.IndexOf('+') != -1)
                {
                    applyAdd(operators.IndexOf('+'));
                }
                while (operators.IndexOf('-') != -1)
                {
                    applySubtract(operators.IndexOf('-'));
                }
            }
            return values[0];
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
