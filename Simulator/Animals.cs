namespace Simulator;

public class Animals
{
    // kod z zadania
    public required string Description { get; init; }
    public uint Size { get; set; } = 3;

    // właściwość odczytu Info
    public string Info
    {
        get { return $"{Description} <{Size}>"; }
    }
}