using ComicBookApi.Data;
using ComicBookApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComicBookApi.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authorization;

namespace ComicBookApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ComicDbContext _context;
        private readonly IMapper _mapper;

        public CharactersController(ComicDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> GetCharacters()
        {
            var characters = await _context.Characters.ToListAsync();
            var characterDTOs = _mapper.Map<List<CharacterDTO>>(characters);
            return Ok(characterDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDTO>> GetCharacter(int id)
        {
            var character = await _context.Characters.FindAsync(id);

            if (character == null)
                return NotFound();
            
            var characterDTO = _mapper.Map<CharacterDTO>(character);
            return Ok(characterDTO);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CharacterDTO>> CreateCharacter([FromBody] CharacterCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var character = _mapper.Map<Character>(dto);
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            
            var result = _mapper.Map<CharacterDTO>(character);
            return CreatedAtAction(nameof(GetCharacter), new { id = character.CharacterId }, result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCharacter(int id, [FromBody] CharacterCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var character = await _context.Characters.FindAsync(id);
            if (character == null)
                return NotFound();

            _mapper.Map(dto, character); // update existing character with new values

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var character = await _context.Characters.FindAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
