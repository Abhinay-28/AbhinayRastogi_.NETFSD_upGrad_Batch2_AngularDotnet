using System;
using System.Collections.Generic;

namespace hands_on_prblm_week5_day2
{
    // Record definition
    public record Student(int RollNumber, string Name, string Course, int Marks);

    class P4
    {
        static void Main()
        {
            List<Student> students = new List<Student>();

            Console.Write("Enter number of students: ");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int roll, marks;
                string name, course;

                Console.Write("Enter Roll Number: ");
                roll = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Name: ");
                name = Console.ReadLine();

                Console.Write("Enter Course: ");
                course = Console.ReadLine();

                Console.Write("Enter Marks: ");
                marks = Convert.ToInt32(Console.ReadLine());

                if (marks < 0 || marks > 100)
                {
                    Console.WriteLine("Invalid marks. Try again.");
                    i--;
                    continue;
                }

                students.Add(new Student(roll, name, course, marks));
            }

            Console.WriteLine("\nStudent Records:");
            foreach (var s in students)
            {
                Console.WriteLine($"Roll No: {s.RollNumber} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
            }

            Console.Write("\nSearch Roll Number: ");
            int searchRoll = Convert.ToInt32(Console.ReadLine());

            bool found = false;

            foreach (var s in students)
            {
                if (s.RollNumber == searchRoll)
                {
                    Console.WriteLine("Student Found:");
                    Console.WriteLine($"Roll No: {s.RollNumber} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Record not found.");
            }

            Console.ReadLine();
        }
    }
}