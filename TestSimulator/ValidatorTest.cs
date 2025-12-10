namespace TestSimulator;

public static class Validator
{
    public static bool IsPositive(int value) => value > 0;
    public static bool IsInRange(int value, int min, int max) => value >= min && value <= max;
}

public class ValidatorTests
{
    [Theory]
    [InlineData(1, true)]
    [InlineData(0, false)]
    [InlineData(-5, false)]
    public void IsPositive_ShouldReturnCorrectResult(int value, bool expected)
    {
        Assert.Equal(expected, Validator.IsPositive(value));
    }

    [Theory]
    [InlineData(5, 0, 10, true)]
    [InlineData(0, 0, 10, true)]
    [InlineData(10, 0, 10, true)]
    [InlineData(-1, 0, 10, false)]
    [InlineData(11, 0, 10, false)]
    public void IsInRange_ShouldReturnCorrectResult(int value, int min, int max, bool expected)
    {
        Assert.Equal(expected, Validator.IsInRange(value, min, max));
    }
}
