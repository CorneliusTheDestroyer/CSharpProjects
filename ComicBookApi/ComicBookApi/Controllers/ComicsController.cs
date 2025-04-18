using ComicBookApi.Data;
using ComicBookApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ComicBookApi.DTOs;

namespace ComicBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicsController : ControllerBase
    {
        private readonly ComicDbContext _context;
        private readonly IMapper _mapper;

        public ComicsController(ComicDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ComicDTO>> CreateComic([FromBody] ComicCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comic = _mapper.Map<Comic>(dto);
            _context.Comics.Add(comic);
            await _context.SaveChangesAsync();

            // Reload with Series for mapping back to DTO
            var createdComic = await _context.Comics
                .Include(c => c.Series)
                .FirstOrDefaultAsync(c => c.ComicId == comic.ComicId);

            var result = _mapper.Map<ComicDTO>(createdComic);
            return CreatedAtAction(nameof(GetComic), new { id = result.ComicId }, result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComicDTO>>> GetComics()
        {
            var comic = await _context.Comics
                .Include(c => c.Series) // Needed for SeriesTitle mapping
                .ToListAsync();

            var comicDTOs = _mapper.Map<List<ComicDTO>>(comic);

            return Ok(comicDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComicDTO>> GetComic(int id)
        {
            var comic = await _context.Comics
                .Include(c => c.Series)
                .FirstOrDefaultAsync(c => c.ComicId == id);

            if (comic == null)
                return NotFound();

            var comicDTO = _mapper.Map<ComicDTO>(comic);
            return Ok(comicDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComic(int id, [FromBody] ComicCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comic = await _context.Comics.FindAsync(id);
            if (comic == null)
                return NotFound();

            _mapper.Map(dto, comic); // apply changes from DTO to entity
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComic(int id)
        {
            var comic = await _context.Comics.FindAsync(id);
            if (comic == null)
            {
                return NotFound();
            }

            _context.Comics.Remove(comic);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
