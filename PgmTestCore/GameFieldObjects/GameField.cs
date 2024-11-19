using System.Text;
using PgmTest.Pieces;

namespace PgmTest.GameFieldObjects;

public class GameField
{
    private readonly List<List<Cell>> _cells;

    public GameField()
    {
        _cells = new List<List<Cell>>();
        for (int i = 0; i < 8; i++)
        {
            _cells.Add(new List<Cell>());
            for (int j = 0; j < 8; j++) _cells[i].Add(new Cell());
        }
    }

    public void AddPiece(IPiece piece, Point position)
    {
        _cells[position.Y][position.X].Piece = piece;
        piece.Position = position;
    }

    public bool CellIsOccupied(Point position)
    {
        return !_cells[position.Y][position.X].IsEmpty;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 7; i >= 0; i--)
        {
            var line = _cells[i];
            foreach (var cell in line)
            {
                builder.Append(cell.ToString());
            }
            builder.AppendLine();
        }
        return builder.ToString();
    }
}