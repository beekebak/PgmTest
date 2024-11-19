using PgmTest.GameFieldObjects;

namespace PgmTest.Pieces;

public class Shadow: Piece
{
    public Shadow(): base() { }
    public Shadow(Point point): base(point) { }

    public override bool CanMove(Point destination, MoveChecker checker)
    {
        return checker.CheckMove(destination, this);
    }
    
    public override string ToString()
    {
        return "Shadow " + base.ToString();
    }
}