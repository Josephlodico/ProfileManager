using ProfileManager.Interfaces;

namespace ProfileManager.Validators
{
    public class EmailValidator : IValidator
    {
        public bool IsValid(string input)
        {

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Email cannot be empty.");
                return false;
            }

            if (!input.Contains("@"))
            {
                Console.WriteLine("Email must contain @.");
                return false;
            }

            string[] parts = input.Split('@');
            if (parts.Length != 2)
            {
                Console.WriteLine("Email can only contain one @.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(parts[0]))
            {
                Console.WriteLine("Email must have a name before @.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(parts[1]))
            {
                Console.WriteLine("Email must have an email type after @.");
                return false;
            }

            string domain = parts[1];
            int dotIndex = domain.LastIndexOf('.');
            if (dotIndex <= 0 || dotIndex == domain.Length - 1)
            {
                Console.WriteLine("Email must have a valid domain (e.g., example.com, example.ca).");
                return false;
            }
            return true;
        }
    }
}
