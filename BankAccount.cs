//Todo: Remove unused using 
using System.Security.Cryptography;

//Todo: Namespace is wrong 
public class BankAccount
{
    //Todo: Go through encapuslation. Which Properties need to be public??? Else private or internal 
    public string AccountNumber { get; set; }
    public string OwnerName { get; set; }
    public double Balance { get; protected set; }

    //Todo: History transaction
    public string FirstTransaction { get; private set; }
    public string LastTransaction { get; private set; }

    //Todo: Extract to its own class as mapper
    public BankAccount(string ownerName, double initialBalance)
    {

        OwnerName = ownerName;
        Balance = initialBalance;
        AccountNumber = Guid.NewGuid().ToString();

        FirstTransaction = $"Deposit of {initialBalance} on {DateTime.Now}";
        LastTransaction = FirstTransaction;

    }

    //Todo:  virtual keyword not used. Deposit is never overwritten
    public virtual void Deposit(double amount)
    {
        if (amount <= 0)
        {
            //Todo: spelling 
            Console.WriteLine("Deposit amount must be postitve");
            return;
        }

        Balance += amount;
        Console.WriteLine($"{amount} SEK deposited. New balance: {Balance} SEK");

        //Todo: condition is allways false. Remove or re-write logic. And spelling 
        if (FirstTransaction == null)
            FirstTransaction = $"Depisited {amount} on {DateTime.Now}";

        LastTransaction = $"Depisited {amount} on {DateTime.Now}";
    }


    //Todo:  virtual keyword not used. Deposit is never overwritten
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
            //Todo: remove spacing

        }
        else
        {
            Console.WriteLine($"{amount} Withdraw not possible due to either to high ammount ot to low balance");
        }
    }

    public virtual void PrintAccountInfo()
    {
        //Todo: consolidate to one console writeline with array or list of strings
        Console.WriteLine($"\nAccount Number: {AccountNumber}");
        Console.WriteLine($"Owner: {OwnerName}");
        Console.WriteLine($"Balance: {Balance}");
        Console.WriteLine($"First Transaction: {FirstTransaction}");
        Console.WriteLine($"Last Transaction: {LastTransaction}");
    }
}
