using System;

namespace hands_on_prblm_week5_day1
{
    class Vehicle
    {
        public string Brand { get; set; }
        public double RentalRatePerDay { get; set; }

        public virtual double CalculateRental(int days)
        {
            return RentalRatePerDay * days;
        }
    }

    class Car : Vehicle
    {
        public override double CalculateRental(int days)
        {
            double total = RentalRatePerDay * days;
            return total + 500;
        }
    }

    class Bike : Vehicle
    {
        public override double CalculateRental(int days)
        {
            double total = RentalRatePerDay * days;
            return total - (total * 0.05);
        }
    }

    class P4
    {
        static void Main()
        {
            Vehicle car = new Car();
            car.RentalRatePerDay = 2000;

            int days = 3;

            Console.WriteLine("Total Rental = " + car.CalculateRental(days));
        }
    }
}