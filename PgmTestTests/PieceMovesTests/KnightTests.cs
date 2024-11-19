using PgmTest;
using PgmTest.GameFieldObjects;
using PgmTest.Pieces;

namespace PgmTest_Tests.PieceMovesTests;

public class KnightTests
{
    private void SetupGameField(out GameField gameField, out MoveChecker checker)
    {
        gameField = new GameField();
        checker = new MoveChecker(gameField);
    }
    
    [Fact]
    public void Knight_MovesTwoAndOneField_Test()
    {
        SetupGameField(out GameField gameField, out MoveChecker checker);
        IPiece knight = new Knight();
        gameField.AddPiece(knight, new Point(4, 4));
        Assert.True(knight.CanMove(new Point(6, 5), checker));
        Assert.True(knight.CanMove(new Point(5, 6), checker));
        Assert.True(knight.CanMove(new Point(2, 5), checker));
        Assert.True(knight.CanMove(new Point(5, 2), checker));
        Assert.True(knight.CanMove(new Point(2, 3), checker));
        Assert.True(knight.CanMove(new Point(3, 2), checker));
        Assert.True(knight.CanMove(new Point(6, 3), checker));
        Assert.True(knight.CanMove(new Point(3, 6), checker));
    }

    [Fact]
    public void Knight_DoesntMoveOtherFields_Test()
    {
        SetupGameField(out GameField gameField, out MoveChecker checker);
        IPiece knight = new Knight();
        gameField.AddPiece(knight, new Point(4, 4));
        Assert.False(knight.CanMove(new Point(5, 5), checker));
        Assert.False(knight.CanMove(new Point(4, 5), checker));
        Assert.False(knight.CanMove(new Point(5, 4), checker));
        Assert.False(knight.CanMove(new Point(3, 5), checker));
    }
}