using PgmTest.GameFieldObjects;

namespace PgmTest.Pieces;

public class Rook: Piece
{
    public Rook(): base() { }
    public Rook(Point point): base(point) { }

    public override bool CanMove(Point destination, MoveChecker checker)
    {
        return checker.CheckMove(destination, this);
    }
    
    public override string ToString()
    {
        return "Rook " + base.ToString();
    }
}