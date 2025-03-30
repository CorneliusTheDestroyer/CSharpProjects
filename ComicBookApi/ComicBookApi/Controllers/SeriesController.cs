using ComicBookApi.Data;
using ComicBookApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComicBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly ComicDbContext _context;

        public SeriesController(ComicDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Series>>> GetSeries()
        {
            return await _context.Series
                .Include(s => s.Comics)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Series>> GetSeries(int id)
        {
            var series = await _context.Series
                .Include(s => s.Comics)
                .FirstOrDefaultAsync(s => s.SeriesId == id);

            if (series == null)
            {
                return NotFound();
            }

            return series;
        }

        [HttpPost]
        public async Task<ActionResult<Series>> CreateSeries([FromBody] Series series)
        {
            _context.Series.Add(series);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSeries), new { id = series.SeriesId }, series);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeries(int id, [FromBody] Series series)
        {
            if (id != series.SeriesId)
            {
                return BadRequest();
            }

            _context.Entry(series).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Series.Any(s => s.SeriesId == id))
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
        public async Task<IActionResult> DeleteSeries(int id)
        {
            var series = await _context.Series.FindAsync(id);

            if (series == null)
            {
                return NotFound();
            }

            _context.Series.Remove(series);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
