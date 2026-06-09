using ProfileManager.Classes;
using ProfileManager.Validators;
using System;
using System.Collections.Generic;

/*                              USER PROFILE SYSTEM                           */
namespace ProfileManager
{
    class UserProfileSystem
    {
        static void Main(string[] args)
        {
            IValidator emailValidator = new EmailValidator();
            IValidator nameValidator = new NameValidator(20);
            IValidator phoneValidator = new PhoneValidator();
            IValidator genderValidator = new GenderValidator();
            IValidator ageValidator = new AgeValidator();
            IValidator addressValidator = new AddressValidator();
            IValidator countryValidator = new CountryValidator();
            IValidator provinceValidator = new ProvinceValidator();

            MainTitle();
            var p = new Profile();

            //Name of User
            p.FirstName = GetValidInput("Enter First Name: ", nameValidator);
            GetSpacing();

            p.LastName = GetValidInput("Enter Last Name: ", nameValidator);
            GetSpacing();

            //Email of User
            p.Email = GetValidInput("Enter Email: ", emailValidator);
            GetSpacing();

            // Basic Info
            p.PhoneNumber = GetValidInput("Enter Phone Number: ", phoneValidator);
            GetSpacing();
            
            p.Address = GetValidInput("Enter Address: ", addressValidator);
            GetSpacing();

            p.Gender = GetValidInput("Enter Gender: ", genderValidator);
            GetSpacing();

            // Numbers
            p.Age = Convert.ToInt32(GetValidInput("Enter Age: ", ageValidator));
            GetSpacing();
            // Location
            p.Country = GetValidInput("Enter Country: ", countryValidator);
            p.Province = GetValidInput("Enter Province: ", provinceValidator);

            // Date
            p.DateOfBirth = GetDateInput("Enter Date of Birth (yyyy-MM-dd): ");

            // Favorites
            p.Hobby = GetInput("Enter Hobby: ");
            p.FavoriteGame = GetInput("Enter Favorite Game: ");
            p.FavoriteAnime = GetInput("Enter Favorite Anime: ");
            p.Pets = GetInput("Enter your Favorite Pet: ");

            //Physical Info
            p.Weight = GetDoubleInput("Enter Weight (kg): ");
            p.Height = GetDoubleInput("Enter Height (cm): ");

            Console.Clear();

            DisplayProfile(p);
        }
        public static string GetValidInput(string message, IValidator validator)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine()!;

                if (validator.IsValid(input))
                {
                    return input;
                }
                Console.WriteLine("Invalid input. Try again.");
            }
        }
        // STRING INPUT
        public static string GetInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine()!;
            
        }

        // INTEGER INPUT
        public static int GetIntInput(string message)
        {
            Console.Write(message);
            return Convert.ToInt32(Console.ReadLine());
        }

        //Double Input
        public static double GetDoubleInput(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out double result))
                    return result;
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        //Date INPUT
        public static DateTime GetDateInput(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime result))
                    return result;
                Console.WriteLine("Invalid date. Please use the format yyyy-MM-dd (e.g., 2000-01-25).");
            }
        }
        public static void GetSpacing()
        {
            Console.WriteLine("=========================================");
        }
        

        public static void MainTitle()
        {
            Console.Clear();
            string title = "PROFILE MANAGER";
            Console.WriteLine(new string('=', Console.WindowWidth));
            int spaces = (Console.WindowWidth - title.Length) / 2;
            Console.WriteLine(new string(' ', spaces) + title);
            Console.WriteLine(new string('=', Console.WindowWidth));
        }

        public static void DisplayProfile(Profile p)
        {
            Console.WriteLine("===== PROFILE =====");

            Console.WriteLine($"Name: {p.FirstName} {p.LastName}");
            Console.WriteLine($"Email: {p.Email}");
            Console.WriteLine($"Phone Number: {p.PhoneNumber}");
            Console.WriteLine($"Address: {p.Address}");

            Console.WriteLine($"Age: {p.Age}");
            Console.WriteLine($"Gender: {p.Gender}");
            Console.WriteLine($"Country: {p.Country}");
            Console.WriteLine($"Province: {p.Province}");
            Console.WriteLine($"Date of Birth: {p.DateOfBirth}");

            Console.WriteLine($"Hobby: {p.Hobby}");
            Console.WriteLine($"Favorite Game: {p.FavoriteGame}");
            Console.WriteLine($"Favorite Anime: {p.FavoriteAnime}");
            Console.WriteLine($"Pet: {p.Pets}");

            Console.WriteLine($"Weight: {p.Weight}");
            Console.WriteLine($"Height: {p.Height}");
        }
    }
}
