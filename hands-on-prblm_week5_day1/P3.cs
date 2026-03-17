using System;

namespace hands_on_prblm_week5_day1
{
    class Product
    {
        private double price;

        public string Name { get; set; }

        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    Console.WriteLine("Price cannot be negative.");
                else
                    price = value;
            }
        }

        public virtual double CalculateDiscount()
        {
            return Price;
        }
    }

    class Electronics : Product
    {
        public override double CalculateDiscount()
        {
            return Price - (Price * 0.05);
        }
    }

    class Clothing : Product
    {
        public override double CalculateDiscount()
        {
            return Price - (Price * 0.15);
        }
    }

    class P3
    {
        static void Main()
        {
            Product item = new Electronics();
            item.Price = 20000;

            Console.WriteLine("Final Price after discount = " + item.CalculateDiscount());
        }
    }
}