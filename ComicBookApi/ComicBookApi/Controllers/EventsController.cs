using ComicBookApi.Data;
using ComicBookApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComicBookApi.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace ComicBookApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ComicDbContext _context;
        private readonly IMapper _mapper;

        public EventsController(ComicDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDTO>>> GetEvents()
        {
            var events = await _context.Events.ToListAsync();
            var dtoList = _mapper.Map<List<EventDTO>>(events);

            return Ok(dtoList);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<EventDTO>> GetEvent(int id)
        {
            var comicEvent = await _context.Events.FindAsync(id);

            if (comicEvent == null)
                return NotFound();

            var dto = _mapper.Map<EventDTO>(comicEvent);
            return Ok(dto);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<EventDTO>> CreateEvent([FromBody] EventCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comicEvent = _mapper.Map<Event>(dto);
            _context.Events.Add(comicEvent);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<EventDTO>(comicEvent);
            return CreatedAtAction(nameof(GetEvent), new { id = comicEvent.EventId }, result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] EventCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comicEvent = await _context.Events.FindAsync(id);
            if (comicEvent == null)
                return NotFound();

            _mapper.Map(dto, comicEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
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
