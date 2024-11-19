using PgmTest;
using PgmTest.GameFieldObjects;
using PgmTest.Pieces;

namespace PgmTest_Tests.PieceMovesTests;

public class RookTests
{
    private void SetupGameField(out GameField gameField, out MoveChecker checker)
    {
        gameField = new GameField();
        checker = new MoveChecker(gameField);
    }
    
    [Fact]
    public void Rook_MovesHorizontally_Test()
    {
        SetupGameField(out GameField gameField, out MoveChecker checker);
        IPiece rook = new Rook();
        gameField.AddPiece(rook, new Point(0, 0));
        Assert.True(rook.CanMove(new Point(7, 0), checker));
    }

    [Fact]
    public void Rook_MovesVertically_Test()
    {
        SetupGameField(out GameField gameField, out MoveChecker checker);
        IPiece rook = new Rook();
        gameField.AddPiece(rook, new Point(0, 0));
        Assert.True(rook.CanMove(new Point(0, 7), checker));
    }
    
    [Fact]
    public void Rook_CantMoveOtherDirections_Test()
    {
        SetupGameField(out GameField gameField, out MoveChecker checker);
        IPiece rook = new Rook();
        gameField.AddPiece(rook, new Point(4, 4));
        Assert.False(rook.CanMove(new Point(1, 1), checker));
        Assert.False(rook.CanMove(new Point(1, 7), checker));
        Assert.False(rook.CanMove(new Point(5, 6), checker));
        Assert.False(rook.CanMove(new Point(3, 3), checker));
    }

    [Fact]
    public void Rook_CantMoveOverOtherPieces_Test()
    {
        SetupGameField(out GameField gameField, out MoveChecker checker);
        IPiece rook = new Rook();
        gameField.AddPiece(rook, new Point(4, 4));
        gameField.AddPiece(new Rook(), new Point(4, 3));
        Assert.False(rook.CanMove(new Point(4, 0), checker));
    }
}