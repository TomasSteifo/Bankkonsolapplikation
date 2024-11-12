using System.Linq;

namespace Bankkonsolapplikation
{
    public class Bank
    {
        private List<BankAccount> accounts = new List<BankAccount>();
        private List<User> users = new List<User>();
        private User loggedInUser;

        public void RegisterUser(string username, string password)
        {
            if (users.Any(u => u.Username == username))
            {
                Console.WriteLine("Username already exists. Please choose a different username.");
            }
            else
            {
                users.Add(new User(username, password));
                Console.WriteLine("User registered successfully.");
            }
        }

        public bool Login(string username, string password)
        {
            var user = users.FirstOrDefault(u => u.Username == username);
            if (user != null && user.ValidatePassword(password))
            {
                loggedInUser = user;
                Console.WriteLine($"Login successful. Welcome, {username}!");
                return true;
            }
            Console.WriteLine("Invalid username or password. Please try again.");
            return false;
        }

        public void Logout()
        {
            loggedInUser = null;
            Console.WriteLine("You have been logged out.");
        }

        public void CreateAccount(string ownerName, double initialBalance)
        {
            var newAccount = new BankAccount(ownerName, initialBalance);
            accounts.Add(newAccount);
            Console.WriteLine($"Account created with Account Number: {newAccount.AccountNumber}");
        }

        public void DeleteAccount(string accountNumber)
        {
            var account = GetAccountByNumber(accountNumber);
            if (account != null)
            {
                accounts.Remove(account);
                Console.WriteLine($"Account {accountNumber} deleted.");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public BankAccount GetAccountByNumber(string accountNumber)
        {
            return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        public void ShowAllAccountInfo()
        {
            foreach (var account in accounts)
            {
                account.PrintAccountInfo();
                account.ShowTransactionHistory();
            }
        }

        public void ShowTransactionHistory(string accountNumber)
        {
            var account = GetAccountByNumber(accountNumber);
            if (account != null)
            {
                account.ShowTransactionHistory();
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public List<BankAccount> GetAllAccounts()
        {
            return accounts;
        }

        public void TransferFunds(string fromAccountNumber, string toAccountNumber, double amount)
        {
            var fromAccount = GetAccountByNumber(fromAccountNumber);
            var toAccount = GetAccountByNumber(toAccountNumber);
            if (fromAccount != null && toAccount != null)
            {
                fromAccount.Transfer(toAccount, amount);
            }
            else
            {
                Console.WriteLine("Invalid account number(s) provided for transfer.");
            }
        }
    }
}
