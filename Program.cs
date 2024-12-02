using System.Globalization;

namespace BankAccountApp
{
    class Account
    {
        private string name;
        private double balance;

        public Account(string accountName, double initialBalance)
        {
            name = accountName;
            balance = initialBalance < 0 ? 0 : initialBalance;
        }

        public void Deposit(double amount)
        {
            if (amount > 0) balance += amount;
        }

        public void Withdrawal(double amount)
        {
            if (amount > 0 && amount <= balance) balance -= amount;
        }

        public double GetBalance() => balance;
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter first account name:");
            string account1Name = Console.ReadLine();

            double account1InitialBalance = GetValidDouble("Enter first account initial balance:");

            Console.WriteLine("Enter second account name:");
            string account2Name = Console.ReadLine();

            double account2InitialBalance = GetValidDouble("Enter second account initial balance:");

            Account account1 = new Account(account1Name, account1InitialBalance);
            Account account2 = new Account(account2Name, account2InitialBalance);

            double withdrawAmount = GetValidDouble($"Enter amount to withdraw from {account1Name}:");
            account1.Withdrawal(withdrawAmount);

            double depositAmount = GetValidDouble($"Enter amount to deposit into {account2Name}:");
            account2.Deposit(depositAmount);

            Console.WriteLine($"The balance of {account1Name} is now: {account1.GetBalance():F2}");
            Console.WriteLine($"The balance of {account2Name} is now: {account2.GetBalance():F2}");
        }

        static double GetValidDouble(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine()?.Replace(',', '.');
                if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
                    return value;

                Console.WriteLine("Invalid input. Please try again.");
            }
        }
    }
}