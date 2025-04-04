﻿using ComicBookApi.Data;
using ComicBookApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComicBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicsController : ControllerBase
    {
        private readonly ComicDbContext _context;

        public ComicsController(ComicDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComic([FromBody] Comic comic)
        {
            _context.Comics.Add(comic);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetComic), new { id = comic.ComicId }, comic);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comic>>> GetComics()
        {
            return await _context.Comics
                .Include(c => c.Series)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comic>> GetComic(int id)
        {
            var comic = await _context.Comics
                .Include(c => c.Series)
                .FirstOrDefaultAsync(c => c.ComicId == id);

            if (comic == null)
            {
                return NotFound();
            }
            return comic;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComic(int id, [FromBody] Comic comic)
        {
            if (id != comic.ComicId)
            {
                return BadRequest();
            }

            _context.Entry(comic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Comics.Any(e => e.ComicId == id))
                    return NotFound();
                
                throw;
            }

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
