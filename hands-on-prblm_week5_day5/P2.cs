using System;
using System.IO;

namespace Week5_Day5
{
    class P2
    {
        static void Main()
        {
            Console.Write("Enter folder path: ");
            string path = Console.ReadLine();

            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);

                if (!dir.Exists)
                {
                    Console.WriteLine("Invalid directory.");
                    return;
                }

                FileInfo[] files = dir.GetFiles();

                foreach (var file in files)
                {
                    Console.WriteLine($"{file.Name} | {file.Length} bytes | Created: {file.CreationTime}");
                }

                Console.WriteLine("Total Files: " + files.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}