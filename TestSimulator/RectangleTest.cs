using Simulator;

namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ShouldSwapCoordinatesIfNeeded()
    {
        var rect = new Rectangle(5, 10, 2, 8);
        Assert.Equal(2, rect.X1);
        Assert.Equal(8, rect.Y1);
        Assert.Equal(5, rect.X2);
        Assert.Equal(10, rect.Y2);
    }

    [Fact]
    public void Constructor_ShouldThrowIfDegenerate()
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(0, 0, 0, 5));
        Assert.Throws<ArgumentException>(() => new Rectangle(0, 0, 5, 0));
        Assert.Throws<ArgumentException>(() => new Rectangle(1, 1, 1, 1));
    }

    [Theory]
    [InlineData(3, 4, true)]
    [InlineData(0, 0, false)]
    [InlineData(5, 10, true)]
    [InlineData(6, 11, false)]
    public void Contains_ShouldReturnCorrectValue(int x, int y, bool expected)
    {
        var rect = new Rectangle(3, 4, 5, 10);
        Assert.Equal(expected, rect.Contains(new Point(x, y)));
    }

    [Fact]
    public void ToString_ShouldReturnCorrectFormat()
    {
        var rect = new Rectangle(2, 3, 7, 8);
        Assert.Equal("(2, 3):(7, 8)", rect.ToString());
    }
}
