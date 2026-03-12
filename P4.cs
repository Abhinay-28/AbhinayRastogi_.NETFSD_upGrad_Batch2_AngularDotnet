using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hands_on_prblm_week4_day3
{
    internal class P4
    {
    
        static void Main()
        {
            int n;
            int evenCount = 0;
            int oddCount = 0;
            int sum = 0;

            Console.Write("Enter Number: ");
            n = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                sum = sum + i;

                if (i % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }
            }

            Console.WriteLine("Even Count: " + evenCount);
            Console.WriteLine("Odd Count: " + oddCount);
            Console.WriteLine("Sum: " + sum);
        }
    }
}

