using ProfileManager.Classes;

/*                              USER PROFILE SYSTEM                           */
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

            if (input.Length != 10)
            {
                Console.WriteLine("Phone number must be 10 digits.");
                return false;
            }

            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    Console.WriteLine("Phone number must contain only digits.");
                    return false;
                }
            }
            return true;
        }
    }
}

