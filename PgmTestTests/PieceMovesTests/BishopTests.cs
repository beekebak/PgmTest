using PgmTest;
using PgmTest.GameFieldObjects;
using PgmTest.Pieces;

namespace PgmTest_Tests.PieceMovesTests;

public class BishopTests
{
    private void SetupGameField(out GameField gameField, out MoveChecker checker)
    {
        gameField = new GameField();
        checker = new MoveChecker(gameField);
    }
    
    [Fact]
    public void Bishop_MovesDiagonallyIncreasing_Test()
    {
        SetupGameField(out GameField gameField, out MoveChecker checker);
        IPiece bishop = new Bishop();
        gameField.AddPiece(bishop, new Point(0, 0));
        Assert.True(bishop.CanMove(new Point(7, 7), checker));
    }

    [Fact]
    public void Bishop_MovesDiagonallyDecreasing_Test()
    {
        SetupGameField(out GameField gameField, out MoveChecker checker);
        IPiece bishop = new Bishop();
        gameField.AddPiece(bishop, new Point(7, 0));
        Assert.True(bishop.CanMove(new Point(0, 7), checker));
    }
    
    [Fact]
    public void Bishop_CantMoveOtherDirections_Test()
    {
        SetupGameField(out GameField gameField, out MoveChecker checker);
        IPiece bishop = new Bishop();
        gameField.AddPiece(bishop, new Point(4, 4));
        Assert.False(bishop.CanMove(new Point(1, 4), checker));
        Assert.False(bishop.CanMove(new Point(4, 1), checker));
        Assert.False(bishop.CanMove(new Point(5, 6), checker));
    }

    [Fact]
    public void Bishop_CantMoveOverOtherPieces_Test()
    {
        SetupGameField(out GameField gameField, out MoveChecker checker);
        IPiece bishop = new Bishop();
        gameField.AddPiece(bishop, new Point(4, 4));
        gameField.AddPiece(new Rook(), new Point(3, 3));
        Assert.False(bishop.CanMove(new Point(1, 1), checker));
    }
}