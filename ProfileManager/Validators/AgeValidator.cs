using ProfileManager.Classes;
                           
namespace ProfileManager.Validators
{
    public class AgeValidator : IValidator
    {
        public bool IsValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Age cannot be empty.");
                return false;
            }
            if (!int.TryParse(input, out int age))
            {
                Console.WriteLine("Age must be a valid number.");
                return false;
            }
            if (age < 0 || age > 120)
            {
                Console.WriteLine("Age must be between 0 and 120.");
                return false;
            }
            return true;
        }
    }
}

