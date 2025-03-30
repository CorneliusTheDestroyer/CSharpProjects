using ComicBookApi.Data;
using ComicBookApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComicBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatorsController : ControllerBase
    {
        private readonly ComicDbContext _context;

        public CreatorsController(ComicDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Creator>>> GetCreators()
        {
            return await _context.Creators.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Creator>> GetCreator(int id)
        {
            var creator = await _context.Creators.FindAsync(id);

            if (creator == null)
            {
                return NotFound();
            }

            return creator;
        }

        [HttpPost]
        public async Task<ActionResult<Creator>> CreateCreator([FromBody] Creator creator)
        {
            _context.Creators.Add(creator);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCreator), new { id = creator.CreatorId }, creator);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCreator(int id, [FromBody] Creator creator)
        {
            if (id != creator.CreatorId)
            {
                return BadRequest();
            }

            _context.Entry(creator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Creators.Any(cr => cr.CreatorId == id))
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
        public async Task<IActionResult> DeleteCreator(int id)
        {
            var creator = await _context.Creators.FindAsync(id);

            if (creator == null)
            {
                return NotFound();
            }

            _context.Creators.Remove(creator);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
