using Simulator;

namespace Simulator.Maps;

public interface IMappable
{
    void Go(Direction direction);
    string Info { get; }
}
