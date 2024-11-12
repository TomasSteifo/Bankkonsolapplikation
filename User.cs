using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankkonsolapplikation
{
    public class User
    {
        public string Username { get; private set; }
        public string Password { get; private set; } // Plaintext for simplicity

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        // Validates if the provided password matches this user's password
        public bool ValidatePassword(string password)
        {
            return Password == password;
        }
    }

}
