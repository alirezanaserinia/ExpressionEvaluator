using Calculator;
using Calculator.Business.Services;
using Calculator.Business.Utils;
using Calculator.Domain;
using System;
using System.Data;


namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();
            History history = new History();
            ExpressionValidator validator = new ExpressionValidator();
            Evaluator calculator = new Evaluator(logger, history);

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "HISTORY")
                {
                    Console.Write(calculator.GetHistory());
                }
                else if (input == "FINISH")
                {
                    break;
                }
                else
                {
                    var isValid = validator.CheckExprValidation(input).Success;
                    var Message = validator.CheckExprValidation(input).Message;
                    if (isValid)
                    {
                        Expression expression = new Expression(input);
                        var result = calculator.Calculate(expression);
                        Console.WriteLine(result);
                    }
                    else
                    {
                        string errorLogMessage = LogUtils.GetErrorLogMessage(input, Message);
                        logger.Error(errorLogMessage);
                        Console.WriteLine(Message);
                    }
                }
            }
        }
    }
}
