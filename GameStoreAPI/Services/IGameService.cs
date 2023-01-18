using GameStore.API.Models;

namespace GameStore.API.Services;

public interface IGameService
{
    Task<GameDto> GetGameById(int gameId);
    Task<IReadOnlyCollection<GameDto>> GetGames();
    Task<GameDto> AddGame(GameDto newGame);
    Task UpdateGame(GameDto gameToUpdate);
    Task DeleteGame(int gameId);
}