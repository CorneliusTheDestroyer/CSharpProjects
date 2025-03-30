using ComicBookApi.Data;
using ComicBookApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComicBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private readonly ComicDbContext _context;

        public StoriesController(ComicDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Story>>> GetStories()
        {
            return await _context.Stories
                .Include(s => s.Comic)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Story>> GetStory(int id)
        {
            var story = await _context.Stories
                .Include(s => s.Comic)
                .FirstOrDefaultAsync(s => s.StoryId == id);
            
            if (story == null)
            {
                return NotFound();
            }

            return story;
        }

        [HttpPost]
        public async Task<ActionResult<Story>> CreateStory([FromBody] Story story)
        {
            _context.Stories.Add(story);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStory), new { id = story.StoryId }, story);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStory(int id, [FromBody] Story story)
        {
            if (id != story.StoryId)
            {
                return BadRequest();
            }

            _context.Entry(story).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Stories.Any(s => s.StoryId == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStory(int id)
        {
            var story = await _context.Stories.FindAsync(id);
            
            if (story == null)
            {
                return NotFound();
            }

            _context.Stories.Remove(story);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
    }
}
