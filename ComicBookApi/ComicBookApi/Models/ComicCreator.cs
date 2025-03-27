namespace ComicBookApi.Models
{
    public class ComicCreator
    {
        public int ComicId { get; set; }
        public Comic Comic { get; set; }

        public int CreatorId { get; set; }
        public Creator Creator { get; set; }
    }
}
