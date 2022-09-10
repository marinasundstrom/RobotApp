namespace RobotApp.Tests;

public class ExamplesTest
{
    [Fact]
    public void Example1()
    {
        World world = new(5, 7);
        Robot robot = new Robot(world, new Point(3, 3), Direction.North);

        var result = robot.Command(
            Instruction.Left,
            Instruction.Forward,
            Instruction.Forward,
            Instruction.Right,
            Instruction.Forward,
            Instruction.Right,
            Instruction.Forward,
            Instruction.Right,
            Instruction.Forward,
            Instruction.Forward);
    }

    [Fact]
    public void Example2()
    {
        World world = new(5, 5);
        Robot robot = new Robot(world, new Point(1, 2), Direction.North);

        var result = robot.Command(
            Instruction.Right,
            Instruction.Forward,
            Instruction.Right,
            Instruction.Forward,
            Instruction.Forward,
            Instruction.Right,
            Instruction.Forward,
            Instruction.Right,
            Instruction.Forward);

        Assert.Equal(new Point(1, 3), result.Position);
        Assert.Equal(Direction.North, result.Direction);
    }

    [Fact]
    public void Example3()
    {
        World world = new(5, 5);
        Robot robot = new Robot(world, new Point(0, 0), Direction.East);

        var result = robot.Command(
            Instruction.Right,
            Instruction.Forward,
            Instruction.Left,
            Instruction.Forward,
            Instruction.Forward,
            Instruction.Left,
            Instruction.Right,
            Instruction.Forward);

        Assert.Equal(new Point(3, 1), result.Position);
        Assert.Equal(Direction.East, result.Direction);
    }
}
