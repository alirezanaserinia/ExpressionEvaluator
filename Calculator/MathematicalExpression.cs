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
        public string errorMessage;
        public bool isValid;

        public List<double> values = new List<double>();
        public List<char> operators = new List<char>();

        public MathematicalExpression(string _inputString)
        {
            inputString = _inputString;
            errorMessage = "";
            isValid = IsValid(inputString);
            SetValues();
            SetOperators();
        }

        public bool IsValid(string inputExpression)
        {
            bool isValid;
            try
            {
                MathematiacalExpressionValidation ExpressionValidation = new MathematiacalExpressionValidation(inputExpression);
                isValid = true;
                errorMessage = "No error";
            }
            catch (StartWithOperatorException ex)
            {
                isValid = false;
                errorMessage = ex.Message;
            }
            catch (EndWithOperatorException ex)
            {
                isValid = false;
                errorMessage = ex.Message;
            }
            catch (InvalidCharacterException ex)
            {
                isValid = false;
                errorMessage = ex.Message;
            }
            catch (Exceptions.DivideByZeroException ex)
            {
                isValid = false;
                errorMessage = ex.Message;
            }
            catch (ConsecutiveOperatorsException ex)
            {
                isValid = false;
                errorMessage = ex.Message;
            }
            return isValid;
        }

        public void SetValues()
        {
            if (isValid)
            {
                char[] input_chars = inputString.ToCharArray();
                for (int i = 0; i < input_chars.Length - 1; i++)
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
                        }
                    }
                }
            }
        }

        public void SetOperators()
        {
            if (isValid)
            {
                char[] input_chars = inputString.ToCharArray();
                for (int i = 0; i < input_chars.Length - 1; i++)
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
        }
    }
}
