using System.Security.Cryptography;

public class BankAccount
{
    public string AccountNumber { get; set; }
    public string OwnerName { get; set; }
    public double Balance { get; protected set; }

    public BankAccount(string ownerName, double initialBalance)
    {

        OwnerName = ownerName;
        Balance = initialBalance;
        AccountNumber = Guid.NewGuid().ToString();
    }

    public virtual void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"{amount} SEK deposited. New balance: {Balance} SEK");
        }
        else
        {
            Console.WriteLine($"{amount} DEposit ammount must be positive");
        }
    }


    public virtual void Withdraw(double amount)
    {
        if (amount > 0 && Balance >= amount)
        {
            Balance -= amount;
            Console.WriteLine($"{amount} SEK Withdraw. New balance: {Balance} SEK");
        }
        else
        {
            Console.WriteLine($"{amount} Withdraw not possible due to either to high ammount ot to low balance");
        }
    }

    public double GetBalance()
    {
        return Balance;
    }

    public virtual void PrintAccountInfo()
    {
        Console.WriteLine($" Account owner {OwnerName}, Account numbwe {AccountNumber},  Account Balance {Balance},");
    }
}