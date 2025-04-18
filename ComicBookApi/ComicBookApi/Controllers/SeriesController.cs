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
    public class SeriesController : ControllerBase
    {
        private readonly ComicDbContext _context;
        private readonly IMapper _mapper;

        public SeriesController(ComicDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeriesDTO>>> GetSeries()
        {
            var seriesList = await _context.Series.ToListAsync();
            var dtoList = _mapper.Map<List<SeriesDTO>>(seriesList);

            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SeriesDTO>> GetSeries(int id)
        {
            var series = await _context.Series.FindAsync(id);

            if (series == null)
                return NotFound();

            var dto = _mapper.Map<SeriesDTO>(series);
            return Ok(dto);
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
