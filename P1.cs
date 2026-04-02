using System;
using System.Threading.Tasks;

namespace Week6_Day1
{
    class P1
    {
        static async Task Main()
        {
            Console.WriteLine("Starting logging...");

            await WriteLogAsync("Log 1");
            await WriteLogAsync("Log 2");
            await WriteLogAsync("Log 3");

            Console.WriteLine("All logs completed.");
            Console.ReadLine();
        }

        static async Task WriteLogAsync(string message)
        {
            Console.WriteLine($"Writing: {message}");

            await Task.Delay(2000); // simulate file write delay

            Console.WriteLine($"Completed: {message}");
        }
    }
}