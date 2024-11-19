using PgmTest.GameFieldObjects;

namespace PgmTest.Pieces;

public abstract class Piece : IPiece
{
    public Point Position { get; set; }
    public abstract bool CanMove(Point destination, MoveChecker checker);

    public Piece(Point position)
    {
        Position = position;
    }

    public Piece()
    {
        Position = new Point(0, 0);
    }
    
    public override string ToString() => $"{Position.X} {Position.Y}";
}