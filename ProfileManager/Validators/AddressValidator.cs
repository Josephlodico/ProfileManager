using ProfileManager.Interfaces;

namespace ProfileManager.Validators
{
    public class AddressValidator : IValidator
    {
        public bool IsValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Address cannot be empty.");
                return false;
            }

            if (input.Length > 100)
            {
                Console.WriteLine("Address cannot be more than 100 characters long.");
                return false;
            }

            foreach (char c in input)
            {
                if (!char.IsLetterOrDigit(c) && c != ' ' && c != ',' && c != '.' && c != '-' && c != '#')
                {
                    Console.WriteLine("Address can only contain letters, numbers, spaces, and , . - #");
                    return false;
                }
            }
            return true;
        }
    }
}
