using PgmTest.GameFieldObjects;

namespace PgmTest.Pieces;

public class Knight: Piece
{
    public Knight(): base() { }
    public Knight(Point point): base(point) { }

    public override bool CanMove(Point destination, MoveChecker checker)
    {
        return checker.CheckMove(destination, this);
    }
    
    public override string ToString()
    {
        return "Knight " + base.ToString();
    }
}