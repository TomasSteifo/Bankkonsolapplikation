public class Personkonto : BankAccount
{
    public Personkonto(string ownerName, string pinCode, double initialBalance)
        : base(ownerName, pinCode, initialBalance) // Pass arguments to base constructor
    {
    }

    public override void PrintAccountInfo()
    {
        Console.WriteLine("Personkonto");
        base.PrintAccountInfo();
    }
}
