namespace Simulator;

public class TurnLog
{
    public required string Mappable { get; init; }
    public required string Move { get; init; }
    public required Dictionary<Point, char> Symbols { get; init; }
}
