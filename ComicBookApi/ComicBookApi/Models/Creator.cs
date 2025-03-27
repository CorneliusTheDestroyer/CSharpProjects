namespace ComicBookApi.Models
{
    public class Creator
    {
        public int CreatorId { get; set; }
        public string FullName { get; set; }
        public string? Role { get; set; }

        public ICollection<ComicCreator>? ComicCreators { get; set; }
    }
}
