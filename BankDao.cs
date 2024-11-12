using System.IO;
using Newtonsoft.Json;
// Optionally, use an alias to make the code cleaner
using JsonFormatting = Newtonsoft.Json.Formatting;

public class BankDao
{
    private const string FilePath = "bankData.json";

    public void SaveData(List<BankAccount> accounts)
    {
        // Use the alias if you set it, or fully qualify Formatting as shown below
        var jsonData = JsonConvert.SerializeObject(accounts, JsonFormatting.Indented);
        // Alternatively:
        // var jsonData = JsonConvert.SerializeObject(accounts, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(FilePath, jsonData);
    }

    public List<BankAccount> LoadData()
    {
        if (!File.Exists(FilePath)) return new List<BankAccount>();

        var jsonData = File.ReadAllText(FilePath);
        return JsonConvert.DeserializeObject<List<BankAccount>>(jsonData) ?? new List<BankAccount>();
    }
}
