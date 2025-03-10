namespace TicTacToe.Core.Models;

public class TicTacToeGame
{
    private readonly char[] _board; 
    private char _currentPlayer;
    
    public TicTacToeGame()
    {
        _board = new char[9];
        for (var i = 0; i < 9; i++)
        {
            _board[i] = ' ';
        }
        _currentPlayer = 'X';
    }

    public bool MakeMove(int position)
    {
        if (_board[position] != ' ' || position < 0 || position >= 9)
        {
            return false;
        }
        
        _board[position] = _currentPlayer;
        _currentPlayer = _currentPlayer == 'X' ? 'O' : 'X';
        return true;
    }

    public string? CheckWinner()
    {
        // Define all winning combinations(3 rows, 3 columns, 2 diagonals)
        var winningCombinations = new[]
        {
            new[] {0, 1, 2},
            new[] {3, 4, 5},
            new[] {6, 7, 8},
            new[] {0, 3, 6},
            new[] {1, 4, 7},
            new[] {2, 5, 8},
            new[] {0, 4, 8},
            new[] {2, 4, 6}
        };

        // Check for winning condition
        foreach (var combination in winningCombinations)
        {
            if (_board[combination[0]] != ' ' && _board[combination[0]] == _board[combination[1]] && _board[combination[1]] == _board[combination[2]])
            {
                return _board[combination[0]].ToString();
            }
        }

        // Check for draw condition
        return _board.All(cell => cell != ' ') ? "Draw" : null;
    }
    
    public void GameReset()
    {
        for (var i = 0; i < 9; i++)
        {
            _board[i] = ' ';
        }
    }
    
    public char[] GetBoard()
    {
        return (char[])_board.Clone();
    }
    
    public char GetCurrentPlayer()
    {
        return _currentPlayer;
    }
}