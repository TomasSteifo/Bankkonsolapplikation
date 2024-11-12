public class Sparkonto : BankAccount
{
    public Sparkonto(string ownerName, double initialBalance)
        : base(ownerName, initialBalance)
    {
    }

    // Override PrintAccountInfo in Sparkonto
    public override void PrintAccountInfo()
    {
        Console.WriteLine("Sparkonto");
        base.PrintAccountInfo();  // Optionally call the base method
    }
}
