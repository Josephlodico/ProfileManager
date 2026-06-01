using ProfileManager.Classes;

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

            //Must end with.com
            if (!parts[1].EndsWith(".com"))
            {
                Console.WriteLine("Email must end with .com");
                return false;
            }
            return true;
        }
    }
}
