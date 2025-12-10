using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        var map = new SmallSquareMap(10);
        Assert.Equal(10, map.SizeX);
        Assert.Equal(10, map.SizeY);
    }

    [Theory]
    [InlineData(4)]
    [InlineData(21)]
    public void Constructor_InvalidSize_ShouldThrow(int size)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
    }

    [Fact]
    public void Exist_ShouldReturnCorrectValues()
    {
        var map = new SmallSquareMap(10);
        Assert.True(map.Exist(new Point(0, 0)));
        Assert.True(map.Exist(new Point(9, 9)));
        Assert.False(map.Exist(new Point(-1, 0)));
        Assert.False(map.Exist(new Point(0, 10)));
    }

    [Fact]
    public void Next_ShouldReturnSamePointIfOutside()
    {
        var map = new SmallSquareMap(10);
        var p = new Point(0, 0);
        var np = map.Next(new Point(-1, 0), Direction.Right);
        Assert.Equal(new Point(-1, 0), np);
    }

    [Fact]
    public void NextDiagonal_ShouldReturnSamePointIfOutside()
    {
        var map = new SmallSquareMap(10);
        var p = new Point(10, 10);
        var np = map.NextDiagonal(p, Direction.Up);
        Assert.Equal(p, np);
    }
}
