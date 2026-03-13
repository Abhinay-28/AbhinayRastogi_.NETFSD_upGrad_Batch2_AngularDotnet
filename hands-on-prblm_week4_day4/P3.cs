using System;

namespace hands_on_prblm_week4_day4
{
    class ResultAnalyzer
    {
        public void CalculateResult(int m1, int m2, int m3, out int totalMarks, out double averageMarks)
        {
            totalMarks = m1 + m2 + m3;
            averageMarks = totalMarks / 3.0;
        }
    }

    internal class P3
    {
        static void Main(string[] args)
        {
            char choice;

            do
            {
                int m1, m2, m3;

                Console.Write("Enter Marks for Subject 1: ");
                m1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Marks for Subject 2: ");
                m2 = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Marks for Subject 3: ");
                m3 = Convert.ToInt32(Console.ReadLine());

                if (m1 < 0 || m1 > 100 || m2 < 0 || m2 > 100 || m3 < 0 || m3 > 100)
                {
                    Console.WriteLine("Invalid marks. Please enter marks between 0 and 100.");
                }
                else
                {
                    ResultAnalyzer analyzer = new ResultAnalyzer();

                    int total;
                    double average;

                    analyzer.CalculateResult(m1, m2, m3, out total, out average);

                    Console.WriteLine("Total Marks: " + total);
                    Console.WriteLine("Average Marks: " + average);

                    if (average >= 40)
                        Console.WriteLine("Result: Pass");
                    else
                        Console.WriteLine("Result: Fail");
                }

                Console.Write("Check another student? (y/n): ");
                choice = Convert.ToChar(Console.ReadLine());

            } while (choice == 'y' || choice == 'Y');

            Console.ReadLine();
        }
    }
}