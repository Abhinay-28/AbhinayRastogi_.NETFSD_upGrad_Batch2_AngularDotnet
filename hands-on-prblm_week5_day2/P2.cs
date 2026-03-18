using System;

namespace hands_on_prblm_week5_day2
{
    class P2
    {
        static void Main()
        {
            string[] stack = new string[10];
            int top = -1;

            // Push operations
            Push(stack, ref top, "Type A");
            Push(stack, ref top, "Type B");
            Push(stack, ref top, "Type C");

            // Undo operations
            Pop(stack, ref top);
            Pop(stack, ref top);

            Console.WriteLine("\nCurrent State After Operations:");
            for (int i = 0; i <= top; i++)
            {
                Console.WriteLine(stack[i]);
            }

            Console.ReadLine();
        }

        static void Push(string[] stack, ref int top, string action)
        {
            if (top == stack.Length - 1)
            {
                Console.WriteLine("Stack Overflow");
                return;
            }

            top++;
            stack[top] = action;

            Console.WriteLine("Action Added: " + action);
        }

        static void Pop(string[] stack, ref int top)
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is empty. Cannot undo.");
                return;
            }

            Console.WriteLine("Undo: " + stack[top]);
            top--;
        }
    }
}