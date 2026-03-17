using System;

namespace hands_on_prblm_week5_day1
{
    class Employee
    {
        public string Name { get; set; }
        public double BaseSalary { get; set; }

        public virtual double CalculateSalary()
        {
            return BaseSalary;
        }
    }

    class Manager : Employee
    {
        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.20);
        }
    }

    class Developer : Employee
    {
        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.10);
        }
    }

    class P2
    {
        static void Main()
        {
            Employee manager = new Manager();
            manager.BaseSalary = 50000;

            Employee developer = new Developer();
            developer.BaseSalary = 50000;

            Console.WriteLine("Manager Salary = " + manager.CalculateSalary());
            Console.WriteLine("Developer Salary = " + developer.CalculateSalary());
        }
    }
}