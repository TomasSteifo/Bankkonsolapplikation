public class Personkonto : BankAccount
{
    public Personkonto(string owenerName, double initialBalance) : base(owenerName, initialBalance)
    { 
    }

    public override void PrintAccountInfo()
    {
        Console.WriteLine("Personkonto");
        base.PrintAccountInfo();
    }
}
