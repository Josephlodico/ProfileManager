using ProfileManager.Models;
using ProfileManager.Validators;
using ProfileManager.Services;
using ProfileManager.Helpers;

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

            var profiles = new List<Profile>
            {
                ProfileService.CreateProfile(validators)
            };

            Console.Clear();

            ProfileService.DisplayProfile(profiles[0]);

            MenuService.ShowMenu(profiles, validators);
        }
    }
}
