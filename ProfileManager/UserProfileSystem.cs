using ProfileManager.Models;
using ProfileManager.Interfaces;
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
            IValidator nameValidator = new NameValidator(20);
            IValidator genderValidator = new GenderValidator();
            IValidator ageValidator = new AgeValidator();
            IValidator dateOfBirthValidator = new DateOfBirthValidator();

            IValidator emailValidator = new EmailValidator();
            IValidator phoneValidator = new PhoneValidator();
            IValidator addressValidator = new AddressValidator();

            IValidator countryValidator = new CountryValidator();
            IValidator provinceValidator = new ProvinceValidator();
            IValidator textValidator = new TextValidator();

            MainTitle();
            var p = new Profile();

            SectionTitle("Profile Information");

            p.FirstName = GetValidInput("Enter First Name: ", nameValidator);
            GetSpacing();
            p.LastName = GetValidInput("Enter Last Name: ", nameValidator);
            GetSpacing();
            p.Gender = GetValidInput("Enter Gender: ", genderValidator);
            GetSpacing();
            p.Age = Convert.ToInt32(GetValidInput("Enter Age: ", ageValidator));
            GetSpacing();
            p.DateOfBirth = DateTime.Parse(GetValidInput("Enter Date of Birth (yyyy-MM-dd): ", dateOfBirthValidator));
            GetSpacing();

            SectionTitle("Contact Information");

            p.Email = GetValidInput("Enter Email: ", emailValidator);
            GetSpacing();
            p.PhoneNumber = GetValidInput("Enter Phone Number: ", phoneValidator);
            GetSpacing();
            p.Address = GetValidInput("Enter Address: ", addressValidator);
            GetSpacing();


            SectionTitle("Location");

            p.Country = GetValidInput("Enter Country: ", countryValidator);
            GetSpacing();
            p.Province = GetValidInput("Enter Province: ", provinceValidator);
            GetSpacing();


            SectionTitle("Hobbies and Interests");

            p.Hobby = GetValidInput("Enter Hobby: ", textValidator);
            GetSpacing();

            p.FavoriteGame = GetValidInput("Enter Favorite Game: ", textValidator);
            GetSpacing();

            p.FavoriteAnime = GetValidInput("Enter Favorite Anime: ", textValidator);
            GetSpacing();

            p.Pets = GetValidInput("Enter your Favorite Pet: ", textValidator);
            GetSpacing();

            SectionTitle("Physical Information");

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

        public static void GetSpacing()
        {
            Console.WriteLine("==========================================");
        }
        
        public static void SectionTitle(string title)
        {
            Console.WriteLine();
            Console.WriteLine($"Topic: {title}");
            Console.WriteLine("------------------------------------------");
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
            Console.WriteLine($"Gender: {p.Gender}");
            Console.WriteLine($"Age: {p.Age}");
            Console.WriteLine($"Date of Birth: {p.DateOfBirth}");

            Console.WriteLine($"Email: {p.Email}");
            Console.WriteLine($"Phone Number: {p.PhoneNumber}");
            Console.WriteLine($"Address: {p.Address}");

            Console.WriteLine($"Country: {p.Country}");
            Console.WriteLine($"Province: {p.Province}");

            Console.WriteLine($"Hobby: {p.Hobby}");
            Console.WriteLine($"Favorite Game: {p.FavoriteGame}");
            Console.WriteLine($"Favorite Anime: {p.FavoriteAnime}");
            Console.WriteLine($"Pet: {p.Pets}");

            Console.WriteLine($"Weight: {p.Weight}");
            Console.WriteLine($"Height: {p.Height}");

            
        }

        
    }
}
