using PgmTest.Pieces;

namespace PgmTest.GameFieldObjects;

public class Cell
{
    public IPiece? Piece { private get; set; } = null;
    public bool IsEmpty => Piece is null;

    public override string ToString()
    {
        if (Piece is Knight) return "N"; //in English notation knight is referred as 'N'. It is the only piece which alias doesn't match its name first letter
        return Piece?.ToString()!.Substring(0, 1) ?? "-";
    }
}