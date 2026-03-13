using System;

namespace hands_on_prblm_week4_day4
{
    class OrderCalculator
    {
        public double CalculateFinalAmount(double price, int quantity, double discountPercent = 0, double shippingCharge = 50)
        {
            double subtotal = price * quantity;
            double discount = subtotal * discountPercent / 100;
            double amountAfterDiscount = subtotal - discount;
            double finalAmount = amountAfterDiscount + shippingCharge;

            Console.WriteLine("Subtotal: " + subtotal);
            Console.WriteLine("Discount Applied: " + discount);
            Console.WriteLine("Shipping Charge: " + shippingCharge);

            return finalAmount;
        }
    }

    internal class P4
    {
        static void Main(string[] args)
        {
            double price;
            int quantity;

            Console.Write("Enter Product Price: ");
            price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Quantity: ");
            quantity = Convert.ToInt32(Console.ReadLine());

            OrderCalculator order = new OrderCalculator();

            double finalAmount = order.CalculateFinalAmount(price, quantity);

            Console.WriteLine("Final Payable Amount: " + finalAmount);

            Console.ReadLine();
        }
    }
}