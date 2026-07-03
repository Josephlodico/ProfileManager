using System;
using ProfileManager.Helpers;
using ProfileManager.Models;

namespace ProfileManager.Services
{
    public static class ProfileService
    {
        public static bool Confirm(string message)
        {
            while (true)
            {
                Console.Write($"{message} (y/n): ");
                string input = Console.ReadLine()!.Trim().ToLower();

                if (input == "y" || input == "yes")
                    return true;
                if (input == "n" || input == "no")
                    return false;

                Console.WriteLine("Please enter 'y' or 'n'.");
            }
        }

        public static void EditProfile(Profile p, ProfileValidators validators)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("===== EDIT PROFILE =====");
                Console.WriteLine("1. First Name");
                Console.WriteLine("2. Last Name");
                Console.WriteLine("3. Gender");
                Console.WriteLine("4. Age");
                Console.WriteLine("5. Date of Birth");
                Console.WriteLine("6. Email");
                Console.WriteLine("7. Phone Number");
                Console.WriteLine("8. Address");
                Console.WriteLine("9. Country");
                Console.WriteLine("10. Province");
                Console.WriteLine("11. Hobby");
                Console.WriteLine("12. Favorite Game");
                Console.WriteLine("13. Favorite Anime");
                Console.WriteLine("14. Pet");
                Console.WriteLine("15. Weight");
                Console.WriteLine("16. Height");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Choose a field to edit: ");

                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        p.FirstName = ConsoleHelper.GetValidInput("Enter First Name: ", validators.Name);
                        break;
                    case "2":
                        p.LastName = ConsoleHelper.GetValidInput("Enter Last Name: ", validators.Name);
                        break;
                    case "3":
                        p.Gender = ConsoleHelper.GetValidInput("Enter Gender: ", validators.Gender);
                        break;
                    case "4":
                        p.Age = Convert.ToInt32(ConsoleHelper.GetValidInput("Enter Age: ", validators.Age));
                        break;
                    case "5":
                        p.DateOfBirth = DateTime.Parse(ConsoleHelper.GetValidInput("Enter Date of Birth (yyyy-MM-dd): ", validators.DateOfBirth));
                        break;
                    case "6":
                        p.Email = ConsoleHelper.GetValidInput("Enter Email: ", validators.Email);
                        break;
                    case "7":
                        p.PhoneNumber = ConsoleHelper.GetValidInput("Enter Phone Number: ", validators.Phone);
                        break;
                    case "8":
                        p.Address = ConsoleHelper.GetValidInput("Enter Address: ", validators.Address);
                        break;
                    case "9":
                        p.Country = ConsoleHelper.GetValidInput("Enter Country: ", validators.Country);
                        break;
                    case "10":
                        p.Province = ConsoleHelper.GetValidInput("Enter Province: ", validators.Province);
                        break;
                    case "11":
                        p.Hobby = ConsoleHelper.GetValidInput("Enter Hobby: ", validators.Text);
                        break;
                    case "12":
                        p.FavoriteGame = ConsoleHelper.GetValidInput("Enter Favorite Game: ", validators.Text);
                        break;
                    case "13":
                        p.FavoriteAnime = ConsoleHelper.GetValidInput("Enter Favorite Anime: ", validators.Text);
                        break;
                    case "14":
                        p.Pets = ConsoleHelper.GetValidInput("Enter your Favorite Pet: ", validators.Text);
                        break;
                    case "15":
                        p.Weight = ConsoleHelper.GetDoubleInput("Enter Weight (kg): ");
                        break;
                    case "16":
                        p.Height = ConsoleHelper.GetDoubleInput("Enter Height (cm): ");
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
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
