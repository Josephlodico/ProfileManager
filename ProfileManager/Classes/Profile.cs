/*                              USER PROFILE SYSTEM                           */
namespace ProfileManager.Classes
{
    public class Profile
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }

        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? Country { get; set; }
        public string? Province { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string? Hobby { get; set; }  
        public string? FavoriteGame { get; set; }
        public string? FavoriteAnime { get; set; }
        public string? Pets { get; set; }


        public double Weight { get; set; }
        public double Height { get; set; }

       
    }
}
