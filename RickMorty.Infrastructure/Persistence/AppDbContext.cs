using Microsoft.EntityFrameworkCore;
using RickMorty.Domain.Entities;

namespace RickMorty.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Character> Characters => Set<Character>();
}
