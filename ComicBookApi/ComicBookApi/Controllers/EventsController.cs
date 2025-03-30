using ComicBookApi.Data;
using ComicBookApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComicBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ComicDbContext _context;

        public EventsController(ComicDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var comicEvent = await _context.Events.FindAsync(id);

            if (comicEvent == null)
            {
                return NotFound();
            }

            return comicEvent;
        }

        [HttpPost]
        public async Task<ActionResult<Event>> CreateEvent([FromBody] Event comicEvent)
        {
            _context.Events.Add(comicEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEvent), new { id = comicEvent.EventId }, comicEvent);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] Event comicEvent)
        {
            if (id != comicEvent.EventId)
            {
                return BadRequest();
            }

            _context.Entry(comicEvent).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Events.Any(e => e.EventId == id))
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
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var comicEvent = await _context.Events.FindAsync(id);
            
            if (comicEvent == null)
            {
                return NotFound();
            }

            _context.Events.Remove(comicEvent);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
    }
}
