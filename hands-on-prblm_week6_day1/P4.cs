using System;
using System.Threading.Tasks;

namespace Week6_Day1
{
    class P4
    {
        static async Task Main()
        {
            Console.WriteLine("Order Processing Started");

            await VerifyPaymentAsync();
            await CheckInventoryAsync();
            await ConfirmOrderAsync();

            Console.WriteLine("Order Completed");
            Console.ReadLine();
        }

        static async Task VerifyPaymentAsync()
        {
            Console.WriteLine("Verifying Payment...");
            await Task.Delay(2000);
            Console.WriteLine("Payment Verified");
        }

        static async Task CheckInventoryAsync()
        {
            Console.WriteLine("Checking Inventory...");
            await Task.Delay(2000);
            Console.WriteLine("Inventory Available");
        }

        static async Task ConfirmOrderAsync()
        {
            Console.WriteLine("Confirming Order...");
            await Task.Delay(2000);
            Console.WriteLine("Order Confirmed");
        }
    }
}