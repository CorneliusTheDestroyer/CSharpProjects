namespace ComicBookApi.Models
{
    public class ComicEvent
    {
        public int ComicId { get; set; }
        public Comic Comic { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
