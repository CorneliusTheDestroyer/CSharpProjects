using System.ComponentModel.DataAnnotations;

namespace ComicBookApi.DTOs
{
    public class SeriesCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
