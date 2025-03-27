namespace ComicBookApi.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }

        public ICollection<ComicEvent>? ComicEvents { get; set; }
    }
}
