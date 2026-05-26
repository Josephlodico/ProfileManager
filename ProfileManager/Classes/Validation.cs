using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        public static string GetValidName(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                //Check if empty
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Name cannot be empty.");
                    continue;
                }

                //Checks if characters are letters
                bool isValid = true;

                foreach(char c in input)
                {
                    if (!char.IsLetter(c))
                    {
                        isValid = false;
                        break;
                    }
                }
                if (isValid)
                {
                    return input;
                }

                Console.WriteLine("Invalid name. Letters only.");
            }
        }
    }
}
