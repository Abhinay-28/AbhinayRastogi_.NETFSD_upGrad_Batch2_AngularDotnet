using System;

namespace Week6_Day1
{
    class P2
    {
        static void Main()
        {
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Discount %: ");
            double discount = Convert.ToDouble(Console.ReadLine());

            double finalPrice = price - (price * discount / 100);

            Console.WriteLine($"Final Price: {finalPrice}");

            Console.ReadLine();
        }
    }
}