using System.ComponentModel.DataAnnotations;

namespace ComicBookApi.DTOs
{
    public class CharacterCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string? Alias { get; set; }
    }
}
