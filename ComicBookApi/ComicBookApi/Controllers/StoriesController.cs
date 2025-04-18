using ComicBookApi.Data;
using ComicBookApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComicBookApi.DTOs;
using AutoMapper;

namespace ComicBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private readonly ComicDbContext _context;
        private readonly IMapper _mapper;

        public StoriesController(ComicDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoryDTO>>> GetStories()
        {
            var stories = await _context.Stories
                .Include(s => s.Comic) // needed for ComicTitle
                .ToListAsync();

            var dtoList = _mapper.Map<List<StoryDTO>>(stories);
            return Ok(dtoList);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<StoryDTO>> GetStory(int id)
        {
            var story = await _context.Stories
                .Include(s => s.Comic)
                .FirstOrDefaultAsync(s => s.StoryId == id);

            if (story == null)
                return NotFound();

            var dto = _mapper.Map<StoryDTO>(story);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<StoryDTO>> CreateStory([FromBody] StoryCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var story = _mapper.Map<Story>(dto);
            _context.Stories.Add(story);
            await _context.SaveChangesAsync();

            var result = await _context.Stories
                .Include(s => s.Comic)
                .FirstOrDefaultAsync(s => s.StoryId == story.StoryId);

            return CreatedAtAction(nameof(GetStory), new { id = result.StoryId }, _mapper.Map<StoryDTO>(result));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStory(int id, [FromBody] StoryCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var story = await _context.Stories.FindAsync(id);
            if (story == null)
                return NotFound();

            _mapper.Map(dto, story);
            await _context.SaveChangesAsync();

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
