using Calculator.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class MathematicalExpression
    {
        private readonly string inputString;

        public List<double> values = new List<double>();
        public List<char> operators = new List<char>();

        public MathematicalExpression(string _inputString)
        {
            inputString = _inputString;
            IsValidMathematicalExpression(inputString);
        }

        public void IsValidMathematicalExpression(string input)
        {
            char[] input_chars = input.ToCharArray();

            if ((Char.IsDigit(input_chars[0])) && (Char.IsDigit(input_chars[^1])))
            {
                for (int i = 0; i < input_chars.Length - 1; i++)
                {
                    if ((input_chars[i] >= '0' && input_chars[i] <= '9') || (input_chars[i] == '+' || input_chars[i] == '-' || input_chars[i] == '*' || input_chars[i] == '/'))
                    {
                        if (input_chars[i] >= '0' && input_chars[i] <= '9')
                        {
                            StringBuilder sbuf = new StringBuilder();
                            while (i < input_chars.Length && input_chars[i] >= '0' && input_chars[i] <= '9')
                            {
                                sbuf.Append(input_chars[i++]);
                            }
                            values.Add(int.Parse(sbuf.ToString()));
                            i--;
                        }
                        else if (input_chars[i] == '+' || input_chars[i] == '-' || input_chars[i] == '*' || input_chars[i] == '/')
                        {
                            if (Char.IsDigit(input_chars[i + 1]))
                            {
                                if (i + 1 == input_chars.Length - 1)
                                {
                                    values.Add(Char.GetNumericValue(input_chars[i + 1]));
                                }
                                if ((input_chars[i] == '/') && (input_chars[i + 1] == '0'))
                                {
                                    throw new Exceptions.DivideByZeroException("Divide by zero occurred!");
                                }
                                else
                                {
                                    if (input_chars[i] == '+')
                                        operators.Add('+');
                                    else if (input_chars[i] == '-')
                                        operators.Add('-');
                                    else if (input_chars[i] == '*')
                                        operators.Add('*');
                                    else if (input_chars[i] == '/')
                                        operators.Add('/');
                                }
                            }
                            else
                            {
                                throw new ConsecutiveOperatorsException("Two consecutive operators can't be in the expression!");
                            }
                        }
                    }
                    else
                    {
                        throw new InvalidCharacterException("Invalid character was found in the expression!");
                    }
                }
            }
            else
            {
                if (!Char.IsDigit(input_chars[0]))
                {
                    throw new StartWithOperatorException("Expression must be started with number!");
                }
                else if (!Char.IsDigit(input_chars[^1]))
                {
                    throw new EndWithOperatorException("Expression must be finished with number!");
                }
            }
        }




    }
}
