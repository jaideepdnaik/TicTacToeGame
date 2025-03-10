using System.Text.Json.Serialization;

namespace TicTacToe.Api.Models.DTO;

public class MakeMoveDto
{
    [JsonPropertyName("position")]
    public int Position { get; set; }
}