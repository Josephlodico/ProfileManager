using ProfileManager.Helpers;
using ProfileManager.Models;

namespace ProfileManager.Services
{
    public class MenuService
    {
        private static readonly string[] MainMenuOptions =
        [
            "1. Create New Profile",
            "2. View a Profile",
            "3. Search/Filter Profiles",
            "4. Edit a Profile",
            "5. Delete a Profile",
            "6. Undo Delete",
            "7. Find Duplicate Profiles",
            "8. Sort Profiles",
            "9. Profile Stats/Summary View",
            "10. Save Profiles (JSON)",
            "11. Export Profiles (CSV)",
            "12. Exit",
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
                        {
                            var newProfile = ProfileService.CreateProfile(validators);
                            var duplicates = ProfileService.FindMatchesForNewProfile(profiles, newProfile);

                            if (duplicates.Count > 0)
                            {
                                Console.WriteLine();
                                Console.WriteLine($"Warning: this looks like a possible duplicate of {duplicates.Count} existing profile(s):");
                                foreach (var d in duplicates)
                                    Console.WriteLine($"- {d.FirstName} {d.LastName} | Email: {d.Email} | Phone: {d.PhoneNumber}");

                                if (!ProfileService.Confirm("Add this profile anyway"))
                                {
                                    Console.WriteLine("Profile creation cancelled.");
                                    break;
                                }
                            }

                            profiles.Add(newProfile);
                            Console.WriteLine("Profile created.");
                            break;
                        }

                    case "2":
                        {
                            int index = ProfileService.SelectProfileIndex(profiles, "view");
                            if (index >= 0)
                                ProfileService.DisplayProfile(profiles[index]);
                            break;
                        }

                    case "3":
                        ProfileService.SearchProfiles(profiles);
                        break;

                    case "4":
                        {
                            int index = ProfileService.SelectProfileIndex(profiles, "edit");
                            if (index >= 0)
                                ProfileService.EditProfile(profiles[index], validators);
                            break;
                        }

                    case "5":
                        {
                            int index = ProfileService.SelectProfileIndex(profiles, "delete");
                            if (index >= 0 && ProfileService.Confirm("Are you sure you want to delete this profile"))
                            {
                                var deleted = profiles[index];
                                profiles.RemoveAt(index);
                                ProfileService.RecordDeletion(deleted, index);
                                Console.WriteLine("Profile deleted.");
                            }
                            break;
                        }

                    case "6":
                        ProfileService.TryUndoDelete(profiles);
                        break;

                    case "7":
                        ProfileService.FindAndDisplayDuplicates(profiles);
                        break;

                    case "8":
                        ProfileService.SortProfiles(profiles);
                        break;

                    case "9":
                        ProfileService.ShowProfileStats(profiles);
                        break;

                    case "10":
                        {
                            string path = ProfileService.SaveProfilesToJson(profiles);
                            Console.WriteLine($"Profiles saved to {path}");
                            if (ProfileService.Confirm("Open the file now"))
                                ProfileService.OpenFile(path);
                            break;
                        }

                    case "11":
                        {
                            if (profiles.Count == 0)
                            {
                                Console.WriteLine("No profiles to export.");
                                break;
                            }

                            string path = ProfileService.ExportProfilesToCsv(profiles);
                            Console.WriteLine($"Profiles exported to {path}");
                            if (ProfileService.Confirm("Open the file now"))
                                ProfileService.OpenFile(path);
                            break;
                        }

                    case "12":
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
