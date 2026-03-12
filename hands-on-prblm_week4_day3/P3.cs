using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hands_on_prblm_week4_day3
{
    internal class P3
    {





        static void Main()
        {
            string name;
            double salary, bonus, finalSalary;
            int experience;

            Console.Write("Enter Name: ");
            name = Console.ReadLine();

            Console.Write("Enter Salary: ");
            salary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Experience (years): ");
            experience = Convert.ToInt32(Console.ReadLine());

            double bonusRate;

            if (experience < 2)
            {
                bonusRate = 0.05;
            }
            else if (experience <= 5)
            {
                bonusRate = 0.10;
            }
            else
            {
                bonusRate = 0.15;
            }

            bonus = salary * bonusRate;
            finalSalary = salary + bonus;

            Console.WriteLine("Employee: " + name);
            Console.WriteLine("Bonus: " + bonus);
            Console.WriteLine("Final Salary: " + finalSalary);
        }
    }


}

