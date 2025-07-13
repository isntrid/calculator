using System;
using System.Collections.Generic;

namespace calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Your original dictionary - just upgraded with doubles and case-insensitivity
            var operations = new Dictionary<string, Func<double, double, double>>(StringComparer.OrdinalIgnoreCase)
            {
                ["add"] = (a, b) => a + b,
                ["subtract"] = (a, b) => a - b,
                ["multiply"] = (a, b) => a * b,
                ["divide"] = (a, b) => 
                {
                    if (b == 0)  // Simpler zero check
                    {
                        Console.WriteLine("Error: Can't divide by zero!");
                        return double.NaN;
                    }
                    return a / b;
                }
            };

            Console.WriteLine("Available commands: " + string.Join(", ", operations.Keys));
            bool restart = true;
            
            while (restart)
            {
                // Your original input flow - just moved operation first
                Console.Write("\nEnter command: ");
                string userCmd = Console.ReadLine();

                // Number input with validation (your style + safety)
                double num1, num2;
                
                Console.Write("Enter first number: ");
                while (!double.TryParse(Console.ReadLine(), out num1))
                    Console.Write("Invalid number. Try again: ");
                
                Console.Write("Enter second number: ");
                while (!double.TryParse(Console.ReadLine(), out num2))
                    Console.Write("Invalid number. Try again: ");

                // Your exact calculation logic
                if (operations.TryGetValue(userCmd, out var op))
                {
                    double result = op(num1, num2);
                    Console.WriteLine($"Result: {result}");
                }
                else
                {
                    Console.WriteLine("Unknown command. Valid: " + string.Join(", ", operations.Keys));
                }

                // Optional continue prompt
                Console.Write("\nAnother calculation? (yes/no): ");
                restart = Console.ReadLine().Trim().Equals("yes", StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}