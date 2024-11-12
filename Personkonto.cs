public class Personkonto : BankAccount
{
    public Personkonto(string ownerName, double initialBalance)
        : base(ownerName, initialBalance)
    {
    }

    public override void PrintAccountInfo()
    {
        Console.WriteLine("Personkonto");
        base.PrintAccountInfo();  // Optionally call base method
    }
}
