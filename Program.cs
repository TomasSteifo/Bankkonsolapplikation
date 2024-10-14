//Todo: Namespace is wrong 
class Program
{
    //Todo: args not used in param
    static void Main(string[] args)
    {
        //Todo: Unecessary spacing and extract to its own class
        
        Console.WriteLine("Enter account owner's name:");
        
        //Todo: Never use typed variables 
        var ownerName = Console.ReadLine();

        //Todo:Never use typed variables 
        var initialDeposit = GetValidDouble("Enter initial deposit:");

        //Todo: Never use typed variables
        //Todo: Nullcheck & Validate owner name, initial deposit 
        Bank bank = new Bank(ownerName, initialDeposit);

        //Todo: Never use typed variables
        bool running = true;
        while (running)
        {
            //Todo: consolidate to one ConsoleWriteLine with array or list of strings
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Deposit money");
            Console.WriteLine("2. Withdraw money");
            Console.WriteLine("3. Transfer money");
            Console.WriteLine("4. Show account balances");
            Console.WriteLine("5. Exit");

            //Todo: Never use typed variables
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    //Todo: Never use typed variables
                    string depositAccountNumber = GetValidAccountNumber(bank);
                    double depositAmount = GetValidDouble("Enter deposit amount:");
                    bank.Deposit(bank.GetAccountByNumber(depositAccountNumber), depositAmount);
                    break;

                case "2":
                    //Todo: Never use typed variables
                    string withdrawAccountNumber = GetValidAccountNumber(bank);
                    double withdrawAmount = GetValidDouble("Enter withdrawal amount:");
                    bank.Withdraw(bank.GetAccountByNumber(withdrawAccountNumber), withdrawAmount);
                    break;

                case "3":
                    //Todo: Never use typed variables
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

    //Todo: Extract Helper method
    // Todo: Helper method to get a valid double (with input validation)
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

    //Todo: Extract helper method 
    // Todo: Helper method to get a valid account number
    static string GetValidAccountNumber(Bank bank, string prompt = "Enter account number:")
    {
        string accountNumber;
        while (true)
        {
            Console.WriteLine(prompt);
            //Todo: Null check
            accountNumber = Console.ReadLine();
            if (bank.GetAccountByNumber(accountNumber) != null)
                break;
            Console.WriteLine("Invalid account number, please try again.");
        }
        return accountNumber;
    }
}
