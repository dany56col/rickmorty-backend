using RickMorty.Application.DTOs;
using RickMorty.Application.External;
using System.Net.Http.Json;

namespace RickMorty.Infrastructure.External;

public class RickMortyClient : IRickMortyClient
{
    private readonly HttpClient _http;

    public RickMortyClient(HttpClient http)
    {
        _http = http;
    }

    public async Task<RickMortyApiResponse> GetCharactersAsync(string query)
    {
        return await _http
            .GetFromJsonAsync<RickMortyApiResponse>($"character?{query}")
            ?? throw new Exception("Rick & Morty API error");
    }

    public async Task<RickMortyCharacterDto> GetByIdAsync(int id)
    {
        return await _http
            .GetFromJsonAsync<RickMortyCharacterDto>($"character/{id}")
            ?? throw new Exception("Rick & Morty API error");
    }
}

