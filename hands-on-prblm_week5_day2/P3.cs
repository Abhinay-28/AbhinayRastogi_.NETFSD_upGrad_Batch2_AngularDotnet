using System;

namespace hands_on_prblm_week5_day2
{
    class Node
    {
        public int id;
        public string name;
        public Node next;
    }

    class LinkedList
    {
        Node head;

        public void InsertEnd(int id, string name)
        {
            Node newNode = new Node();
            newNode.id = id;
            newNode.name = name;
            newNode.next = null;

            if (head == null)
            {
                head = newNode;
                return;
            }

            Node temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }

            temp.next = newNode;
        }

        public void Delete(int id)
        {
            if (head == null)
                return;

            if (head.id == id)
            {
                head = head.next;
                return;
            }

            Node temp = head;
            while (temp.next != null && temp.next.id != id)
            {
                temp = temp.next;
            }

            if (temp.next != null)
            {
                temp.next = temp.next.next;
            }
        }

        public void Display()
        {
            Node temp = head;

            while (temp != null)
            {
                Console.WriteLine(temp.id + " - " + temp.name);
                temp = temp.next;
            }
        }
    }

    class P3
    {
        static void Main()
        {
            LinkedList list = new LinkedList();

            list.InsertEnd(101, "John");
            list.InsertEnd(102, "Sara");
            list.InsertEnd(103, "Mike");

            list.Delete(102);

            Console.WriteLine("Employee List After Deletion:");
            list.Display();

            Console.ReadLine();
        }
    }
}