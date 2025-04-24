using System.ComponentModel.DataAnnotations;

namespace ComicBookApi.DTOs
{
    public class ComicCreateDTO
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(50)]
        public string? IssueNumber { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Required]
        public int SeriesId { get; set; }
    }
}
