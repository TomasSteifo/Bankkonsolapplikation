using System;
using System.Collections.Generic;
using System.Linq;

namespace Bankkonsolapplikation
{
    public class Bank
    {
        private List<BankAccount> accounts = new List<BankAccount>();
        private List<User> users = new List<User>();
        private User loggedInUser;

        // Register a new user
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

        // Log in an existing user
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

        // Log out the current user
        public void Logout()
        {
            loggedInUser = null;
            Console.WriteLine("You have been logged out.");
        }

        // Create a new bank account with a PIN
        public void CreateAccount(string ownerName, string pinCode, double initialBalance)
        {
            if (string.IsNullOrWhiteSpace(pinCode) || pinCode.Length != 4 || !pinCode.All(char.IsDigit))
            {
                Console.WriteLine("Invalid PIN. It must be a 4-digit number.");
                return;
            }

            var newAccount = new BankAccount(ownerName, pinCode, initialBalance);
            accounts.Add(newAccount);
            Console.WriteLine($"Account created with Account Number: {newAccount.AccountNumber}");
        }

        // Load accounts into the bank
        public void LoadAccounts(List<BankAccount> loadedAccounts)
        {
            if (loadedAccounts == null || !loadedAccounts.Any())
            {
                Console.WriteLine("No accounts to load.");
                return;
            }

            accounts.AddRange(loadedAccounts);
            Console.WriteLine($"Loaded {loadedAccounts.Count} accounts into the bank.");
        }

        // Delete a bank account by account number
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

        // Retrieve a bank account by its number
        public BankAccount GetAccountByNumber(string accountNumber)
        {
            return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        // Display information for all accounts
        public void ShowAllAccountInfo()
        {
            foreach (var account in accounts)
            {
                account.PrintAccountInfo();
                account.ShowTransactionHistory();
            }
        }

        // Display the transaction history of a specific account
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

        // Return a list of all bank accounts
        public List<BankAccount> GetAllAccounts()
        {
            return accounts;
        }

        // Transfer funds between two accounts
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

        // Authenticate a bank account using account number and PIN
        public BankAccount AuthenticateAccount(string accountNumber, string pinCode)
        {
            var account = GetAccountByNumber(accountNumber);
            if (account != null && account.PinCode == pinCode)
            {
                return account; // Successfully authenticated
            }
            Console.WriteLine("Invalid account number or PIN.");
            return null; // Authentication failed
        }
    }
}
