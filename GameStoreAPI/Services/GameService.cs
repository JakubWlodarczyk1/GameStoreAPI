using GameStore.API.Data;
using GameStore.API.Domain;
using GameStore.API.Exceptions;
using GameStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Services;

public class GameService : IGameService
{
    private readonly DataContext _dataContext;

    public GameService(
        DataContext dataContext
    )
    {
        _dataContext = dataContext;
    }

    public async Task<GameDto> GetGameById(int gameId)
    {
        var entity = await _dataContext.Games.FindAsync(gameId);

        if (entity is null) throw new NotFoundException($"Game with ID of {gameId} doesn't exist in database.");

        return MapEntityToDto(entity);
    }

    public async Task<IReadOnlyCollection<GameDto>> GetGames()
    {
        var entities = await _dataContext.Games.ToListAsync();

        return MapEntitiesToDtos(entities);
    }

    public async Task<GameDto> AddGame(GameDto newGame)
    {
        var newEntity = new Game(
            newGame.Title,
            newGame.Price,
            newGame.Quantity
        );

        _dataContext.Games.Add(newEntity);
        await _dataContext.SaveChangesAsync();

        return MapEntityToDto(newEntity);
    }

    public async Task UpdateGame(GameDto gameToUpdate)
    {
        var entity = await _dataContext.Games.FindAsync(gameToUpdate.Id);

        if (entity is null) throw new NotFoundException($"Game with ID of {gameToUpdate.Id} doesn't exist in database.");

        entity.Title = gameToUpdate.Title;
        entity.Price = gameToUpdate.Price;
        entity.Quantity = gameToUpdate.Quantity;

        _dataContext.Update(entity);
        await _dataContext.SaveChangesAsync();
    }

    public async Task DeleteGame(int gameId)
    {
        var entity = await _dataContext.Games.FindAsync(gameId);

        if (entity is null) throw new NotFoundException($"Game with ID of {gameId} doesn't exist in database.");

        _dataContext.Games.Remove(entity);
        await _dataContext.SaveChangesAsync();
    }

    // MAPS OBJECT FROM DATABASE
    private GameDto MapEntityToDto(Game entity)
    {
        return new()
        {
            Id = entity.Id,
            Price = entity.Price,
            Quantity = entity.Quantity,
            Title = entity.Title
        };
    }

    // OBJECT LIST MAPPING
    private IReadOnlyCollection<GameDto> MapEntitiesToDtos(IEnumerable<Game> entities)
    {
        var dtos = new List<GameDto>();

        foreach (var entity in entities)
            dtos.Add(MapEntityToDto(entity));

        return dtos.AsReadOnly();
    }
}