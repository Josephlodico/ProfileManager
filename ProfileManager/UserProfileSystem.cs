using ProfileManager.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Net;
using System.Reflection;


/*                              USER PROFILE SYSTEM                           */
namespace ProfileManager
{
    class userProfileSystem
    {
        static void Main(string[] args)
        {
            var profile = new Profile();

            Console.Write("Enter First Name: ");
            profile.FirstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            profile.LastName = Console.ReadLine();

            Console.Write("Enter Email: ");
            profile.Email = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            profile.PhoneNumber = Console.ReadLine();

            Console.Write("Enter Address: ");
            profile.Address = Console.ReadLine();

            Console.Write("Enter Gender: ");
            profile.Gender = Console.ReadLine();

            Console.Write("Enter Age: ");
            profile.Age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Country: ");
            profile.Country = Console.ReadLine();

            Console.Write("Enter Province: ");
            profile.Province = Console.ReadLine();

            Console.Write("Enter Date of Birth (yyyy-MM-dd): ");
            profile.DateOfBirth = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Enter Hobby: ");
            profile.Hobby = Console.ReadLine();

            Console.Write("Enter Favorite Game: ");
            profile.FavoriteGame = Console.ReadLine();

            Console.Write("Enter Favorite Anime: ");
            profile.FavoriteAnime = Console.ReadLine();

            Console.Write("Enter Pet: ");
            profile.Pet = Console.ReadLine();

            Console.Write("Enter Weight (kg): ");
            profile.Weight = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Height (cm): ");
            profile.Height = Convert.ToDouble(Console.ReadLine());

            Console.Clear();

             DisplayProfile(profile);
        }
        public static void DisplayProfile(Profile profile)
        {
            Console.WriteLine("===== PROFILE =====");

            Console.WriteLine($"Name: {profile.FirstName} {profile.LastName}");
            Console.WriteLine($"Email: {profile.Email}");
            Console.WriteLine($"Phone Number: {profile.PhoneNumber}");
            Console.WriteLine($"Address: {profile.Address}");

            Console.WriteLine($"Age: {profile.Age}");
            Console.WriteLine($"Gender: {profile.Gender}");
            Console.WriteLine($"Country: {profile.Country}");
            Console.WriteLine($"Province: {profile.Province}");
            Console.WriteLine($"Date of Birth: {profile.DateOfBirth}");

            Console.WriteLine($"Hobby: {profile.Hobby}");
            Console.WriteLine($"Favorite Game: {profile.FavoriteGame}");
            Console.WriteLine($"Favorite Anime: {profile.FavoriteAnime}");
            Console.WriteLine($"Pet: {profile.Pet}");

            Console.WriteLine($"Weight: {profile.Weight}");
            Console.WriteLine($"Height: {profile.Height}");
        }
    }
}
