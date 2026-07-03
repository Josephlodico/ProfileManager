using ProfileManager.Interfaces;

namespace ProfileManager.Validators
{
    public class DateOfBirthValidator: IValidator
    {
        public bool IsValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Date of Birth cannot be empty.");
                return false;
            }

            if (!DateTime.TryParseExact(
                input,
                "yyyy-MM-dd",
                null,
                System.Globalization.DateTimeStyles.None,
                out DateTime dateOfBirth))
            {
                Console.WriteLine("Please use the format yyyy-MM-dd.");
                return false;
            }

            if (dateOfBirth > DateTime.Today)
            {
                Console.WriteLine("Date of Birth cannot be in the future.");
                return false;
            }

            return true;
        }
    }
}
