namespace RickMorty.Domain.Entities;

public class Character
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string Species { get; set; } = null!;

    public string Image { get; set; } = null!;

    public string Location { get; set; } = null!;
    public string Episodes { get; set; } = string.Empty;

    public DateTime LastSync { get; set; }
}
