namespace ComicBookApi.DTOs
{
    public class StoryDTO
    {
        public int StoryId { get; set; }

        public string Title { get; set; }

        public string? Type { get; set; }

        public string? Synopsis { get; set; }

        public int ComicId { get; set; }

        public string? ComicTitle { get; set; }  // from Comic.Title
    }
}
