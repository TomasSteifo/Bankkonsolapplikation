using System.Security.Cryptography;

public class BankAccount
{
    public string AccountNumber { get; set; }
    public string OwnerName { get; set; }
    public double Balance { get; protected set; }

    //History transaction
    public string FirstTransaction { get; private set; }
    public string LastTransaction { get; private set; }

    public BankAccount(string ownerName, double initialBalance)
    {

        OwnerName = ownerName;
        Balance = initialBalance;
        AccountNumber = Guid.NewGuid().ToString();

        FirstTransaction = $"Deposit of {initialBalance} on {DateTime.Now}";
        LastTransaction = FirstTransaction;

    }

    public virtual void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Deposit amount must be postitve");
            return;
        }

        Balance += amount;
        Console.WriteLine($"{amount} SEK deposited. New balance: {Balance} SEK");

        if (FirstTransaction == null)
            FirstTransaction = $"Depisited {amount} on {DateTime.Now}";

        LastTransaction = $"Depisited {amount} on {DateTime.Now}";
    }


    public virtual void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Withdraw amount must be postitve");
            return;
        }

        if (Balance >= amount)
        {
            Balance -= amount;
            Console.WriteLine($"{amount} SEK Withdraw from {AccountNumber}. New balance: {Balance} SEK");

            LastTransaction = $"Withdraw {amount} on {DateTime.Now}";


        }
        else
        {
            Console.WriteLine($"{amount} Withdraw not possible due to either to high ammount ot to low balance");
        }
    }

    public virtual void PrintAccountInfo()
    {
        Console.WriteLine($"\nAccount Number: {AccountNumber}");
        Console.WriteLine($"Owner: {OwnerName}");
        Console.WriteLine($"Balance: {Balance}");
        Console.WriteLine($"First Transaction: {FirstTransaction}");
        Console.WriteLine($"Last Transaction: {LastTransaction}");
    }
}