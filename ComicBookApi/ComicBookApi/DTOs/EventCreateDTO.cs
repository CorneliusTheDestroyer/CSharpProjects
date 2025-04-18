using System.ComponentModel.DataAnnotations;

namespace ComicBookApi.DTOs
{
    public class EventCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
