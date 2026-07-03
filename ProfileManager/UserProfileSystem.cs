using ProfileManager.Models;
using ProfileManager.Validators;
using ProfileManager.Services;
using ProfileManager.Helpers;
using System;

/*                              USER PROFILE SYSTEM                           */
namespace ProfileManager
{
    class UserProfileSystem
    {
        static void Main()
        {
            var validators = new ProfileValidators(
                name: new NameValidator(20),
                gender: new GenderValidator(),
                age: new AgeValidator(),
                dateOfBirth: new DateOfBirthValidator(),
                email: new EmailValidator(),
                phone: new PhoneValidator(),
                address: new AddressValidator(),
                country: new CountryValidator(),
                province: new ProvinceValidator(),
                text: new TextValidator());

            ConsoleHelper.MainTitle();
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

            Console.Clear();

            ProfileService.DisplayProfile(p);

            var menuService = new MenuService();
            menuService.ShowMenu(ref p, validators);
        }
    }
}
