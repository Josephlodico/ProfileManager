using ProfileManager.Interfaces;

namespace ProfileManager.Validators
{
    public class GenderValidator : IValidator
    {
        public bool IsValid(string input)
        {
            input = input.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Gender cannot be empty.");
                return false;
            }

            if (input == "male" || input == "female" || input == "other")
            {
                return true;
            }
            Console.WriteLine("Gender must be Male, Female, or Other.");
            return false;
        }
    }
}
