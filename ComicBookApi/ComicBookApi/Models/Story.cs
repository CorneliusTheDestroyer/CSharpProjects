namespace ComicBookApi.Models
{
    public class Story
    {
        public int StoryId { get; set; }
        public string Title { get; set; }
        public string? Summary { get; set; }

        public int ComicId { get; set; }
        public Comic Comic { get; set; }
    }
}
