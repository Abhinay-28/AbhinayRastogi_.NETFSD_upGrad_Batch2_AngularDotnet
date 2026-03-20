using System;
using System.IO;

namespace Week5_Day5
{
    class P1
    {
        static void Main()
        {
            try
            {
                Console.Write("Enter message: ");
                string message = Console.ReadLine();

                using (FileStream fs = new FileStream("log.txt", FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(message);
                    }
                }

                Console.WriteLine("Message written successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}