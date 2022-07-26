using Calculator.Business.Interfaces;
using Calculator.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Business.Services
{
    public class ExpressionValidator : IExpressionValidator
    {
        public ExprValidationModel CheckExprValidation(string input)
        {
            if (StartWithoutNumber(input))
            {
                return new ExprValidationModel
                {
                    Success = false,
                    Message = "Expression must be started with number!"
                };
            }
            if (FinishWithoutNumber(input))
            {
                return new ExprValidationModel
                {
                    Success = false,
                    Message = "Expression must be finished with number!"
                };
            }
            if (HasInvalidCharacter(input))
            {
                return new ExprValidationModel
                {
                    Success = false,
                    Message = "Invalid character was found in the expression!"
                };
            }
            if (HasDivideByZero(input))
            {
                return new ExprValidationModel
                {
                    Success = false,
                    Message = "Divide by zero occurred!"
                };
            }
            if (HasConsecutiveOperators(input))
            {
                return new ExprValidationModel 
                { 
                    Success = false,
                    Message = "Consecutive operators can't be in the expression!"
                };
            }
            else
            {
                return new ExprValidationModel
                {
                    Success = true,
                    Message = "input expression is valid"
                };
            }
        }

        private bool StartWithoutNumber(string input)
        {
            char[] input_chars = input.ToCharArray();
            return !char.IsDigit(input_chars[0]);
        }

        private bool FinishWithoutNumber(string input)
        {
            char[] input_chars = input.ToCharArray();
            return !char.IsDigit(input_chars[^1]);
        }

        private bool HasInvalidCharacter(string input)
        {
            bool hasInvalidChar = false;
            char[] input_chars = input.ToCharArray();

            for (int i = 0; i < input_chars.Length - 1; i++)
            {
                if ((char.IsDigit(input_chars[i])) ||
                    (input_chars[i] == '+' || input_chars[i] == '-' || input_chars[i] == '*' || input_chars[i] == '/'))
                {
                    continue;
                }
                else
                {
                    hasInvalidChar = true;
                    break;
                }
            }
            return hasInvalidChar;
        }

        private bool HasDivideByZero(string input)
        {
            bool hasDivideByZero = false;
            char[] input_chars = input.ToCharArray();

            for (int i = 0; i < input_chars.Length - 1; i++)
            {
                if ((input_chars[i] == '/') && (input_chars[i + 1] == '0'))
                {
                    hasDivideByZero = true;
                    break;
                }
            }
            return hasDivideByZero;
        }

        private bool HasConsecutiveOperators(string input)
        {
            bool hasConsecutiveOperators = false;
            char[] input_chars = input.ToCharArray();

            for (int i = 0; i < input_chars.Length - 1; i++)
            {
                if (input_chars[i] == '+' || input_chars[i] == '-' || input_chars[i] == '*' || input_chars[i] == '/')
                {
                    if (input_chars[i + 1] == '+' || input_chars[i + 1] == '-' || input_chars[i + 1] == '*' || input_chars[i + 1] == '/')
                    {
                        hasConsecutiveOperators = true;
                        break;
                    }
                }
            }
            return hasConsecutiveOperators;
        }
    }
}
