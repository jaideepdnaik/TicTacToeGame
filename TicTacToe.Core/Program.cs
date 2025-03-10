using TicTacToe.Core.Models;

namespace TicTacToe.Core;

class Program
{
    static void Main()
    {
        var game = new TicTacToeGame();
        
        game.MakeMove(0);
        game.MakeMove(3);
        game.MakeMove(1);
        game.MakeMove(4);
        game.MakeMove(2);
        
        var board = game.GetBoard();
        for (var i = 0; i < 9; i++)
        {
            Console.Write(board[i] + " ");
            if ((i + 1) % 3 == 0) Console.WriteLine();
        }

        var winner = game.CheckWinner();
        Console.WriteLine($"Winner: {(winner ?? "No winner yet")}");
    }
}