
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProfileManager.Interfaces;
using ProfileManager.Models;

namespace ProfileManager.Services
{
    public class MenuService
    {
        public void ShowMenu(
            ref Profile p,
            IValidator nameValidator,
            IValidator genderValidator,
            IValidator ageValidator,
            IValidator dateOfBirthValidator,
            IValidator emailValidator,
            IValidator phoneValidator,
            IValidator addressValidator,
            IValidator countryValidator,
            IValidator provinceValidator,
            IValidator textValidator)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("===== MENU =====");
                Console.WriteLine("1. View Profile");
                Console.WriteLine("2. Edit Profile");
                Console.WriteLine("3. Delete Profile");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        UserProfileSystem.DisplayProfile(p);
                        break;
                    case "2":
                        UserProfileSystem.EditProfile(
                            p,
                            nameValidator,
                            genderValidator,
                            ageValidator,
                            dateOfBirthValidator,
                            emailValidator,
                            phoneValidator,
                            addressValidator,
                            countryValidator,
                            provinceValidator,
                            textValidator);
                        break;
                    case "3":
                        if (UserProfileSystem.Confirm("Are you sure you want to delete this profile"))
                        {
                            p = new Profile(); // Reset the profile to a new instance
                            Console.WriteLine("Profile deleted.");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Exiting Profile Manager...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }

        }
    }
}
