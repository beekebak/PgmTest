using PgmTest.GameFieldObjects;
using PgmTest.Pieces;

namespace PgmTest;

public class InputParser
{
    public IPiece GetNewPiece(string input)
    {
        string[] parts = input.Split(' ');
        Point point = new Point(int.Parse(parts[1]), int.Parse(parts[2]));
        switch (parts[0])
        {
            case "bishop": return new Bishop(point);
            case "rook": return new Rook(point);
            case "knight": return new Knight(point);
            case "queen": return new Queen(point);
            case "king": return new King(point);
            case "shadow": return new Shadow(point);
            default: throw new ArgumentException($"Invalid piece type: {parts[0]} is not a valid piece type.");
        }
    }
}