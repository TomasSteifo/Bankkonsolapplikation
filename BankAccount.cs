using System;
using System.Collections.Generic;

public class BankAccount
{
    public string AccountNumber { get; set; } // Allow deserialization
    public string OwnerName { get; set; } // Allow deserialization
    public string PinCode { get; set; } // Added for authentication
    public double Balance { get; set; } // Allow deserialization
    public List<string> TransactionHistory { get; set; } = new List<string>();

    // Default constructor for JSON deserialization
    public BankAccount() { }

    // Constructor for creating a new account
    public BankAccount(string ownerName, string pinCode, double initialBalance)
    {
        OwnerName = ownerName;
        PinCode = pinCode;
        Balance = initialBalance;
        AccountNumber = Guid.NewGuid().ToString(); // Generate a unique account number
        AddTransaction("Initial Deposit", initialBalance, "Account created");
    }

    // Add a transaction to the history
    public void AddTransaction(string type, double amount, string description)
    {
        string transaction = $"{DateTime.Now}: {type} of {amount} SEK - {description}";
        TransactionHistory.Add(transaction);
    }

    public void Transfer(BankAccount toAccount, double amount)
    {
        if (toAccount == null || toAccount == this)
        {
            Console.WriteLine("Invalid transfer target.");
            return;
        }

        if (amount <= 0)
        {
            Console.WriteLine("Transfer amount must be positive.");
            return;
        }

        if (Balance >= amount)
        {
            Withdraw(amount); // Deduct from this account
            toAccount.Deposit(amount); // Add to the target account
            AddTransaction("Transfer", amount, $"Transferred to account {toAccount.AccountNumber}");
            Console.WriteLine($"Transferred {amount} SEK to account {toAccount.AccountNumber}.");
        }
        else
        {
            Console.WriteLine("Insufficient funds for transfer.");
        }
    }


    // Deposit money into the account
    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Deposit amount must be positive.");
            return;
        }

        Balance += amount;
        AddTransaction("Deposit", amount, "Deposit completed.");
        Console.WriteLine($"{amount} SEK deposited. New balance: {Balance} SEK");
    }


    // Withdraw money from the account
    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Withdrawal amount must be positive.");
            return;
        }

        if (Balance >= amount)
        {
            Balance -= amount;
            AddTransaction("Withdrawal", amount, "Withdrawal completed.");
            Console.WriteLine($"{amount} SEK withdrawn. New balance: {Balance} SEK");
        }
        else
        {
            Console.WriteLine("Insufficient balance for this withdrawal.");
        }
    }



    // Validate if the amount is positive
    private bool IsValidAmount(double amount, string operation)
    {
        if (amount <= 0)
        {
            Console.WriteLine($"{operation} amount must be positive.");
            return false;
        }
        return true;
    }

    // Display the transaction history
    public void ShowTransactionHistory()
    {
        Console.WriteLine($"\nTransaction History for Account {AccountNumber}:");
        if (TransactionHistory.Count == 0)
        {
            Console.WriteLine("No transactions found.");
        }
        else
        {
            foreach (var transaction in TransactionHistory)
            {
                Console.WriteLine(transaction);
            }
        }
    }

    // Print basic account information
    public virtual void PrintAccountInfo()
    {
        Console.WriteLine($"\nAccount Information:");
        Console.WriteLine($"Account Number: {AccountNumber}");
        Console.WriteLine($"Owner: {OwnerName}");
        Console.WriteLine($"Balance: {Balance} SEK");
    }
}
