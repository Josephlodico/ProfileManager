using System.Diagnostics;
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
            "4. Relationship Status",
            "5. Age",
            "6. Date of Birth",
            "7. Email",
            "8. Phone Number",
            "9. Address",
            "10. Country",
            "11. Province",
            "12. Hobby",
            "13. Favorite Game",
            "14. Favorite Anime",
            "15. Pet",
            "16. Favorite Music Artist",
            "17. Favorite Movie",
            "18. Favorite TV Show",
            "19. Favorite Song",
            "20. Favorite Sport",
            "21. Weight",
            "22. Height",
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
            p.RelationshipStatus = ConsoleHelper.GetValidInput("Enter Relationship Status: ", validators.Text);
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

            ConsoleHelper.SectionTitle("Entertainment");

            p.MusicArtist = ConsoleHelper.GetValidInput("Enter Favorite Music Artist: ", validators.Text);
            ConsoleHelper.GetSpacing();

            p.Movie = ConsoleHelper.GetValidInput("Enter Favorite Movie: ", validators.Text);
            ConsoleHelper.GetSpacing();

            p.TVShow = ConsoleHelper.GetValidInput("Enter Favorite TV Show: ", validators.Text);
            ConsoleHelper.GetSpacing();

            p.Song = ConsoleHelper.GetValidInput("Enter Favorite Song: ", validators.Text);
            ConsoleHelper.GetSpacing();

            p.Sport = ConsoleHelper.GetValidInput("Enter Favorite Sport: ", validators.Text);
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
                        p.RelationshipStatus = ConsoleHelper.GetValidInput("Enter Relationship Status: ", validators.Text);
                        break;
                    case "5":
                        p.Age = Convert.ToInt32(ConsoleHelper.GetValidInput("Enter Age: ", validators.Age));
                        break;
                    case "6":
                        p.DateOfBirth = DateTime.Parse(ConsoleHelper.GetValidMaskedInput("Enter Date of Birth (yyyy-MM-dd): ", validators.DateOfBirth, "####-##-##"));
                        break;
                    case "7":
                        p.Email = ConsoleHelper.GetValidInput("Enter Email: ", validators.Email);
                        break;
                    case "8":
                        p.PhoneNumber = ConsoleHelper.GetValidMaskedInput("Enter Phone Number: ", validators.Phone, "###-###-####");
                        break;
                    case "9":
                        p.Address = ConsoleHelper.GetValidInput("Enter Address: ", validators.Address);
                        break;
                    case "10":
                        p.Country = ConsoleHelper.GetValidInput("Enter Country: ", validators.Country);
                        break;
                    case "11":
                        p.Province = ConsoleHelper.GetValidInput("Enter Province: ", validators.Province);
                        break;
                    case "12":
                        p.Hobby = ConsoleHelper.GetValidInput("Enter Hobby: ", validators.Text);
                        break;
                    case "13":
                        p.FavoriteGame = ConsoleHelper.GetValidInput("Enter Favorite Game: ", validators.Text);
                        break;
                    case "14":
                        p.FavoriteAnime = ConsoleHelper.GetValidInput("Enter Favorite Anime: ", validators.Text);
                        break;
                    case "15":
                        p.Pets = ConsoleHelper.GetValidInput("Enter your Favorite Pet: ", validators.Text);
                        break;
                    case "16":
                        p.MusicArtist = ConsoleHelper.GetValidInput("Enter Favorite Music Artist: ", validators.Text);
                        break;
                    case "17":
                        p.Movie = ConsoleHelper.GetValidInput("Enter Favorite Movie: ", validators.Text);
                        break;
                    case "18":
                        p.TVShow = ConsoleHelper.GetValidInput("Enter Favorite TV Show: ", validators.Text);
                        break;
                    case "19":
                        p.Song = ConsoleHelper.GetValidInput("Enter Favorite Song: ", validators.Text);
                        break;
                    case "20":
                        p.Sport = ConsoleHelper.GetValidInput("Enter Favorite Sport: ", validators.Text);
                        break;
                    case "21":
                        p.Weight = ConsoleHelper.GetDoubleInput("Enter Weight (kg): ");
                        break;
                    case "22":
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
            sb.AppendLine($"Relationship Status: {p.RelationshipStatus}");
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
            sb.AppendLine($"Favorite Music Artist: {p.MusicArtist}");
            sb.AppendLine($"Favorite Movie: {p.Movie}");
            sb.AppendLine($"Favorite TV Show: {p.TVShow}");
            sb.AppendLine($"Favorite Song: {p.Song}");
            sb.AppendLine($"Favorite Sport: {p.Sport}");
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

        private static bool IsDuplicate(Profile a, Profile b)
        {
            if (!string.IsNullOrWhiteSpace(a.Email) && string.Equals(a.Email, b.Email, StringComparison.OrdinalIgnoreCase))
                return true;

            if (!string.IsNullOrWhiteSpace(a.PhoneNumber) && string.Equals(a.PhoneNumber, b.PhoneNumber, StringComparison.OrdinalIgnoreCase))
                return true;

            if (!string.IsNullOrWhiteSpace(a.FirstName) && !string.IsNullOrWhiteSpace(a.LastName) &&
                string.Equals(a.FirstName, b.FirstName, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(a.LastName, b.LastName, StringComparison.OrdinalIgnoreCase) &&
                a.DateOfBirth == b.DateOfBirth)
                return true;

            return false;
        }

        public static List<Profile> FindMatchesForNewProfile(List<Profile> profiles, Profile candidate)
        {
            return profiles.Where(p => IsDuplicate(p, candidate)).ToList();
        }

        public static List<List<Profile>> FindDuplicateGroups(List<Profile> profiles)
        {
            var groups = new List<List<Profile>>();
            var seen = new HashSet<Profile>();

            for (int i = 0; i < profiles.Count; i++)
            {
                if (seen.Contains(profiles[i]))
                    continue;

                var group = new List<Profile> { profiles[i] };

                for (int j = i + 1; j < profiles.Count; j++)
                {
                    if (seen.Contains(profiles[j]))
                        continue;

                    if (IsDuplicate(profiles[i], profiles[j]))
                    {
                        group.Add(profiles[j]);
                        seen.Add(profiles[j]);
                    }
                }

                if (group.Count > 1)
                {
                    groups.Add(group);
                    seen.Add(profiles[i]);
                }
            }

            return groups;
        }

        public static void FindAndDisplayDuplicates(List<Profile> profiles)
        {
            if (profiles.Count == 0)
            {
                Console.WriteLine("No profiles to check.");
                return;
            }

            var groups = FindDuplicateGroups(profiles);

            if (groups.Count == 0)
            {
                Console.WriteLine("No duplicate profiles found.");
                return;
            }

            Console.WriteLine($"Found {groups.Count} group(s) of possible duplicates:");

            for (int g = 0; g < groups.Count; g++)
            {
                Console.WriteLine();
                Console.WriteLine($"--- Duplicate Group {g + 1} ---");

                foreach (var p in groups[g])
                {
                    int index = profiles.IndexOf(p);
                    Console.WriteLine($"{index + 1}. {p.FirstName} {p.LastName} | Email: {p.Email} | Phone: {p.PhoneNumber} | DOB: {p.DateOfBirth:yyyy-MM-dd}");
                }
            }
        }

        private static readonly string[] SortFieldOptions =
        [
            "1. First Name",
            "2. Last Name",
            "3. Age",
            "4. Date of Birth",
            "5. Country",
            "6. Province",
            "0. Cancel",
        ];

        public static void SortProfiles(List<Profile> profiles)
        {
            if (profiles.Count == 0)
            {
                Console.WriteLine("No profiles to sort.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("===== SORT PROFILES =====");
            ConsoleHelper.WriteMenu(SortFieldOptions);
            Console.Write("Choose a field to sort by: ");
            string choice = Console.ReadLine()!;

            Comparison<Profile> comparison;

            switch (choice)
            {
                case "1":
                    comparison = (a, b) => string.Compare(a.FirstName, b.FirstName, StringComparison.OrdinalIgnoreCase);
                    break;
                case "2":
                    comparison = (a, b) => string.Compare(a.LastName, b.LastName, StringComparison.OrdinalIgnoreCase);
                    break;
                case "3":
                    comparison = (a, b) => a.Age.CompareTo(b.Age);
                    break;
                case "4":
                    comparison = (a, b) => a.DateOfBirth.CompareTo(b.DateOfBirth);
                    break;
                case "5":
                    comparison = (a, b) => string.Compare(a.Country, b.Country, StringComparison.OrdinalIgnoreCase);
                    break;
                case "6":
                    comparison = (a, b) => string.Compare(a.Province, b.Province, StringComparison.OrdinalIgnoreCase);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    return;
            }

            if (!Confirm("Sort ascending"))
            {
                var ascending = comparison;
                comparison = (a, b) => ascending(b, a);
            }

            profiles.Sort(comparison);
            Console.WriteLine("Profiles sorted.");
            ListProfiles(profiles);
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
