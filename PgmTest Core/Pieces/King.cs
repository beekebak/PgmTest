using PgmTest.GameFieldObjects;

namespace PgmTest.Pieces;

public class King: Piece
{
    public King(): base() { }
    public King(Point point): base(point) { }

    public override bool CanMove(Point destination, MoveChecker checker)
    {
        return checker.CheckMove(destination, this);
    }
    
    public override string ToString()
    {
        return "King " + base.ToString();
    }
}