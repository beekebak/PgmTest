using PgmTest.GameFieldObjects;
using PgmTest.Pieces;

namespace PgmTest;


public class MoveChecker
{
    private GameField _gameField;

    private bool PointsOnSameHorizontal(Point p1, Point p2)
    {
        return p1.Y == p2.Y;
    }
    
    private bool PointsOnSameVertical(Point p1, Point p2)
    {
        return p1.X == p2.X;
    }

    private bool PointsOnSameIncreasingDiagonal(Point p1, Point p2)
    {
        return p1.X - p2.X == p1.Y - p2.Y;
    }
    
    private bool PointsOnSameDecreasingDiagonal(Point p1, Point p2)
    {
        return p1.X - p2.X == p2.Y - p1.Y;
    }
    
    private bool PieceCanMoveHorizontally(Point p1, Point p2)
    {
        if (!PointsOnSameHorizontal(p1, p2)) return false;
        int y = p1.Y;
        int lowerX = p1.X > p2.X ? p2.X : p1.X;
        int higherX = p1.X > p2.X ? p1.X : p2.X;
        for (int x = lowerX+1; x < higherX; x++)
        {
            if (_gameField.CellIsOccupied(new Point(x, y))) return false;
        }
        return true;
    }

    private bool PieceCanMoveVertically(Point p1, Point p2)
    {
        if (!PointsOnSameVertical(p1, p2)) return false;
        int x = p1.X;
        int lowerY = p1.Y > p2.Y ? p2.Y : p1.Y;
        int higherY = p1.Y > p2.Y ? p1.Y : p2.Y;
        for (int y = lowerY+1; y < higherY; y++)
        {
            if (_gameField.CellIsOccupied(new Point(x, y))) return false;
        }
        return true;
    }

    private bool PieceCanMoveIncreasingDiagonally(Point p1, Point p2)
    {
        if (!PointsOnSameIncreasingDiagonal(p1, p2)) return false;
        int lowerX = p1.X > p2.X ? p2.X : p1.X;
        int lowerY = p1.Y > p2.Y ? p2.Y : p1.Y;
        int higherY = p1.Y > p2.Y ? p1.Y : p2.Y;
        for (int y = lowerY+1, x = lowerX+1; y < higherY; y++, x++)
        {
            if (_gameField.CellIsOccupied(new Point(x, y))) return false;
        }
        return true;
    }

    private bool PieceCanMoveDecreasingDiagonally(Point p1, Point p2)
    {
        if (!PointsOnSameDecreasingDiagonal(p1, p2)) return false;
        int lowerX = p1.X > p2.X ? p2.X : p1.X;
        int higherY = p1.Y > p2.Y ? p1.Y : p2.Y;
        int lowerY = p1.Y > p2.Y ? p2.Y : p1.Y;
        for (int y = higherY-1, x = lowerX+1; y > lowerY; y--, x++)
        {
            if (_gameField.CellIsOccupied(new Point(x, y))) return false;
        }
        return true;
    }
    
    public MoveChecker(GameField gameField)
    {
        _gameField = gameField;
    }

    public bool CheckMove(Point destination, Rook rook)
    {
        if (Equals(destination, rook.Position)) return false;
        return PieceCanMoveHorizontally(rook.Position, destination) ||
               PieceCanMoveVertically(rook.Position, destination);
    }
    
    public bool CheckMove(Point destination, Queen queen)
    {
        if (Equals(destination, queen.Position)) return false;
        return PieceCanMoveHorizontally(queen.Position, destination) ||
               PieceCanMoveVertically(queen.Position, destination) || 
               PieceCanMoveDecreasingDiagonally(queen.Position, destination) || 
               PieceCanMoveIncreasingDiagonally(queen.Position, destination);
    }
    
    public bool CheckMove(Point destination, Knight knight)
    {
        Point position = knight.Position;
        return (Math.Abs(position.X - destination.X) == 2 && Math.Abs(position.Y - destination.Y) == 1) ||
               (Math.Abs(position.X - destination.X) == 1 && Math.Abs(position.Y - destination.Y) == 2);
    }
    
    public bool CheckMove(Point destination, Bishop bishop)
    {
        if (Equals(destination, bishop.Position)) return false;
        return PieceCanMoveDecreasingDiagonally(bishop.Position, destination) || 
               PieceCanMoveIncreasingDiagonally(bishop.Position, destination);
    }
    
    public bool CheckMove(Point destination, King king)
    {
        if (Equals(destination, king.Position)) return false;
        return Math.Abs(king.Position.X - destination.X) <= 1 && Math.Abs(king.Position.Y - destination.Y) <= 1;
    }
    
    public bool CheckMove(Point destination, Shadow shadow)
    {
        Queen proxy = new Queen();
        proxy.Position = shadow.Position;
        return CheckMove(destination, proxy);
    }
}