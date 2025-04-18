using System.ComponentModel.DataAnnotations;

namespace ComicBookApi.DTOs
{
    public class CreatorCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string? Role { get; set; }
    }
}
