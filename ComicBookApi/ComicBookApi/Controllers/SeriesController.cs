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
        public async Task<ActionResult<SeriesDTO>> CreateSeries([FromBody] SeriesCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var series = _mapper.Map<Series>(dto);
            _context.Series.Add(series);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<SeriesDTO>(series);
            return CreatedAtAction(nameof(GetSeries), new { id = series.SeriesId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeries(int id, [FromBody] SeriesCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var series = await _context.Series.FindAsync(id);
            if (series == null)
                return NotFound();

            _mapper.Map(dto, series);
            await _context.SaveChangesAsync();

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
