using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator 
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Input the command you'd like to execute");
            string userCmd = Console.ReadLine().ToLower();
            Console.WriteLine("What is the first number you want to use?");
            int input1 = (int)Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("What is the second number you want to use?");
            int input2 = (int)Convert.ToInt64(Console.ReadLine());
            bool valid = true;
           
            Dictionary<string, Func<int,int,int>> number = new Dictionary<string, Func<int, int, int>>();

            number["add"] = (a, b) => a + b;
            number["subtract"] = (a, b) => a - b;
            number["multiply"] = (a, b) => a * b;
            number["divide"] = (a, b) => a / b;

            while (valid == true)
            {
                if (number.ContainsKey(userCmd))
                {
                    double result = number[userCmd](input1, input2);
                    Console.WriteLine(result);
                    valid = false;
                }
                else
                {
                    Console.WriteLine("Command not found. Please try again.");
                    userCmd = Console.ReadLine();
                }
            }

        }
    }
}
