public class Investeringskonto : BankAccount
{
    public Investeringskonto(string ownerName, string pinCode, double initialBalance)
        : base(ownerName, pinCode, initialBalance) // Pass arguments to base constructor
    {
    }

    public override void PrintAccountInfo()
    {
        Console.WriteLine("Investeringskonto");
        base.PrintAccountInfo();
    }
}
