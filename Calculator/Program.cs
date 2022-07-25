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
            int userOption = -1;
            double result = 0;

            while (true)
            {
                List<string> menuItems = new List<string>();
                menuItems.Add("Expression evaluator");
                menuItems.Add("History");
                menuItems.Add("Finish");

                Menu menu = new Menu(menuItems);
                /*Console.Write(menu.Show());*/

                input = Console.ReadLine();
                /*userOption = int.Parse(input);
                menu.ItemProvider(userOption);*/

                if (input == "HISTORY")
                {
                    Console.Write(File.ReadAllText("CalculatorLogger.txt"));
                }
                else if (input == "FINISH")
                    break;
                else
                {
                    MathematicalExpression expression = new MathematicalExpression(input);

                    if (expression.isValid)
                    {
                        Calculator calc = new Calculator();
                        result = calc.Calc(expression);

                    }

                    if (expression.isValid)
                    {
                        Console.WriteLine(result);
                        FileHistoryHandler.LogValidCalculation(input, result.ToString());
                    }
                    else
                    {
                        Console.WriteLine(expression.errorMessage);
                        FileHistoryHandler.LogInvalidCalculation(input, expression.errorMessage);
                    }
                }

            }
        }
    }
}
