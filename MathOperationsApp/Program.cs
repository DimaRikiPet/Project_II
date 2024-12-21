using System;

namespace MathOperationsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            History history = new History();
            string input;
            Console.WriteLine("Welcome to the Math Operations App!");
            Console.WriteLine("Enter your calculations (e.g., 2 + 2) or type 'history' to see past calculations or 'exit' to quit.");

            while (true)
            {
                Console.Write("> ");
                input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    break;
                }
                else if (input.ToLower() == "history")
                {
                    Console.WriteLine("Calculation History:");
                    history.ShowHistory();
                }
                else if (input.ToLower().StartsWith("cbrt "))
                {
                    try
                    {
                        double number = double.Parse(input.Substring(5));
                        var result = calculator.CubeRoot(number);
                        history.AddCalculation($"cbrt({number}) = {result}");
                        Console.WriteLine($"Result: {result}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else
                {
                    try
                    {
                        var result = EvaluateExpression(input);
                        history.AddCalculation($"{input} = {result}");
                        Console.WriteLine($"Result: {result}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }

            Console.WriteLine("Do you want to export the history to a TXT file? (yes/no)");
            if (Console.ReadLine().ToLower() == "yes")
            {
                Console.Write("Enter file path: ");
                string filePath = Console.ReadLine();
                history.ExportToTxt(filePath);
                Console.WriteLine("History exported successfully.");
            }
        }

        static double EvaluateExpression(string expression)
        {
            var parts = expression.Split(' ');
            if (parts.Length != 3)
                throw new FormatException("Invalid expression format. Use 'number operator number'.");

            double a = double.Parse(parts[0]);
            string op = parts[1];
            double b = double.Parse(parts[2]);

            switch (op)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a * b;
                case "/":
                    return a / b;
                default:
                    throw new InvalidOperationException("Invalid operator. Use +, -, *, or /.");
            }
        }
    }
}