using System;
using System.Collections.Generic;

namespace hands_on_prblm_week5_day2
{
    class P1
    {
        static void Main()
        {
            int[] marks = { 78, 85, 90, 67, 88 };
            int threshold = 80;

            int total = 0;
            int countAbove = 0;
            int highest = marks[0];

            // Dictionary to simulate Map (subject → highest)
            Dictionary<string, int> subjectHighest = new Dictionary<string, int>();
            subjectHighest["Math"] = 90;
            subjectHighest["Science"] = 88;
            subjectHighest["English"] = 85;

            for (int i = 0; i < marks.Length; i++)
            {
                total += marks[i];

                if (marks[i] > threshold)
                    countAbove++;

                if (marks[i] > highest)
                    highest = marks[i];
            }

            double average = (double)total / marks.Length;

            Console.WriteLine("Total Marks: " + total);
            Console.WriteLine("Average Marks: " + average);
            Console.WriteLine("Students above " + threshold + ": " + countAbove);
            Console.WriteLine("Highest Score: " + highest);

            Console.WriteLine("\nSubject-wise Highest Marks:");
            foreach (var item in subjectHighest)
            {
                Console.WriteLine(item.Key + " : " + item.Value);
            }

            Console.ReadLine();
        }
    }
}