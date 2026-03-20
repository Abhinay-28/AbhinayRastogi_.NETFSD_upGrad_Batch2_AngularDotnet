using System;
using System.IO;

namespace Week5_Day4
{
    class P4
    {
        static void Main()
        {
            Console.Write("Enter directory path: ");
            string path = Console.ReadLine();

            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);

                if (!dir.Exists)
                {
                    Console.WriteLine("Invalid directory.");
                    return;
                }

                DirectoryInfo[] subDirs = dir.GetDirectories();

                foreach (var sub in subDirs)
                {
                    int count = sub.GetFiles().Length;
                    Console.WriteLine($"{sub.Name} - Files: {count}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}