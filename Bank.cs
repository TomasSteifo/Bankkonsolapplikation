using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

public class Bank
{
    private Personkonto personkonto;
    private Sparkonto sparkonto;
    private Investeringskonto investeringskonto;

    public Bank(string ownerName, double initialDeposit)
    { 
        personkonto = new Personkonto (ownerName, initialDeposit);
        sparkonto = new Sparkonto(ownerName, initialDeposit); 
        investeringskonto = new Investeringskonto(ownerName, initialDeposit);   
    }

    public void Transfer(BankAccount fromAccount, BankAccount toAccount, double amount)
    {
        if (fromAccount != null && toAccount != null && fromAccount.Balance >= amount)
        {
            fromAccount.Withdraw(amount);
            toAccount.Deposit(amount);
            Console.WriteLine($"We have transfered {amount} from {fromAccount.OwnerName} to {toAccount.OwnerName} account");
        }
        else
        {
            Console.WriteLine("Not enough funds");
        }
    }

    public void Deposit(BankAccount account, double amount)
    { 
      account.Deposit(amount);
    }

    public void Withdraw(BankAccount account, double amount)
    {
       account.Withdraw(amount);
    }

   public void ShowAccountBs(BankAccount account, double amount)
   {
     account.Withdraw(amount);
   }

    public void ShowAccountBalance(BankAccount account)

    {
        Console.WriteLine($" {account.OwnerName} account balance {account.GetBalance}");
    }

    public void ShowAllAccountInfo()
    { 
        personkonto.PrintAccountInfo();
        sparkonto.PrintAccountInfo();
        investeringskonto.PrintAccountInfo();
    }
}