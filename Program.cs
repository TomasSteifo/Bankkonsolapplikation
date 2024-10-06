class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter account owner's name:");
        string ownerName = Console.ReadLine();

        double initialDeposit = GetValidDouble("Enter initial deposit:");

        Bank bank = new Bank(ownerName, initialDeposit);

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Deposit money");
            Console.WriteLine("2. Withdraw money");
            Console.WriteLine("3. Transfer money");
            Console.WriteLine("4. Show account balances");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string depositAccountNumber = GetValidAccountNumber(bank);
                    double depositAmount = GetValidDouble("Enter deposit amount:");
                    bank.Deposit(bank.GetAccountByNumber(depositAccountNumber), depositAmount);
                    break;

                case "2":
                    string withdrawAccountNumber = GetValidAccountNumber(bank);
                    double withdrawAmount = GetValidDouble("Enter withdrawal amount:");
                    bank.Withdraw(bank.GetAccountByNumber(withdrawAccountNumber), withdrawAmount);
                    break;

                case "3":
                    string fromAccountNumber = GetValidAccountNumber(bank, "Which account would you like to transfer from?");
                    string toAccountNumber = GetValidAccountNumber(bank, "Which account would you like to transfer to?");
                    double transferAmount = GetValidDouble("Enter transfer amount:");
                    bank.Transfer(bank.GetAccountByNumber(fromAccountNumber), bank.GetAccountByNumber(toAccountNumber), transferAmount);
                    break;

                case "4":
                    bank.ShowAllAccountInfo();
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    // Helper method to get a valid double (with input validation)
    static double GetValidDouble(string prompt)
    {
        double result;
        while (true)
        {
            Console.WriteLine(prompt);
            if (double.TryParse(Console.ReadLine(), out result) && result >= 0)
                break;
            Console.WriteLine("Invalid input, please enter a valid positive number.");
        }
        return result;
    }

    // Helper method to get a valid account number
    static string GetValidAccountNumber(Bank bank, string prompt = "Enter account number:")
    {
        string accountNumber;
        while (true)
        {
            Console.WriteLine(prompt);
            accountNumber = Console.ReadLine();
            if (bank.GetAccountByNumber(accountNumber) != null)
                break;
            Console.WriteLine("Invalid account number, please try again.");
        }
        return accountNumber;
    }
}