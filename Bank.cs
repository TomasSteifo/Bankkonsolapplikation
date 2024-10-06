using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

public class Bank
{
    public BankAccount Personkonto { get; private set; }
    public BankAccount Sparkonto { get; private set; }
    public BankAccount Investeringskonto { get; private set; }

    public Bank(string ownerName, double initialDeposit)
    { 
        Personkonto = new BankAccount (ownerName, initialDeposit);
        Sparkonto = new BankAccount(ownerName, initialDeposit); 
        Investeringskonto = new BankAccount(ownerName, initialDeposit);   
    }

    public BankAccount GetAccountByNumber(string accountnumber)
    { 
        if (Personkonto.AccountNumber == accountnumber) return Personkonto;
        if (Sparkonto.AccountNumber == accountnumber) return Sparkonto;
        if (Investeringskonto.AccountNumber == accountnumber) return Investeringskonto;

        return null;
    }

    public void Deposit(BankAccount account, double amount)
    {
        if (account != null)
        {
            account.Deposit(amount);
        }
        else
        {
            Console.WriteLine("Wrong account number");
        }
    }

    public void Withdraw(BankAccount account, double amount)
    {
        if (account != null)
        {
            account.Withdraw(amount);
        }
        else
        {
            Console.WriteLine("Wrong account number");
        }

    }
    public void Transfer(BankAccount fromAccount, BankAccount toAccount, double amount)
    {
        if (fromAccount == null || toAccount == null)
        {
            Console.WriteLine("Invalid account number.");
            return;
        }

        if (fromAccount == toAccount)
        {
            Console.WriteLine("Cannot transfer between the same account.");
            return;
        }

        if (amount <= 0)
        {
            Console.WriteLine("Transfer amount must be positive.");
            return;
        }

        if (fromAccount.Balance >= amount)
        {
            fromAccount.Withdraw(amount);
            toAccount.Deposit(amount);
            Console.WriteLine($"Transferred {amount} from {fromAccount.AccountNumber} to {toAccount.AccountNumber}");
        }
        else
        {
            Console.WriteLine("Insufficient funds for this transfer.");
        }
    }
    // Show all accounts' information
    public void ShowAllAccountInfo()
    {
        Personkonto.PrintAccountInfo();
        Sparkonto.PrintAccountInfo();
        Investeringskonto.PrintAccountInfo();
    }

}