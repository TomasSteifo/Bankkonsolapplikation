public class Sparkonto : BankAccount
{
    public Sparkonto(string ownerName, string pinCode, double initialBalance)
        : base(ownerName, pinCode, initialBalance) // Pass arguments to base constructor
    {
    }

    public override void PrintAccountInfo()
    {
        Console.WriteLine("Sparkonto");
        base.PrintAccountInfo();
    }
}
