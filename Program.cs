namespace Bankkonsolapplikation
{
    class Program
    {
        static void Main(string[] args)
        {
            BankDao bankDao = new BankDao();
            Bank bank = new Bank();
            BankAppUI ui = new BankAppUI(bank);

            // Load accounts from JSON if available
            var loadedAccounts = bankDao.LoadData();
            foreach (var account in loadedAccounts)
            {
                bank.GetAllAccounts().Add(account);
            }

            // User authentication
            bool authenticated = false;
            while (!authenticated)
            {
                Console.WriteLine("\nWelcome to the Bank Application");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        authenticated = ui.LoginUser();
                        break;
                    case "2":
                        ui.RegisterUser();
                        break;
                    case "3":
                        Console.WriteLine("Exiting application...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

            // Main menu, available only after successful login
            bool running = true;
            while (running)
            {
                ShowMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ui.CreateAccount();
                        break;
                    case "2":
                        ui.DeleteAccount();
                        break;
                    case "3":
                        ui.ShowAccounts();
                        break;
                    case "4":
                        ui.TransferFunds();
                        break;
                    case "5":
                        ui.ShowTransactionHistory();
                        break;
                    case "6":
                        bankDao.SaveData(bank.GetAllAccounts());
                        Console.WriteLine("Data saved.");
                        break;
                    case "7":
                        bank.Logout();
                        authenticated = false;
                        Console.WriteLine("Logged out.");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Delete Account");
            Console.WriteLine("3. Show All Accounts");
            Console.WriteLine("4. Transfer Funds");
            Console.WriteLine("5. View Transaction History");
            Console.WriteLine("6. Save Data");
            Console.WriteLine("7. Logout");
        }
    }
}
