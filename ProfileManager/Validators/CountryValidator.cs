using ProfileManager.Interfaces;

namespace ProfileManager.Validators
{
    public class CountryValidator : IValidator
    {
        public bool IsValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Country cannot be empty.");
                return false;
            }

            if (input.Length > 50)
            {
                Console.WriteLine("Country cannot be more than 50 characters long.");
                return false;
            }

            foreach (char c in input)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    Console.WriteLine("Country can only contain letters and spaces.");
                    return false;
                }
            }
            return true;
        }
    }
}
