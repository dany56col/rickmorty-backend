using Microsoft.AspNetCore.Mvc;
using RickMorty.Application.Services;

namespace RickMorty.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharactersController : ControllerBase
{
    private readonly CharacterService _service;

    public CharactersController(CharacterService service)
    {
        _service = service;
    }

    // GET: api/characters
    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery] int page = 1,
        [FromQuery] string? name = null,
        [FromQuery] string? status = null,
        [FromQuery] string? species = null)
    {
        var query = $"page={page}";

        if (!string.IsNullOrWhiteSpace(name))
            query += $"&name={name}";

        if (!string.IsNullOrWhiteSpace(status))
            query += $"&status={status}";

        if (!string.IsNullOrWhiteSpace(species))
            query += $"&species={species}";

        var result = await _service.GetCharactersAsync(query);

        return Ok(result);
    }

    // GET: api/characters/1
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);

        return Ok(result);
    }
}
