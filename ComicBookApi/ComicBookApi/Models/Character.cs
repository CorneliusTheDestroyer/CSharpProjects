namespace ComicBookApi.Models
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public string? Alias { get; set; }

        public ICollection<ComicCharacter>? ComicCharacters { get; set; }
    }
}
