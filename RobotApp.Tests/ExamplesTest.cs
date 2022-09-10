namespace RobotApp.Tests;

public class ExamplesTest
{
    [Fact]
    public void Example1()
    {
        // Arrange

        World world = new(5, 7);
        Robot robot = new(world, new Point(3, 3), Direction.North);

        // Act

        var result = robot.ReceiveCommands(
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
        // Arrange

        World world = new(5, 5);
        Robot robot = new (world, new Point(1, 2), Direction.North);

        // Act

        var result = robot.ReceiveCommands(
            Instruction.Right,
            Instruction.Forward,
            Instruction.Right,
            Instruction.Forward,
            Instruction.Forward,
            Instruction.Right,
            Instruction.Forward,
            Instruction.Right,
            Instruction.Forward);

        // Assert

        Assert.Equal(new Point(1, 3), result.Position);
        Assert.Equal(Direction.North, result.Direction);
    }

    [Fact]
    public void Example3()
    {
        // Arrange

        World world = new(5, 5);
        Robot robot = new (world, new Point(0, 0), Direction.East);

        // Act

        var result = robot.ReceiveCommands(
            Instruction.Right,
            Instruction.Forward,
            Instruction.Left,
            Instruction.Forward,
            Instruction.Forward,
            Instruction.Left,
            Instruction.Right,
            Instruction.Forward);

        // Assert

        Assert.Equal(new Point(3, 1), result.Position);
        Assert.Equal(Direction.East, result.Direction);
    }
}
