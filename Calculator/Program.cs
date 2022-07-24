using Calculator;
using Calculator.Exceptions;
using System;
using System.Data;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string? input = "";
            bool isValid = true;
            double result = 0;
            string errorMessage = "";

            while (true)
            {
                input = Console.ReadLine();
                if (input == "HISTORY")
                {
                    Console.Write(File.ReadAllText("CalculatorLogger.txt"));
                }
                else if (input == "FINISH")
                    break;
                else
                {
                    try
                    {
                        MathematicalExpression expression = new MathematicalExpression(input);
                        isValid = true;

                        ////
                        Calculator calc = new Calculator();
                        result = calc.Calc(expression);

                    }
                    catch (StartWithOperatorException ex)
                    {
                        isValid = false;
                        errorMessage = ex.Message;
                        Console.WriteLine(ex.Message.ToString());
                    }
                    catch (EndWithOperatorException ex)
                    {
                        isValid = false;
                        errorMessage = ex.Message;
                        Console.WriteLine(ex.Message.ToString());
                    }
                    catch (InvalidCharacterException ex)
                    {
                        isValid = false;
                        errorMessage = ex.Message;
                        Console.WriteLine(ex.Message.ToString());
                    }
                    catch (Exceptions.DivideByZeroException ex)
                    {
                        isValid = false;
                        errorMessage = ex.Message;
                        Console.WriteLine(ex.Message.ToString());
                    }
                    catch (ConsecutiveOperatorsException ex)
                    {
                        isValid = false;
                        errorMessage = ex.Message;
                        Console.WriteLine(ex.Message.ToString());
                    }

                    if (isValid)
                    {
                        Console.WriteLine(result);
                        Logging.LogValidCalculation(input, result.ToString());
                    }
                    else
                    {
                        Logging.LogInvalidCalculation(input, errorMessage);
                    }
                }

            }
        }
    }
}
