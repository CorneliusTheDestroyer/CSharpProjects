using ComicBookApi.Data;
using ComicBookApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ComicBookApi.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;
using ComicBookApi.Responses;

namespace ComicBookApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ComicsController : ControllerBase
    {
        private readonly ComicDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public ComicsController(ComicDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        [Authorize(Roles = "Admin")]
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
        public async Task<ActionResult<IEnumerable<ComicDTO>>> GetComics(int pageNumber = 1, int pageSize = 10)
        {
            string cacheKey = $"ComicsPage - {pageNumber} - Size - {pageSize}";
            
            if (!_cache.TryGetValue(cacheKey, out List<ComicDTO> cachedComics))
            {
                var comic = await _context.Comics
                    .Include(c => c.Series)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                cachedComics = _mapper.Map<List<ComicDTO>>(comic);

                // Save to cache for 60 seconds
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(60));

                _cache.Set(cacheKey, cachedComics, cacheOptions);
                
            }

            return Ok(cachedComics);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComicDTO>> GetComic(int id)
        {
            var comic = await _context.Comics
                .Include(c => c.Series)
                .FirstOrDefaultAsync(c => c.ComicId == id);

            if (comic == null)
                return NotFound(ResponseHelper.Fail<ComicDTO>("Comic not found"));

            var comicDTO = _mapper.Map<ComicDTO>(comic);
            return Ok(ResponseHelper.Ok(comicDTO, "Comic retrieved successfully"));
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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
