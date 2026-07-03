using ProfileManager.Interfaces;

namespace ProfileManager.Models
{
    public class ProfileValidators
    {
        public IValidator Name { get; }
        public IValidator Gender { get; }
        public IValidator Age { get; }
        public IValidator DateOfBirth { get; }
        public IValidator Email { get; }
        public IValidator Phone { get; }
        public IValidator Address { get; }
        public IValidator Country { get; }
        public IValidator Province { get; }
        public IValidator Text { get; }

        public ProfileValidators(
            IValidator name,
            IValidator gender,
            IValidator age,
            IValidator dateOfBirth,
            IValidator email,
            IValidator phone,
            IValidator address,
            IValidator country,
            IValidator province,
            IValidator text)
        {
            Name = name;
            Gender = gender;
            Age = age;
            DateOfBirth = dateOfBirth;
            Email = email;
            Phone = phone;
            Address = address;
            Country = country;
            Province = province;
            Text = text;
        }
    }
}
