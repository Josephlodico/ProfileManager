/*                              USER PROFILE SYSTEM                           */
namespace ProfileManager.Classes
{
    public class Profile
    {
        // Basic Information
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }

        // Personal Information
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? RelationshipStatus { get; set; }



        // Location
        public string? Country { get; set; }
        public string? Province { get; set; }

        // Dates
        public DateTime DateOfBirth { get; set; }

        // Favorites
        public string? Hobby { get; set; }  
        public string? FavoriteGame { get; set; }
        public string? FavoriteAnime { get; set; }
        public string? Pets { get; set; }

        //Entertainment
        public string? MusicArtist { get; set; }
        public string? Movie { get; set; }
        public string? TVShow { get; set; }
        public string? Song { get; set; }
        public string? Sport { get; set; }

        // Physical Information
        public double Weight { get; set; }
        public double Height { get; set; }

       
    }
}
