//Todo: class not used, namespace is wrong, also in swedish
public class Investeringskonto : BankAccount
{
    //Todo: Naming convention is wrong and in swedish. 
    public Investeringskonto(string ownerName, double initialBalance) : base(ownerName, initialBalance)
    {
    }

    // Overriding the PrintAccountInfo method
    public override void PrintAccountInfo()
    {
        Console.WriteLine("Investeringskonto");
        base.PrintAccountInfo(); // Calling the base class method to display common info
    }
}
