using Microsoft.AspNetCore.Mvc;
using Milestone.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Milestone.Controllers
{
    [ApiController]
    [Route("api")]
    public class MinesweeperControllerAPI : ControllerBase
    {
        private readonly IGameService _gameService;

        public MinesweeperControllerAPI(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("showSavedGames")]
        public IActionResult ShowSavedGames()
        {
            List<GameDTO> savedGames = _gameService.GetSavedGames();
            return Ok(savedGames);
        }

        [HttpGet("showSavedGames/{gameId}")]
        public IActionResult ShowSavedGame(int gameId)
        {
            GameDTO game = _gameService.GetGameById(gameId);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        [HttpDelete("deleteOneGame/{gameId}")]
        public IActionResult DeleteOneGame(int gameId)
        {
            _gameService.DeleteGame(gameId);
            return NoContent();
        }

        [HttpPost("saveGame")]
        public IActionResult SaveGame(GameDTO game)
        {
            game.SaveDateTime = DateTime.Now;
            _gameService.SaveGame(game);
            return Ok();
        }
    }
}