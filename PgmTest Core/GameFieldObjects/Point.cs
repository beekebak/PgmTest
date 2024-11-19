namespace PgmTest.GameFieldObjects;

public class Point
{
    public int X { get; init; }
    public int Y { get; init; }
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Point p)
        {
            return p.X == X && p.Y == Y;
        };
        return false;
    }
}