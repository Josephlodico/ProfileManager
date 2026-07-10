using System.Diagnostics;
using System.Text;
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
            p.DateOfBirth = DateTime.Parse(ConsoleHelper.GetValidInput("Enter Date of Birth (yyyy-MM-dd): ", validators.DateOfBirth));
            ConsoleHelper.GetSpacing();

            ConsoleHelper.SectionTitle("Contact Information");

            p.Email = ConsoleHelper.GetValidInput("Enter Email: ", validators.Email);
            ConsoleHelper.GetSpacing();
            p.PhoneNumber = ConsoleHelper.GetValidInput("Enter Phone Number: ", validators.Phone);
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

        public static string SaveProfilesToFile(List<Profile> profiles, string fileName = "Profiles.txt")
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            var sb = new StringBuilder();

            for (int i = 0; i < profiles.Count; i++)
            {
                sb.AppendLine($"Profile #{i + 1}");
                sb.Append(FormatProfile(profiles[i]));
                sb.AppendLine();
            }

            File.WriteAllText(path, sb.ToString());
            return path;
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
