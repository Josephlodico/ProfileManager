using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileManager.Classes
{
    public static class Validation
    {
        public static string GetValidEmail()
        {
            while (true)
            {
                Console.Write("Enter Email: ");
                string? Email = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(Email) && Email.Contains("@"))
                {
                    return Email;
                }

                Console.WriteLine("Invalid email. Please enter a valid email.");
            }
        }
    }
}
