using PgmTest;
using PgmTest.GameFieldObjects;
using PgmTest.Pieces;

namespace PgmTest_Tests.PieceMovesTests;

public class KingTests
{
    private void SetupGameField(out GameField gameField, out MoveChecker checker)
    {
        gameField = new GameField();
        checker = new MoveChecker(gameField);
    }
    
    [Fact]
    public void King_MovesAround_Test()
    {
        SetupGameField(out GameField gameField, out MoveChecker checker);
        IPiece king = new King();
        gameField.AddPiece(king, new Point(1, 1));
        Assert.True(king.CanMove(new Point(1, 0), checker));
        Assert.True(king.CanMove(new Point(0, 0), checker));
        Assert.True(king.CanMove(new Point(0, 1), checker));
        Assert.True(king.CanMove(new Point(2, 0), checker));
        Assert.True(king.CanMove(new Point(2, 2), checker));
        Assert.True(king.CanMove(new Point(0, 2), checker));
        Assert.True(king.CanMove(new Point(1, 2), checker));
        Assert.True(king.CanMove(new Point(2, 1), checker));
    }

    [Fact]
    public void King_DoesntMoveFurtherThanOneCell_Test()
    {
        SetupGameField(out GameField gameField, out MoveChecker checker);
        IPiece king = new King();
        gameField.AddPiece(king, new Point(4, 4));
        Assert.False(king.CanMove(new Point(4, 7), checker));
        Assert.False(king.CanMove(new Point(4, 6), checker));
        Assert.False(king.CanMove(new Point(6, 6), checker));
        Assert.False(king.CanMove(new Point(2, 2), checker));
        Assert.False(king.CanMove(new Point(0, 4), checker));
        Assert.False(king.CanMove(new Point(6, 4), checker));
    }
}