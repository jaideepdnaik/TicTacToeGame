namespace TicTacToe.Web.Models;

public class GameState
{
    public required char[] Board { get; set; }
    public char CurrentPlayer { get; set; }
    public required string? Winner { get; set; }
}