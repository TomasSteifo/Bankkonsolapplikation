using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankkonsolapplikation
{
    public class Transaction
    {
        public string Type { get; private set; }
        public double Amount { get; private set; }
        public DateTime Date { get; private set; }
        public string Description { get; private set; }

        // Constructor with three parameters
        public Transaction(string type, double amount, string description)
        {
            Type = type;
            Amount = amount;
            Date = DateTime.Now; // Automatically set date to current time
            Description = description;
        }
    }
}