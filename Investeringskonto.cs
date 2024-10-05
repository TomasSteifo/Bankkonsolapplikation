public class Investeringskonto : BankAccount
{
    public Investeringskonto(string owenerName, double initialBalance) : base(owenerName, initialBalance)
    {
    }

    public override void PrintAccountInfo()
    {
        Console.WriteLine("Investeringskonto");
        base.PrintAccountInfo();
    }
}