using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ComicBookApi.Data;
using ComicBookApi.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new ComicDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ComicDbContext>>());

        if (context.Series.Any()) return;

        var seriesList = Enumerable.Range(1, 5).Select(i => new Series { Title = $"Series {i}" }).ToList();
        var characters = Enumerable.Range(1, 10).Select(i => new Character { Name = $"Character {i}" }).ToList();
        var creators = Enumerable.Range(1, 10).Select(i => new Creator { FullName = $"Creator {i}" }).ToList();
        var eventsList = Enumerable.Range(1, 3).Select(i => new Event { Title = $"Event {i}", Description = $"Event {i} desc" }).ToList();
        var stories = Enumerable.Range(1, 5).Select(i => new Story { Title = $"Story {i}", Summary = $"Story {i} details" }).ToList();

        context.Series.AddRange(seriesList);
        context.Characters.AddRange(characters);
        context.Creators.AddRange(creators);
        context.Events.AddRange(eventsList);
        context.Stories.AddRange(stories);
        context.SaveChanges();

        var comics = Enumerable.Range(1, 20).Select(i =>
        {
            var comic = new Comic
            {
                Title = $"Comic {i}",
                IssueNumber = $"{i:000}",
                ReleaseDate = DateTime.Today.AddDays(-i * 30),
                SeriesId = seriesList[i % seriesList.Count].SeriesId
            };
            return comic;
        }).ToList();

        context.Comics.AddRange(comics);
        context.SaveChanges();

        // Link comics to characters, creators, events
        var comicCharacters = comics.SelectMany(comic => characters.Take(2).Select(c => new ComicCharacter
        {
            ComicId = comic.ComicId,
            CharacterId = c.CharacterId
        })).ToList();

        var comicCreators = comics.SelectMany(comic => creators.Take(2).Select(c => new ComicCreator
        {
            ComicId = comic.ComicId,
            CreatorId = c.CreatorId
        })).ToList();

        var comicEvents = comics.SelectMany(comic => eventsList.Take(1).Select(e => new ComicEvent
        {
            ComicId = comic.ComicId,
            EventId = e.EventId
        })).ToList();

        context.ComicCharacters.AddRange(comicCharacters);
        context.ComicCreators.AddRange(comicCreators);
        context.ComicEvents.AddRange(comicEvents);
        context.SaveChanges();
    }
}