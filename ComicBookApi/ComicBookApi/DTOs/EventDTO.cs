namespace ComicBookApi.DTOs
{
    public class EventDTO
    {
        public int EventId { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
