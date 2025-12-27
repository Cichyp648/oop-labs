namespace Simulator;
internal class LogVisualizer
{
    SimulationLog Log { get; }

    public LogVisualizer(SimulationLog log)
    {
        Log = log ?? throw new ArgumentNullException(nameof(log));
    }

    public void Draw(int turnIndex)
    {
        if (turnIndex < 0 || turnIndex >= Log.TurnLogs.Count)
        {
            Console.WriteLine("Niepoprawny numer tury");
            return;
        }

        var turn = Log.TurnLogs[turnIndex];

        Console.Clear();
        Console.WriteLine($"Tura: {turnIndex}");
        Console.WriteLine($"Obiekt: {turn.Mappable}");
        Console.WriteLine($"Ruch: {turn.Move}");
        Console.WriteLine();

        for (int y = 0; y < Log.SizeY; y++)
        {
            for (int x = 0; x < Log.SizeX; x++)
            {
                var p = new Point(x, y);
                Console.Write(
                    turn.Symbols.TryGetValue(p, out var symbol)
                        ? symbol
                        : '.'
                );
            }
            Console.WriteLine();
        }
    }
}
