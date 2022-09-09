namespace RobotApp;

public record struct Point(int X, int Y)
{
    public override string ToString() => $"({X}, {Y})";
}