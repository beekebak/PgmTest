using System.Text;
using PgmTest.GameFieldObjects;
using PgmTest.Pieces;

namespace PgmTest;

public class CapturesChecker
{
    private string _filePath;
    private InputValidator _inputValidator;
    private InputParser _inputParser;
    private GameField _gameField;
    private List<IPiece> _pieces;
    private MoveChecker _moveChecker;

    public CapturesChecker(string filePath)
    {
        _filePath = filePath;
        _inputValidator = new InputValidator();
        _gameField = new GameField();
        _inputParser = new InputParser();
        _pieces = new List<IPiece>();
        _moveChecker = new MoveChecker(_gameField);
    }
    
    private bool GetInput()
    {
        try
        {
            using (StreamReader reader = new StreamReader(_filePath))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    if(String.IsNullOrWhiteSpace(line)) continue;
                    if (!_inputValidator.Validate(line))
                    {
                        Console.WriteLine("Ошибка формата ввода в следующей строке: " + line);
                        return false;
                    }
                    IPiece piece = _inputParser.GetNewPiece(line);
                    if (_gameField.CellIsOccupied(piece.Position))
                    {
                        Console.WriteLine("Попытка поставить фигуру на занятое поле в строке: " + line);
                        return false;
                    }
                    _pieces.Add(piece);
                    _gameField.AddPiece(piece, piece.Position);
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл не найден");
            return false;
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Нет доступа к файлу");
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.ToString()}");
            return false;
        }
        return true;
    }

    private List<IPiece> GetAttackedPieces(IPiece piece)
    {
        var attackedPieces = new List<IPiece>();
        foreach (var attackedPiece in _pieces)
        {
            if(piece.CanMove(attackedPiece.Position, _moveChecker)) attackedPieces.Add(attackedPiece);
        }
        return attackedPieces;
    }

    private void WriteOutput()
    {
        Console.WriteLine(_gameField.ToString());
        foreach (var piece in _pieces)
        {
            var attackedPieces = GetAttackedPieces(piece);
            StringBuilder b = new StringBuilder();
            b.Append(piece.ToString() + " атакует: ");
            foreach (var attackedPiece in attackedPieces)
            {
                b.Append(attackedPiece.ToString() + " ");
            }
            Console.WriteLine(b.ToString());
        }
    }

    public void Check()
    {
        if(!GetInput()) return;
        WriteOutput();
    }
}