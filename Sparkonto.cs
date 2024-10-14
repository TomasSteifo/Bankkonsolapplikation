//Todo: class not used
public class Sparkonto : BankAccount
{
    //Todo: Naming convention is wrong and in swedish. 
    public Sparkonto(string owenerName, double initialBalance) : base(owenerName, initialBalance)
    {
    }

    public override void PrintAccountInfo()
    {
        Console.WriteLine("Sparkonto");
        base.PrintAccountInfo();
    }
}
