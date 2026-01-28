using RickMorty.Domain.Entities;

namespace RickMorty.Application.Interfaces;

public interface ICharacterRepository
{
    Task<Character?> GetByIdAsync(int id);

    Task<List<Character>> GetAllAsync();

    Task AddAsync(Character character);

    Task SaveAsync();
}

