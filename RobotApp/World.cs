namespace RobotApp;

public class World
{

    public World(int width, int depth)
    {
        Width = width;
        Depth = depth;
    }

    public int Width { get; set; }

    public int Depth { get; set; }
}