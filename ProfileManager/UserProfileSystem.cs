using ProfileManager.Classes;
using System;
using System.Collections.Generic;
/*                              USER PROFILE SYSTEM                           */
namespace ProfileManager
{
    class userProfileSystem
    {
        static void Main(string[] args)
        {
            var p = new Profile();

            //Name of User
            p.FirstName = Validation.GetValidName("Enter FirstName: ");
            p.LastName = Validation.GetValidName("Enter LastName: ");

            //Email of User
            p.Email = Validation.GetValidEmail();

            // Basic Info
            p.PhoneNumber = GetInput("Enter Phone Number: ");
            p.Address = GetInput("Enter Address: ");
            p.Gender = GetInput("Enter Gender: ");

            // Numbers
            p.Age = GetIntInput("Enter Age: ");

            // Location
            p.Country = GetInput("Enter Country: ");
            p.Province = GetInput("Enter Province: ");

            // Date
            p.DateOfBirth = GetDateInput("Enter Date of Birth (yyyy-MM-dd): ");

            // Favorites
            p.Hobby = GetInput("Enter Hobby");
            p.FavoriteGame = GetInput("Enter Favorite Game: ");
            p.FavoriteAnime = GetInput("Enter Favorite Anime: ");
            p.Pets = GetInput("Enter your Favorite Pet: ");

            //Physical Info
            p.Weight = GetDoubleInput("Enter Weigth (kg): ");
            p.Height = GetDoubleInput("Enter Height (cm)L ");

            Console.Clear();

            DisplayProfile(p);
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
            Console.Write(message);
            return Convert.ToInt32(Console.ReadLine());
        }

        //Date INPUT
        public static DateTime GetDateInput(string message)
        {
            Console.Write(message);
            return Convert.ToDateTime(Console.ReadLine());
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
