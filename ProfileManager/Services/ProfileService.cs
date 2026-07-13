using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using ProfileManager.Helpers;
using ProfileManager.Models;

namespace ProfileManager.Services
{
    public static class ProfileService
    {
        private static readonly string[] EditFieldOptions =
        [
            "1. First Name",
            "2. Last Name",
            "3. Gender",
            "4. Age",
            "5. Date of Birth",
            "6. Email",
            "7. Phone Number",
            "8. Address",
            "9. Country",
            "10. Province",
            "11. Hobby",
            "12. Favorite Game",
            "13. Favorite Anime",
            "14. Pet",
            "15. Weight",
            "16. Height",
            "0. Back to Main Menu",
        ];

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

        public static Profile CreateProfile(ProfileValidators validators)
        {
            var p = new Profile();

            ConsoleHelper.SectionTitle("Profile Information");

            p.FirstName = ConsoleHelper.GetValidInput("Enter First Name: ", validators.Name);
            ConsoleHelper.GetSpacing();
            p.LastName = ConsoleHelper.GetValidInput("Enter Last Name: ", validators.Name);
            ConsoleHelper.GetSpacing();
            p.Gender = ConsoleHelper.GetValidInput("Enter Gender: ", validators.Gender);
            ConsoleHelper.GetSpacing();
            p.Age = Convert.ToInt32(ConsoleHelper.GetValidInput("Enter Age: ", validators.Age));
            ConsoleHelper.GetSpacing();
            p.DateOfBirth = DateTime.Parse(ConsoleHelper.GetValidMaskedInput("Enter Date of Birth (yyyy-MM-dd): ", validators.DateOfBirth, "####-##-##"));
            ConsoleHelper.GetSpacing();

            ConsoleHelper.SectionTitle("Contact Information");

            p.Email = ConsoleHelper.GetValidInput("Enter Email: ", validators.Email);
            ConsoleHelper.GetSpacing();
            p.PhoneNumber = ConsoleHelper.GetValidMaskedInput("Enter Phone Number: ", validators.Phone, "###-###-####");
            ConsoleHelper.GetSpacing();
            p.Address = ConsoleHelper.GetValidInput("Enter Address: ", validators.Address);
            ConsoleHelper.GetSpacing();

            ConsoleHelper.SectionTitle("Location");

            p.Country = ConsoleHelper.GetValidInput("Enter Country: ", validators.Country);
            ConsoleHelper.GetSpacing();
            p.Province = ConsoleHelper.GetValidInput("Enter Province: ", validators.Province);
            ConsoleHelper.GetSpacing();

            ConsoleHelper.SectionTitle("Hobbies and Interests");

            p.Hobby = ConsoleHelper.GetValidInput("Enter Hobby: ", validators.Text);
            ConsoleHelper.GetSpacing();

            p.FavoriteGame = ConsoleHelper.GetValidInput("Enter Favorite Game: ", validators.Text);
            ConsoleHelper.GetSpacing();

            p.FavoriteAnime = ConsoleHelper.GetValidInput("Enter Favorite Anime: ", validators.Text);
            ConsoleHelper.GetSpacing();

            p.Pets = ConsoleHelper.GetValidInput("Enter your Favorite Pet: ", validators.Text);
            ConsoleHelper.GetSpacing();

            ConsoleHelper.SectionTitle("Physical Information");

            p.Weight = ConsoleHelper.GetDoubleInput("Enter Weight (kg): ");
            p.Height = ConsoleHelper.GetDoubleInput("Enter Height (cm): ");

            return p;
        }

        public static void EditProfile(Profile p, ProfileValidators validators)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("===== EDIT PROFILE =====");
                ConsoleHelper.WriteMenu(EditFieldOptions);
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
                        p.DateOfBirth = DateTime.Parse(ConsoleHelper.GetValidMaskedInput("Enter Date of Birth (yyyy-MM-dd): ", validators.DateOfBirth, "####-##-##"));
                        break;
                    case "6":
                        p.Email = ConsoleHelper.GetValidInput("Enter Email: ", validators.Email);
                        break;
                    case "7":
                        p.PhoneNumber = ConsoleHelper.GetValidMaskedInput("Enter Phone Number: ", validators.Phone, "###-###-####");
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

        public static string FormatProfile(Profile p)
        {
            var sb = new StringBuilder();

            sb.AppendLine("===== PROFILE =====");
            sb.AppendLine($"Name: {p.FirstName} {p.LastName}");
            sb.AppendLine($"Gender: {p.Gender}");
            sb.AppendLine($"Age: {p.Age}");
            sb.AppendLine($"Date of Birth: {p.DateOfBirth:yyyy-MM-dd}");
            sb.AppendLine($"Email: {p.Email}");
            sb.AppendLine($"Phone Number: {p.PhoneNumber}");
            sb.AppendLine($"Address: {p.Address}");
            sb.AppendLine($"Country: {p.Country}");
            sb.AppendLine($"Province: {p.Province}");
            sb.AppendLine($"Hobby: {p.Hobby}");
            sb.AppendLine($"Favorite Game: {p.FavoriteGame}");
            sb.AppendLine($"Favorite Anime: {p.FavoriteAnime}");
            sb.AppendLine($"Pet: {p.Pets}");
            sb.AppendLine($"Weight: {p.Weight}");
            sb.AppendLine($"Height: {p.Height}");

            return sb.ToString();
        }

        public static void DisplayProfile(Profile p)
        {
            Console.Write(FormatProfile(p));
        }

        private static readonly string[] SearchFieldOptions =
        [
            "1. First Name",
            "2. Last Name",
            "3. Email",
            "4. Phone Number",
            "5. Country",
            "6. Province",
            "7. Age Range",
            "0. Cancel",
        ];

        public static void SearchProfiles(List<Profile> profiles)
        {
            if (profiles.Count == 0)
            {
                Console.WriteLine("No profiles to search.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("===== SEARCH / FILTER PROFILES =====");
            ConsoleHelper.WriteMenu(SearchFieldOptions);
            Console.Write("Choose a field to search by: ");
            string choice = Console.ReadLine()!;

            List<Profile> matches;

            switch (choice)
            {
                case "1":
                    matches = FilterByText(profiles, "First Name", p => p.FirstName);
                    break;
                case "2":
                    matches = FilterByText(profiles, "Last Name", p => p.LastName);
                    break;
                case "3":
                    matches = FilterByText(profiles, "Email", p => p.Email);
                    break;
                case "4":
                    matches = FilterByText(profiles, "Phone Number", p => p.PhoneNumber);
                    break;
                case "5":
                    matches = FilterByText(profiles, "Country", p => p.Country);
                    break;
                case "6":
                    matches = FilterByText(profiles, "Province", p => p.Province);
                    break;
                case "7":
                    matches = FilterByAgeRange(profiles);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    return;
            }

            if (matches.Count == 0)
            {
                Console.WriteLine("No matching profiles found.");
                return;
            }

            Console.WriteLine($"Found {matches.Count} matching profile(s):");
            for (int i = 0; i < matches.Count; i++)
                Console.WriteLine($"{i + 1}. {matches[i].FirstName} {matches[i].LastName}");

            Console.Write("Enter a number to view that profile (0 to skip): ");
            string input = Console.ReadLine()!;

            if (input == "0")
                return;

            if (int.TryParse(input, out int index) && index >= 1 && index <= matches.Count)
                DisplayProfile(matches[index - 1]);
            else
                Console.WriteLine("Invalid selection.");
        }

        private static List<Profile> FilterByText(List<Profile> profiles, string fieldName, Func<Profile, string?> selector)
        {
            Console.Write($"Enter {fieldName} to search for: ");
            string term = Console.ReadLine()!.Trim();

            return profiles
                .Where(p => (selector(p) ?? "").Contains(term, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        private static List<Profile> FilterByAgeRange(List<Profile> profiles)
        {
            int min = ConsoleHelper.GetIntInput("Enter minimum age: ");
            int max = ConsoleHelper.GetIntInput("Enter maximum age: ");

            return profiles.Where(p => p.Age >= min && p.Age <= max).ToList();
        }

        public static void ListProfiles(List<Profile> profiles)
        {
            Console.WriteLine($"You have {profiles.Count} profile(s).");

            for (int i = 0; i < profiles.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {profiles[i].FirstName} {profiles[i].LastName}");
            }
        }

        public static int SelectProfileIndex(List<Profile> profiles, string action)
        {
            if (profiles.Count == 0)
            {
                Console.WriteLine($"No profiles to {action}.");
                return -1;
            }

            ListProfiles(profiles);
            Console.Write($"Enter the number of the profile to {action} (0 to cancel): ");
            string input = Console.ReadLine()!;

            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Invalid selection.");
                return -1;
            }

            if (choice >= 1 && choice <= profiles.Count)
                return choice - 1;

            if (choice != 0)
                Console.WriteLine("Invalid selection.");

            return -1;
        }

        private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

        public static string SaveProfilesToJson(List<Profile> profiles, string fileName = "Profiles.json")
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            File.WriteAllText(path, JsonSerializer.Serialize(profiles, JsonOptions));
            return path;
        }

        public static List<Profile> LoadProfilesFromJson(string fileName = "Profiles.json")
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            if (!File.Exists(path))
                return [];

            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Profile>>(json) ?? [];
        }

        public static void OpenFile(string path)
        {
            try
            {
                Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not open the file automatically: {ex.Message}");
            }
        }
    }
}
