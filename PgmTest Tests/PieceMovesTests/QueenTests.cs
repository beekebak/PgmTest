using PgmTest;
using PgmTest.GameFieldObjects;
using PgmTest.Pieces;

namespace PgmTest_Tests.PieceMovesTests;

public class QueenTests
{
    private void SetupGameField(out GameField gameField, out MoveChecker checker)
    {
        gameField = new GameField();
        checker = new MoveChecker(gameField);
    }
    
    [Fact]
    public void Queen_MovesDiagonallyIncreasing_Test()
    {
        SetupGameField(out GameField gameField, out MoveChecker checker);
        IPiece queen = new Queen();
        gameField.AddPiece(queen, new Point(0, 0));
        Assert.True(queen.CanMove(new Point(7, 7), checker));
    }

    [Fact]
    public void Queen_MovesDiagonallyDecreasing_Test()
    {
        SetupGameField(out GameField gameField, out MoveChecker checker);
        IPiece queen = new Queen();
        gameField.AddPiece(queen, new Point(7, 0));
        Assert.True(queen.CanMove(new Point(0, 7), checker));
    }
    
    [Fact]
    public void Queen_MovesHorizontally_Test()
    {
        SetupGameField(out GameField gameField, out MoveChecker checker);
        IPiece queen = new Queen();
        gameField.AddPiece(queen, new Point(0, 0));
        Assert.True(queen.CanMove(new Point(7, 0), checker));
    }

    [Fact]
    public void Queen_MovesVertically_Test()
    {
        SetupGameField(out GameField gameField, out MoveChecker checker);
        IPiece queen = new Queen();
        gameField.AddPiece(queen, new Point(0, 0));
        Assert.True(queen.CanMove(new Point(0, 7), checker));
    }
    
    [Fact]
    public void Queen_CantMoveOtherDirections_Test()
    {
        SetupGameField(out GameField gameField, out MoveChecker checker);
        IPiece queen = new Queen();
        gameField.AddPiece(queen, new Point(4, 4));
        Assert.False(queen.CanMove(new Point(5, 6), checker));
    }

    [Fact]
    public void Queen_CantMoveOverOtherPieces_Test()
    {
        SetupGameField(out GameField gameField, out MoveChecker checker);
        IPiece queen = new Queen();
        gameField.AddPiece(queen, new Point(4, 4));
        gameField.AddPiece(new Queen(), new Point(4, 3));
        gameField.AddPiece(new Rook(), new Point(3, 3));
        Assert.False(queen.CanMove(new Point(4, 0), checker));
        Assert.False(queen.CanMove(new Point(1, 1), checker));
    }
}