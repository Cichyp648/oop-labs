using System.Xml.Linq;

namespace Simulator;

public class Animals
{
    private string description = "Unknown";

    // kod z zadania
    // dodana walidacja do init
    public required string Description {
        get { return description; }
        init
        {
            string val = value.Trim();

            if (val.Length < 3)
                val = val.PadRight(3, '#');

            if (val.Length > 25)
                val = val.Substring(0, 15).TrimEnd();

            if (val.Length < 3)
                val = val.PadRight(3, '#');

            if (char.IsLower(val[0]))
                val = char.ToUpper(val[0]) + val.Substring(1);

            description = val;
        }
    }
    public uint Size { get; set; } = 3;

    // właściwość odczytu Info
    public string Info
    {
        get { return $"{Description} <{Size}>"; }
    }
}
