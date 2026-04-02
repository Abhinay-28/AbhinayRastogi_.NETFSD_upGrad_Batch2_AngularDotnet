using System;
using System.Diagnostics;
using System.IO;

namespace Week6_Day1
{
    class P5
    {
        static void Main()
        {
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));
            Trace.AutoFlush = true;

            ProcessOrder();

            Console.WriteLine("Check log file for trace output.");
            Console.ReadLine();
        }

        static void ProcessOrder()
        {
            Trace.WriteLine("Order Validation Started");
            Trace.TraceInformation("Validating Order");

            Trace.WriteLine("Processing Payment");
            Trace.TraceInformation("Payment Done");

            Trace.WriteLine("Updating Inventory");
            Trace.TraceInformation("Inventory Updated");

            Trace.WriteLine("Generating Invoice");
            Trace.TraceInformation("Invoice Generated");
        }
    }
}