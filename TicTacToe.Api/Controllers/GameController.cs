using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Services;
using TicTacToe.Api.Models.DTO;
using TicTacToe.Core.Models;

namespace TicTacToe.Api.Controllers;

[ApiController]
[Route("api/[controller]/game")]
public class GameController(TicTacToeGame game) : ControllerBase
{
    [HttpPost("new")]
    public IActionResult NewGame()
    {
        game.GameReset();
        return Ok(new
        {
            Board = game.GetBoard(),
            CurrentPlayer = game.GetCurrentPlayer()
        });
    }

    [HttpPost("makeMove")]
    [Consumes("application/x-www-form-urlencoded", "application/json")]    
    public IActionResult MakeMove(MakeMoveDto requestDto)
    {
        if (!game.MakeMove(requestDto.Position))
        {
            return BadRequest("Invalid Move.");
        }
        
        var winner = game.CheckWinner();
        return Ok(new
        {
            Board = game.GetBoard(),
            CurrentPlayer = game.GetCurrentPlayer(),
            Winner = winner
        });
    }

    [HttpGet("state")]
    public IActionResult GetState()
    {
        return Ok(new
        {
            Board = game.GetBoard(),
            CurrentPlayer = game.GetCurrentPlayer(),
            Winner = game.CheckWinner()
        });
    }
}