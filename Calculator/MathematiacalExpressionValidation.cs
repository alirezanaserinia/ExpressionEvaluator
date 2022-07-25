using Calculator.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class MathematiacalExpressionValidation
    {
        public MathematiacalExpressionValidation(string inputExpression)
        {
            IsValidMathematicalExpression(inputExpression);
        }

        public void IsValidMathematicalExpression(string inputExpr)
        {
            char[] input_chars = inputExpr.ToCharArray();
            if (!Char.IsDigit(input_chars[0]))
            {
                throw new StartWithOperatorException("Expression must be started with number!");
            }
            else if (!Char.IsDigit(input_chars[^1]))
            {
                throw new EndWithOperatorException("Expression must be finished with number!");
            }
            else
            {
                for (int i = 0; i < input_chars.Length - 1; i++)
                {
                    if ((input_chars[i] >= '0' && input_chars[i] <= '9') || (input_chars[i] == '+' || input_chars[i] == '-' || input_chars[i] == '*' || input_chars[i] == '/'))
                    {
                        if (input_chars[i] >= '0' && input_chars[i] <= '9')
                        {
                            continue;
                        }
                        else if (input_chars[i] == '+' || input_chars[i] == '-' || input_chars[i] == '*' || input_chars[i] == '/')
                        {
                            if (Char.IsDigit(input_chars[i + 1]))
                            {
                                if ((input_chars[i] == '/') && (input_chars[i + 1] == '0'))
                                {
                                    throw new Exceptions.DivideByZeroException("Divide by zero occurred!");
                                }
                                else
                                {
                                    continue;
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
        }
    }
}
