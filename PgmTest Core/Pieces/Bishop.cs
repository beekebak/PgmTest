using PgmTest.GameFieldObjects;

namespace PgmTest.Pieces;

public class Bishop: Piece
{
    public Bishop(): base() { }
    public Bishop(Point point): base(point) { }

    public override bool CanMove(Point destination, MoveChecker checker)
    {
        return checker.CheckMove(destination, this);
    }

    public override string ToString()
    {
        return "Bishop " + base.ToString();
    }
}