using System.Text.RegularExpressions;

namespace PgmTest;

public class InputValidator
{
    private bool IsPieceName(string name)
    {
        return name == "king" || name == "queen" || name == "rook" ||
               name == "bishop" || name == "knight" || name == "shadow";
    }

    private bool CheckBoundaries(int coordinate)
    {
        return coordinate >= 0 && coordinate <= 7;
    }

    public bool Validate(string input)
    {
        string pattern = @"^\w+\s+-?\d+\s+-?\d+$";
        if(!Regex.IsMatch(input, pattern)) return false;
        string[] parts = input.Split(' ');
        if(!IsPieceName(parts[0])) return false;
        if(!CheckBoundaries(int.Parse(parts[1]))) return false;
        if(!CheckBoundaries(int.Parse(parts[2]))) return false;
        return true;
    }
}