using System.IO;
using Newtonsoft.Json;

public class BankDao
{
    private const string FilePath = "accounts.json";

    // Load accounts from the JSON file
    public List<BankAccount> LoadData()
    {
        if (!File.Exists(FilePath)) return new List<BankAccount>();

        var jsonData = File.ReadAllText(FilePath);
        return JsonConvert.DeserializeObject<List<BankAccount>>(jsonData) ?? new List<BankAccount>();
    }

    // Save accounts to the JSON file
    public void SaveData(List<BankAccount> accounts)
    {
        var jsonData = JsonConvert.SerializeObject(accounts, Formatting.Indented);
        File.WriteAllText(FilePath, jsonData);
    }
}
