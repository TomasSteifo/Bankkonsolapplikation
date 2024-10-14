//Todo:class not used, namespace wrong, also in swedish
public class Personkonto : BankAccount
{
    //Todo: Naming convention is wrong and in swedish. 
    public Personkonto(string owenerName, double initialBalance) : base(owenerName, initialBalance)
    { 
    }

    public override void PrintAccountInfo()
    {
        Console.WriteLine("Personkonto");
        base.PrintAccountInfo();
    }
}
