using RickMorty.Application.DTOs;

namespace RickMorty.Application.External;

public interface IRickMortyClient
{
    Task<RickMortyApiResponse> GetCharactersAsync(string query);

    Task<RickMortyCharacterDto> GetByIdAsync(int id);
}
