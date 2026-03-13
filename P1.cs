// See https://aka.ms/new-console-template for more information
using System;

namespace hands_on_prblm_week4_day4
{
    class Calculator
    {
        // Method for addition
        public int Add(int a, int b)
        {
            return a + b;
        }

        // Method for subtraction
        public int Subtract(int a, int b)
        {
            return a - b;
        }
    }

    internal class P1
    {
        static void Main(string[] args)
        {
            int num1, num2;

            Console.Write("Enter first number: ");
            num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            num2 = Convert.ToInt32(Console.ReadLine());

            Calculator calc = new Calculator();

            int addResult = calc.Add(num1, num2);
            int subResult = calc.Subtract(num1, num2);

            Console.WriteLine("Addition = " + addResult);
            Console.WriteLine("Subtraction = " + subResult);

            Console.ReadLine();
        }
    }
}
