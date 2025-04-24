namespace ComicBookApi.DTOs
{
    public class ComicDTO
    {
        public int ComicId { get; set; }
        public string Title { get; set; }
        public string IssueNumber { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public string? SeriesTitle { get; set; } // from Series navigation property
    }
}
