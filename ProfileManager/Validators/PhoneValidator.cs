using ProfileManager.Interfaces;

namespace ProfileManager.Validators
{
    public class PhoneValidator : IValidator
    {
        public bool IsValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Phone number cannot be empty.");
                return false;
            }

            foreach (char c in input)
            {
                if (!char.IsDigit(c) && c != '-')
                {
                    Console.WriteLine("Phone number must contain only digits and dashes.");
                    return false;
                }
            }

            int digitCount = input.Count(char.IsDigit);

            if (digitCount != 10)
            {
                Console.WriteLine("Phone number must be 10 digits.");
                return false;
            }

            return true;
        }
    }
}
