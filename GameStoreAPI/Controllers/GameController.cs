using GameStore.API.Models;
using GameStore.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class GamesController : ControllerBase
{
    private readonly IGameService _gameService;

    public GamesController(
        IGameService gameService
    )
    {
        _gameService = gameService;
    }
    // GET ALL RECORDS
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _gameService.GetGames());
    }
    // GET SINGLE RECORD BY ID
    [HttpGet("{gameId}")]
    public async Task<IActionResult> Get(int gameId)
    {
        return Ok(await _gameService.GetGameById(gameId));
    }
    // ADD RECORD
    [HttpPost]
    public async Task<IActionResult> Post(GameDto gameModel)
    {
        if (gameModel is null) return BadRequest();

        return Ok(await _gameService.AddGame(gameModel));
    }
    // MODIFY RECORD
    [HttpPut]
    public async Task<IActionResult> Put(GameDto gameModel)
    {
        if (gameModel is null) return BadRequest();

        await _gameService.UpdateGame(gameModel);

        return Ok();
    }
    // DELETE RECORD BY ID 
    [HttpDelete("{gameId}")]
    public async Task<IActionResult> Delete(int gameId)
    {
        await _gameService.DeleteGame(gameId);

        return NoContent();
    }
}