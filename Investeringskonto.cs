public class Investeringskonto : BankAccount
{
    public Investeringskonto(string ownerName, double initialBalance) : base(ownerName, initialBalance)
    {
    }

    // Overriding the PrintAccountInfo method
    public override void PrintAccountInfo()
    {
        Console.WriteLine("Investeringskonto");
        base.PrintAccountInfo();  // Calling the base class method to display common info
    }
}
