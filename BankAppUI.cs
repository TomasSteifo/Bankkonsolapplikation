using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankkonsolapplikation
{
    using System;

    public class BankAppUI
    {
        private Bank bank;

        public BankAppUI(Bank bank)
        {
            this.bank = bank;
        }

        public bool LoginUser()
        {
            Console.WriteLine("Enter Account Number:");
            string accountNumber = Console.ReadLine();

            Console.WriteLine("Enter PIN Code:");
            string pinCode = Console.ReadLine();

            var account = bank.AuthenticateAccount(accountNumber, pinCode);
            if (account != null)
            {
                Console.WriteLine($"Login successful. Welcome, {account.OwnerName}!");
                return true;
            }

            Console.WriteLine("Invalid login credentials. Please try again.");
            return false;
        }

        public void RegisterUser()
        {
            Console.WriteLine("Enter a new username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter a new password:");
            string password = Console.ReadLine();

            bank.RegisterUser(username, password);
        }

        public void CreateAccount()
        {
            Console.WriteLine("Enter account owner's name:");
            string ownerName = Console.ReadLine();

            Console.WriteLine("Enter a 4-digit PIN code:");
            string pinCode = Console.ReadLine();

            Console.WriteLine("Enter initial balance:");
            double initialBalance;
            while (!double.TryParse(Console.ReadLine(), out initialBalance) || initialBalance < 0)
            {
                Console.WriteLine("Invalid balance. Please enter a valid positive number.");
            }

            // Use the Bank instance passed in the constructor
            bank.CreateAccount(ownerName, pinCode, initialBalance);
        }


        public void DeleteAccount()
        {
            Console.WriteLine("Enter account number to delete:");
            string accountNumber = Console.ReadLine();

            bank.DeleteAccount(accountNumber);
        }

        public void ShowAccounts()
        {
            bank.ShowAllAccountInfo();
        }

        public void TransferFunds()
        {
            Console.WriteLine("Enter the account number to transfer from:");
            string fromAccountNumber = Console.ReadLine();

            Console.WriteLine("Enter the account number to transfer to:");
            string toAccountNumber = Console.ReadLine();

            double amount = GetValidDouble("Enter transfer amount:");

            bank.TransferFunds(fromAccountNumber, toAccountNumber, amount);
        }

        public void ShowTransactionHistory()
        {
            Console.WriteLine("Enter the account number to view transaction history:");
            string accountNumber = Console.ReadLine();

            bank.ShowTransactionHistory(accountNumber);
        }

        private double GetValidDouble(string prompt)
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
    }

}
