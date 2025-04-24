using System.ComponentModel.DataAnnotations;

namespace ComicBookApi.DTOs
{
    public class StoryCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(50)]
        public string? Type { get; set; }

        [MaxLength(1000)]
        public string? Synopsis { get; set; }

        [Required]
        public int ComicId { get; set; }
    }
}
