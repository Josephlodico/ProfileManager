using System.Collections.Generic;
using ProfileManager.Helpers;
using ProfileManager.Models;
//Testing new branch called Development
namespace ProfileManager.Services
{
    public class MenuService
    {
        private static readonly string[] MainMenuOptions =
        [
            "1. Create New Profile",
            "2. View a Profile",
            "3. Edit a Profile",
            "4. Delete a Profile",
            "5. Save Profiles to File",
            "6. Exit",
        ];

        public static void ShowMenu(List<Profile> profiles, ProfileValidators validators)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("===== MENU =====");
                Console.WriteLine($"You have {profiles.Count} profile(s).");
                ConsoleHelper.WriteMenu(MainMenuOptions);
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        profiles.Add(ProfileService.CreateProfile(validators));
                        Console.WriteLine("Profile created.");
                        break;

                    case "2":
                        {
                            int index = ProfileService.SelectProfileIndex(profiles, "view");
                            if (index >= 0)
                                ProfileService.DisplayProfile(profiles[index]);
                            break;
                        }

                    case "3":
                        {
                            int index = ProfileService.SelectProfileIndex(profiles, "edit");
                            if (index >= 0)
                                ProfileService.EditProfile(profiles[index], validators);
                            break;
                        }

                    case "4":
                        {
                            int index = ProfileService.SelectProfileIndex(profiles, "delete");
                            if (index >= 0 && ProfileService.Confirm("Are you sure you want to delete this profile"))
                            {
                                profiles.RemoveAt(index);
                                Console.WriteLine("Profile deleted.");
                            }
                            break;
                        }

                    case "5":
                        {
                            string path = ProfileService.SaveProfilesToFile(profiles);
                            Console.WriteLine($"Profiles saved to {path}");
                            if (ProfileService.Confirm("Open the file in Notepad now"))
                                ProfileService.OpenFile(path);
                            break;
                        }

                    case "6":
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
