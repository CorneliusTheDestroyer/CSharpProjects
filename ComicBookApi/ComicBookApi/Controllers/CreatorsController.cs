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
    public class CreatorsController : ControllerBase
    {
        private readonly ComicDbContext _context;
        private readonly IMapper _mapper;

        public CreatorsController(ComicDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreatorDTO>>> GetCreators()
        {
            var creators = await _context.Creators.ToListAsync();
            var dtoList = _mapper.Map<List<CreatorDTO>>(creators);

            return Ok(dtoList);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CreatorDTO>> GetCreator(int id)
        {
            var creator = await _context.Creators.FindAsync(id);

            if (creator == null)
                return NotFound();

            var dto = _mapper.Map<CreatorDTO>(creator);
            return Ok(dto);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CreatorDTO>> CreateCreator([FromBody] CreatorCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var creator = _mapper.Map<Creator>(dto);
            _context.Creators.Add(creator);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<CreatorDTO>(creator);
            return CreatedAtAction(nameof(GetCreator), new { id = creator.CreatorId }, result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCreator(int id, [FromBody] CreatorCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var creator = await _context.Creators.FindAsync(id);
            if (creator == null)
                return NotFound();

            _mapper.Map(dto, creator);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
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
