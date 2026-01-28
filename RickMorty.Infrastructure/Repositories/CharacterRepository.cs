using Microsoft.EntityFrameworkCore;
using RickMorty.Application.Interfaces;
using RickMorty.Domain.Entities;
using RickMorty.Infrastructure.Persistence;

namespace RickMorty.Infrastructure.Repositories;

public class CharacterRepository : ICharacterRepository
{
    private readonly AppDbContext _db;

    public CharacterRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync(Character character)
    {
        await _db.Characters.AddAsync(character);
    }

    public Task<List<Character>> GetAllAsync()
    {
        return _db.Characters.ToListAsync();
    }

    public Task<Character?> GetByIdAsync(int id)
    {
        return _db.Characters.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task SaveAsync()
    {
        return _db.SaveChangesAsync();
    }
}
