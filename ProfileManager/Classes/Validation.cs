using System;
using System.Collections.Generic;
using System.Linq;

namespace ProfileManager.Classes
{
    public static class Validation
    {
        public static string GetValidEmail()
        {
            while (true)
            {
                Console.Write("Enter Email: ");
                string? email = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(email))
                {
                    Console.WriteLine("Email cannot be empty.");
                    continue;
                }

                if (!email.Contains("@"))
                {
                    Console.WriteLine("Email must contain @.");
                    continue;
                }

                string[] parts = email.Split('@');
                if (parts.Length != 2)
                {
                    Console.WriteLine("Email can only contain one @.");
                    continue;
                }

                if (string.IsNullOrWhiteSpace(parts[0]))
                {
                    Console.WriteLine("Email must have a name before @.");
                    continue;
                }
                if (string.IsNullOrWhiteSpace(parts[1]))
                {
                    Console.WriteLine("Email must have an email type after @.");
                    continue;
                }

                //Must end with.com
                if (!parts[1].EndsWith(".com"))
                {
                    Console.WriteLine("Email must end with .com");
                    continue;
                }
                return email;
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
