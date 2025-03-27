namespace ComicBookApi.Models
{
    public class Comic
    {
        public int ComicId { get; set; }
        public string? Title { get; set; }
        public string? IssueNumber { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public int SeriesId { get; set; }
        public Series? Series { get; set; }

        public ICollection<ComicCharacter>? ComicCharacters { get; set; }
        public ICollection<ComicCreator>? ComicCreators { get; set; }
        public ICollection<ComicEvent>? ComicEvents { get; set; }
        public ICollection<Story>? Stories { get; set; }
    }
}
