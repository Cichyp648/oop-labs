using Simulator;

namespace TestSimulator;

public class PointTests
{
    [Theory]
    [InlineData(0, 0, Direction.Up, 0, -1)]
    [InlineData(0, 0, Direction.Right, 1, 0)]
    [InlineData(5, 5, Direction.Down, 5, 6)]
    [InlineData(5, 5, Direction.Left, 4, 5)]
    public void Next_ShouldReturnCorrectPoint(int x, int y, Direction dir, int expectedX, int expectedY)
    {
        var p = new Point(x, y);
        var np = p.Next(dir);
        Assert.Equal(new Point(expectedX, expectedY), np);
    }

    [Theory]
    [InlineData(0, 0, Direction.Up, 1, -1)]
    [InlineData(0, 0, Direction.Right, 1, 1)]
    [InlineData(5, 5, Direction.Down, 4, 6)]
    [InlineData(5, 5, Direction.Left, 4, 4)]
    public void NextDiagonal_ShouldReturnCorrectPoint(int x, int y, Direction dir, int expectedX, int expectedY)
    {
        var p = new Point(x, y);
        var np = p.NextDiagonal(dir);
        Assert.Equal(new Point(expectedX, expectedY), np);
    }

    [Fact]
    public void ToString_ShouldReturnCorrectFormat()
    {
        var p = new Point(3, 7);
        Assert.Equal("(3, 7)", p.ToString());
    }
}
