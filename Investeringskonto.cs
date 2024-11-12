public class Investeringskonto : BankAccount
{
    public Investeringskonto(string ownerName, double initialBalance)
        : base(ownerName, initialBalance)
    {
    }

    // Override the PrintAccountInfo method
    public override void PrintAccountInfo()
    {
        Console.WriteLine("Investeringskonto");
        base.PrintAccountInfo();  // Call the base method if you want to include the base information
    }
}
