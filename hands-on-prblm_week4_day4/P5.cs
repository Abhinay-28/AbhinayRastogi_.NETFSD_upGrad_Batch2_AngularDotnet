using System;

namespace hands_on_prblm_week4_day4
{
    class PowerCalculator
    {
        public int CalculatePower(int baseNum, int exponent)
        {
            if (exponent == 0)
                return 1;

            return baseNum * CalculatePower(baseNum, exponent - 1);
        }
    }

    internal class P5
    {
        static void Main(string[] args)
        {
            int baseNum, exponent;

            Console.Write("Enter Base Number: ");
            baseNum = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Exponent: ");
            exponent = Convert.ToInt32(Console.ReadLine());

            if (exponent < 0)
            {
                Console.WriteLine("Exponent must be a positive number.");
            }
            else
            {
                PowerCalculator calc = new PowerCalculator();

                int result = calc.CalculatePower(baseNum, exponent);

                Console.WriteLine("Base: " + baseNum);
                Console.WriteLine("Exponent: " + exponent);
                Console.WriteLine("Result: " + result);
            }

            Console.ReadLine();
        }
    }
}