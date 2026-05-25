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
        }
        public void DisplayProfile()
        {
            var profile = new Profile();
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
