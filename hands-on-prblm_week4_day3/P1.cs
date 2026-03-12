// See https://aka.ms/new-console-template for more information

using System;

class Program
{
    static void Main()
    {
        string name;
        int marks;

        Console.Write("Enter Name: ");
        name = Console.ReadLine();

        Console.Write("Enter Marks: ");
        marks = Convert.ToInt32(Console.ReadLine());

        if (marks < 0 || marks > 100)
        {
            Console.WriteLine("Invalid marks entered.");
        }
        else
        {
            string grade;

            if (marks >= 90)
            {
                grade = "A";
            }
            else if (marks >= 75)
            {
                grade = "B";
            }
            else if (marks >= 60)
            {
                grade = "C";
            }
            else if (marks >= 50)
            {
                grade = "D";
            }
            else
            {
                grade = "Fail";
            }

            Console.WriteLine("Student: " + name);
            Console.WriteLine("Grade: " + grade);
        }
    }
}
