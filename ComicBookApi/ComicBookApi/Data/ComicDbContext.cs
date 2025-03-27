using ComicBookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ComicBookApi.Data
{
    public class ComicDbContext : DbContext
    {
        public ComicDbContext(DbContextOptions<ComicDbContext> options) : base(options)
        {
        }

        public DbSet<Comic> Comics { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<ComicCharacter> ComicCharacters { get; set; }
        public DbSet<Creator> Creators { get; set; }
        public DbSet<ComicCreator> ComicCreators { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<ComicEvent> ComicEvents { get; set; }
        public DbSet<Story> Stories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComicCharacter>()
                .HasKey(cc => new { cc.ComicId, cc.CharacterId });
            modelBuilder.Entity<ComicCreator>()
                .HasKey(cc => new { cc.ComicId, cc.CreatorId });
            modelBuilder.Entity<ComicEvent>()
                .HasKey(ce => new { ce.ComicId, ce.EventId });
        }
    }
}
