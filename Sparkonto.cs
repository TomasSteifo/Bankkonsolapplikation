public class Sparkonto : BankAccount
{
    public Sparkonto(string owenerName, double initialBalance) : base(owenerName, initialBalance)
    {
    }

    public override void PrintAccountInfo()
    {
        Console.WriteLine("Sparkonto");
        base.PrintAccountInfo();
    }
}