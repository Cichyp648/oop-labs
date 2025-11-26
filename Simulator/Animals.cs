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
    public virtual string Info
    {
        get { return $"{Description} <{Size}>"; }
    }

    public override string ToString()
    {
        string classInfo = this.GetType().Name.ToUpper();
        return $"{classInfo}: {Info}";
    }
}

public class Birds : Animals
{
    private bool CanFly = true;

    private string CanFlyInfo()
    {
        if (CanFly) return "fly+";
        else return "fly-";
    }

    public override string Info
    {
        get { return $"{Description} ({CanFlyInfo}) <{Size}>"; }
    }

    public override string ToString()
    {
        string classInfo = this.GetType().Name.ToUpper();
        return $"{classInfo}: {Info}";
    }
}