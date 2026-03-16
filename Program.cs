using System;

namespace hands_on_prblm_week4_day5
{
    class BankAccount
    {
        // Private field
        private double balance;

        // Method to deposit money
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance = balance + amount;
                Console.WriteLine("Amount Deposited: " + amount);
            }
            else
            {
                Console.WriteLine("Invalid deposit amount.");
            }
        }

        // Method to withdraw money
        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                Console.WriteLine("Insufficient balance.");
            }
            else
            {
                balance = balance - amount;
                Console.WriteLine("Amount Withdrawn: " + amount);
            }
        }

        // Method to check balance
        public double GetBalance()
        {
            return balance;
        }
    }

    internal class P1
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();

            account.Deposit(1000);
            account.Withdraw(300);

            Console.WriteLine("Current Balance = " + account.GetBalance());

            Console.ReadLine();
        }
    }
}