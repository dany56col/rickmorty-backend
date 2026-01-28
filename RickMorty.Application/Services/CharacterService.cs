using System.Text.Json;
using RickMorty.Application.DTOs;
using RickMorty.Application.External;
using RickMorty.Application.Interfaces;
using RickMorty.Domain.Entities;

namespace RickMorty.Application.Services;

public class CharacterService
{
    private readonly IRickMortyClient _api;
    private readonly ICharacterRepository _repo;

    public CharacterService(
        IRickMortyClient api,
        ICharacterRepository repo)
    {
        _api = api;
        _repo = repo;
    }

    // Listado + cache
    public async Task<RickMortyApiResponse> GetCharactersAsync(string query)
    {
        var apiResult = await _api.GetCharactersAsync(query);

        foreach (var item in apiResult.Results)
        {
            var cached = await _repo.GetByIdAsync(item.Id);

            if (cached == null)
            {
                var entity = new Character
                {
                    Id = item.Id,
                    Name = item.Name,
                    Status = item.Status,
                    Species = item.Species,
                    Image = item.Image,
                    Location = item.Location.Name,

                    // 👇 Guardamos episodios como JSON
                    Episodes = JsonSerializer.Serialize(item.Episode),

                    LastSync = DateTime.UtcNow
                };

                await _repo.AddAsync(entity);
            }
        }

        await _repo.SaveAsync();

        return apiResult;
    }

    // Detalle + cache
    public async Task<Character> GetByIdAsync(int id)
    {
        var cached = await _repo.GetByIdAsync(id);

        if (cached != null)
            return cached;

        var apiData = await _api.GetByIdAsync(id);

        var entity = new Character
        {
            Id = apiData.Id,
            Name = apiData.Name,
            Status = apiData.Status,
            Species = apiData.Species,
            Image = apiData.Image,
            Location = apiData.Location.Name,

            // 👇 Guardamos episodios
            Episodes = JsonSerializer.Serialize(apiData.Episode),

            LastSync = DateTime.UtcNow
        };

        await _repo.AddAsync(entity);
        await _repo.SaveAsync();

        return entity;
    }
}
