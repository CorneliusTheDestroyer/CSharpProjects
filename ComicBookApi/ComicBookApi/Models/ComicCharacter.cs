namespace ComicBookApi.Models
{
    public class ComicCharacter
    {
        public int ComicId { get; set; }
        public Comic Comic { get; set; }

        public int CharacterId { get; set; }
        public Character Character { get; set; }

        public string? Role { get; set; }
    }
}
