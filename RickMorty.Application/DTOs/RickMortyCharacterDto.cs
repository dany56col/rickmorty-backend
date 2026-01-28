namespace RickMorty.Application.DTOs;

public class RickMortyCharacterDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string Species { get; set; } = null!;

    public string Image { get; set; } = null!;

    public LocationDto Location { get; set; } = null!;
    public List<string> Episode { get; set; } = new();
}

public class LocationDto
{
    public string Name { get; set; } = null!;
}
