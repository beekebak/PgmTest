using PgmTest;

namespace PgmTest_Tests;

public class InputValidatorTests
{
    [Fact]
    public void InputValidator_ValidInput_ReturnsTrue()
    {
        InputValidator validator = new();
        Assert.True(validator.Validate("shadow 0 0"));
        Assert.True(validator.Validate("queen 7 7"));
        Assert.True(validator.Validate("king 7 0"));
        Assert.True(validator.Validate("knight 0 7"));
        Assert.True(validator.Validate("rook 2 3"));
        Assert.True(validator.Validate("bishop 6 1"));
    }
    
    [Fact]
    void InputValidator_InvalidInputBadFormat_ReturnsFalse()
    {
        InputValidator validator = new();
        Assert.False(validator.Validate("shadow00"));
        Assert.False(validator.Validate("shadow0 0"));
        Assert.False(validator.Validate("shadow 00"));
        Assert.False(validator.Validate("shadow sj 0"));
        Assert.False(validator.Validate("shadow 0 sj"));
        Assert.False(validator.Validate("shadow sj sj"));
        Assert.False(validator.Validate("shadow 0 0 0"));
        Assert.False(validator.Validate("shadow 0"));
    }
    
    [Fact]
    void InputValidator_InvalidInputBadPieces_ReturnsFalse()
    {
        InputValidator validator = new();
        Assert.False(validator.Validate("tales 0 0"));
        Assert.False(validator.Validate("Queen 0 0"));
    }

    [Fact]
    void InputValidator_InvalidInputBadCoordinates_ReturnsFalse()
    {
        InputValidator validator = new();
        Assert.False(validator.Validate("shadow 0 8"));
        Assert.False(validator.Validate("shadow 8 0"));
        Assert.False(validator.Validate("shadow 0 -1"));
        Assert.False(validator.Validate("shadow -1 0"));
        Assert.False(validator.Validate("shadow 11 -13"));
        Assert.False(validator.Validate("shadow -123 12"));
    }
}