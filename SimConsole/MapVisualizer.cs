using Simulator;
using Simulator.Maps;
using System.Text;

namespace SimConsole;

public class MapVisualizer
{
    private readonly Map map;

    public MapVisualizer(Map map)
    {
        this.map = map ?? throw new ArgumentNullException(nameof(map));
    }

    public void Draw()
    {
        Console.OutputEncoding = Encoding.UTF8;

        int width = map.SizeX;
        int height = map.SizeY;

        Console.Write(Box.TopLeft);
        for (int x = 0; x < width; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < width - 1)
                Console.Write(Box.TopMid);
        }
        Console.WriteLine(Box.TopRight);

        for (int y = 0; y < height; y++)
        {
            Console.Write(Box.Vertical);
            for (int x = 0; x < width; x++)
            {
                char c = GetCellSymbol(x, y);
                Console.Write(c);
                Console.Write(Box.Vertical);
            }
            Console.WriteLine();

            if (y < height - 1)
            {
                Console.Write(Box.MidLeft);
                for (int x = 0; x < width; x++)
                {
                    Console.Write(Box.Horizontal);
                    if (x < width - 1)
                        Console.Write(Box.Cross);
                }
                Console.WriteLine(Box.MidRight);
            }
        }

        Console.Write(Box.BottomLeft);
        for (int x = 0; x < width; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < width - 1)
                Console.Write(Box.BottomMid);
        }
        Console.WriteLine(Box.BottomRight);
    }

    private char GetCellSymbol(int x, int y)
    {
        var objects = map.At(x, y);

        if (objects.Count == 0)
            return ' ';

        if (objects.Count == 1)
        {
            var obj = objects[0];
            return obj.Symbol;
        }

        return 'X';
    }
}
