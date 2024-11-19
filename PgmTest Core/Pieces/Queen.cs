using PgmTest.GameFieldObjects;

namespace PgmTest.Pieces;

public class Queen: Piece
{
    public Queen(): base() { }
    public Queen(Point point): base(point) { }

    public override bool CanMove(Point destination, MoveChecker checker)
    {
        return checker.CheckMove(destination, this);
    }
    
    public override string ToString()
    {
        return "Queen " + base.ToString();
    }
}