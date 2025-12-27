namespace Simulator;

public class SimulationLog
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<TurnLog> TurnLogs { get; } = [];

    public SimulationLog(Simulation simulation)
    {
        _simulation = simulation
            ?? throw new ArgumentNullException(nameof(simulation));

        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;

        Run();
    }

    private void Run()
    {
        // Tura 0 – stan początkowy (bez ruchu)
        TurnLogs.Add(new TurnLog
        {
            Mappable = "START",
            Move = "NONE",
            Symbols = CaptureMap()
        });

        while (!_simulation.Finished)
        {
            _simulation.Turn();

            TurnLogs.Add(new TurnLog
            {
                Mappable = _simulation.CurrentMappable?.ToString() ?? "UNKNOWN",
                Move = _simulation.CurrentMoveName ?? "NONE",
                Symbols = CaptureMap()
            });
        }
    }

    private Dictionary<Point, char> CaptureMap()
    {
        var result = new Dictionary<Point, char>();

        for (int i = 0; i < _simulation.Mappables.Count; i++)
        {
            result[_simulation.Positions[i]] =
                _simulation.Mappables[i].Symbol;
        }

        return result;
    }
}
