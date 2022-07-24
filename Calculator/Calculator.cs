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

        /*
        public double Calculate(string expression)
        {
            char[] expArr = expression.ToCharArray();
            Stack<int> operandsStack = new Stack<int>();
            Stack<char> operatorsStack = new Stack<char>();

            for (int i = 0; i < expArr.Length; i++)
            {

                if (expArr[i] >= '0' && expArr[i] <= '9')
                {
                    StringBuilder sbuf = new StringBuilder();
                    while (i < expArr.Length && expArr[i] >= '0' && expArr[i] <= '9')
                    {
                        sbuf.Append(expArr[i++]);
                    }
                    operandsStack.Push(int.Parse(sbuf.ToString()));
                    i--;
                }

                else if (expArr[i] == '+' || expArr[i] == '-' || expArr[i] == '*' || expArr[i] == '/')
                {
                    while (operatorsStack.Count > 0 && hasPriority(expArr[i], operatorsStack.Peek()))
                    {
                        operandsStack.Push(applyOperation(operatorsStack.Pop(), operandsStack.Pop(), operandsStack.Pop()));
                    }
                    operatorsStack.Push(expArr[i]);
                }
            }

            while (operatorsStack.Count > 0)
                operandsStack.Push(applyOperation(operatorsStack.Pop(), operandsStack.Pop(), operandsStack.Pop()));

            return operandsStack.Pop();
        }

        public static bool hasPriority(char op1, char op2)
        {
            if ((op1 == '*' || op1 == '/') && (op2 == '+' || op2 == '-'))
                return false;
            else
                return true;
        }

        public static int applyOperation(char op, int b, int a)
        {
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    return a / b;
            }
            return 0;
        }

        */




    }
}
