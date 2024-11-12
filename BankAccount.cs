using System.Collections.Generic;
using System.Transactions;

public class BankAccount
{
    public string AccountNumber { get; private set; }
    public string OwnerName { get; private set; }
    public double Balance { get; private set; }
    private List<Transaction> transactionHistory = new List<Transaction>();

    public BankAccount(string ownerName, double initialBalance)
    {
        OwnerName = ownerName;
        Balance = initialBalance;
        AccountNumber = Guid.NewGuid().ToString();
        AddTransaction("Initial Deposit", initialBalance, "Account created");
    }

    public IReadOnlyList<Transaction> TransactionHistory => transactionHistory.AsReadOnly();

    public void Deposit(double amount)
    {
        if (IsValidAmount(amount, "Deposit"))
        {
            Balance += amount;
            AddTransaction("Deposit", amount, "Deposit completed.");
            Console.WriteLine($"{amount} SEK deposited. New balance: {Balance} SEK");
        }
    }

    public void Withdraw(double amount)
    {
        if (IsValidAmount(amount, "Withdraw") && Balance >= amount)
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

    public void Transfer(BankAccount toAccount, double amount)
    {
        if (toAccount != null && toAccount != this && IsValidAmount(amount, "Transfer") && Balance >= amount)
        {
            Withdraw(amount);
            toAccount.Deposit(amount);
            AddTransaction("Transfer", amount, $"Transferred to account {toAccount.AccountNumber}");
        }
    }

    private bool IsValidAmount(double amount, string operation)
    {
        if (amount <= 0)
        {
            Console.WriteLine($"{operation} amount must be positive.");
            return false;
        }
        return true;
    }

    // Example call in BankAccount.cs to create a new Transaction
    private void AddTransaction(string type, double amount, string description)
    {
    }


    public void ShowTransactionHistory()
    {
        Console.WriteLine($"\nTransaction History for Account {AccountNumber}:");
        foreach (var transaction in transactionHistory)
        {
            Console.WriteLine(transaction);
        }
    }

    public virtual void PrintAccountInfo()
    {
        Console.WriteLine($"\nAccount Number: {AccountNumber}");
        Console.WriteLine($"Owner: {OwnerName}");
        Console.WriteLine($"Balance: {Balance}");
    }
}
