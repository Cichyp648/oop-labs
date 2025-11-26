namespace Simulator;

public class Animals
{
    private string description = "Unknown";

    // walidacja przeniesiona do Validator.Shortener
    public required string Description {
        get { return description; }
        init => description = Validator.Shortener(value, 3, 15, '#');
    }
    public uint Size { get; set; } = 3;

    // właściwość odczytu Info
    public string Info
    {
        get { return $"{Description} <{Size}>"; }
    }
}
