using System.ComponentModel.DataAnnotations;

namespace ComicBookApi.DTOs
{
    public class UserRegisterDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public string Role { get; set; } = "User"; // Optional: defaults to "User"
    }
}
