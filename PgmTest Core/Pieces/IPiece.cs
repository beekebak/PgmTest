using PgmTest.GameFieldObjects;

namespace PgmTest.Pieces;

public interface IPiece
{
    public Point Position { get; set; }
    public bool CanMove(Point destination, MoveChecker checker);
}