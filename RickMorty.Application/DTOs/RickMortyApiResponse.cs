namespace RickMorty.Application.DTOs;

public class RickMortyApiResponse
{
    public ApiInfo Info { get; set; } = null!;
    public List<RickMortyCharacterDto> Results { get; set; } = [];
}

public class ApiInfo
{
    public int Count { get; set; }
    public int Pages { get; set; }
    public string? Next { get; set; }
    public string? Prev { get; set; }
}

