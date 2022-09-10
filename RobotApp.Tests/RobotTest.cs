namespace RobotApp.Tests;

public class RobotTest
{
    [Fact]
    public void HeadingNorth_MovingForward()
    {
        // Arrange

        World world = new(5, 5);
        Robot robot = new (world, new Point(3, 3), Direction.North);

        // Act

        var result = robot.ReceiveCommand(Instruction.Forward);

        // Assert

        Assert.Equal(new Point(3, 2), result.Position);
        Assert.Equal(Direction.North, result.Direction);
    }

    [Fact]
    public void HeadingNorth_MovingForward_OutOfBounds()
    {
        // Arrange

        World world = new(5, 5);
        Robot robot = new (world, new Point(3, 3), Direction.North);

        // Act

        robot.ReceiveCommands(
                Instruction.Forward,
                Instruction.Forward,
                Instruction.Forward);

        // Assert

        Assert.Throws<InvalidOperationException>(() =>
        {
            robot.ReceiveCommand(Instruction.Forward);
        });
    }

    [Fact]
    public void HeadingSouth_MovingForward()
    {
        // Arrange

        World world = new(5, 5);
        Robot robot = new (world, new Point(3, 3), Direction.South);

        // Act

        var result = robot.ReceiveCommand(Instruction.Forward);

        // Assert

        Assert.Equal(new Point(3, 4), result.Position);
        Assert.Equal(Direction.South, result.Direction);
    }

    [Fact]
    public void HeadingSouth_MovingForward_OutOfBounds()
    {
        // Arrange

        World world = new(5, 5);
        Robot robot = new (world, new Point(3, 3), Direction.South);

        // Act

        robot.ReceiveCommand(Instruction.Forward);

        // Assert

        Assert.Throws<InvalidOperationException>(() =>
        {
            robot.ReceiveCommand(Instruction.Forward);
        });
    }

    [Fact]
    public void HeadingWest_MovingForward()
    {
        // Arrange

        World world = new(5, 5);
        Robot robot = new (world, new Point(3, 3), Direction.West);

        // Act

        var result = robot.ReceiveCommand(Instruction.Forward);

        // Assert

        Assert.Equal(new Point(2, 3), result.Position);
        Assert.Equal(Direction.West, result.Direction);
    }

    [Fact]
    public void HeadingWest_MovingForward_OutOfBounds()
    {
        // Arrange

        World world = new(5, 5);
        Robot robot = new (world, new Point(3, 3), Direction.West);

        // Act

        robot.ReceiveCommands(
                Instruction.Forward,
                Instruction.Forward,
                Instruction.Forward);

        // Assert

        Assert.Throws<InvalidOperationException>(() =>
        {
            robot.ReceiveCommand(Instruction.Forward);
        });
    }

    [Fact]
    public void HeadingEast_MovingForward()
    {
        // Arrange

        World world = new(5, 5);
        Robot robot = new (world, new Point(3, 3), Direction.East);

        // Act

        var result = robot.ReceiveCommand(Instruction.Forward);

        // Assert

        Assert.Equal(new Point(4, 3), result.Position);
        Assert.Equal(Direction.East, result.Direction);
    }

    [Fact]
    public void HeadingEast_MovingForward_OutOfBounds()
    {
        // Arrange

        World world = new(5, 5);
        Robot robot = new (world, new Point(3, 3), Direction.East);

        // Act

        robot.ReceiveCommand(Instruction.Forward);

        // Assert

        Assert.Throws<InvalidOperationException>(() =>
        {
            robot.ReceiveCommand(Instruction.Forward);
        });
    }

    [Fact]
    public void TurnRightFromNorth_ShouldHeadEast()
    {
        // Arrange

        World world = new(5, 7);
        Robot robot = new (world, new Point(3, 3), Direction.North);

        // Act

        var result = robot.ReceiveCommand(Instruction.Right);

        // Assert

        Assert.Equal(new Point(3, 3), result.Position);
        Assert.Equal(Direction.East, result.Direction);
    }

    [Fact]
    public void TurnRightFromEast_ShouldHeadSouth()
    {
        // Arrange

        World world = new(5, 7);
        Robot robot = new (world, new Point(3, 3), Direction.East);

        // Act

        var result = robot.ReceiveCommand(Instruction.Right);

        // Assert

        Assert.Equal(new Point(3, 3), result.Position);
        Assert.Equal(Direction.South, result.Direction);
    }

    [Fact]
    public void TurnRightFromSouth_ShouldHeadWest()
    {
        // Arrange

        World world = new(5, 7);
        Robot robot = new (world, new Point(3, 3), Direction.South);

        // Act

        var result = robot.ReceiveCommand(Instruction.Right);

        // Assert

        Assert.Equal(new Point(3, 3), result.Position);
        Assert.Equal(Direction.West, result.Direction);
    }

    [Fact]
    public void TurnRightFromWest_ShouldHeadNorth()
    {
        // Arrange

        World world = new(5, 7);
        Robot robot = new (world, new Point(3, 3), Direction.West);

        // Act

        var result = robot.ReceiveCommand(Instruction.Right);

        // Assert

        Assert.Equal(new Point(3, 3), result.Position);
        Assert.Equal(Direction.North, result.Direction);
    }

    [Fact]
    public void TurnLeftFromNorth_ShouldHeadWest()
    {
        // Arrange

        World world = new(5, 7);
        Robot robot = new (world, new Point(3, 3), Direction.North);

        // Act

        var result = robot.ReceiveCommand(Instruction.Left);

        // Assert

        Assert.Equal(new Point(3, 3), result.Position);
        Assert.Equal(Direction.West, result.Direction);
    }

    [Fact]
    public void TurnLeftFromEast_ShouldHeadNorth()
    {
        // Arrange

        World world = new(5, 7);
        Robot robot = new (world, new Point(3, 3), Direction.East);

        // Act

        var result = robot.ReceiveCommand(Instruction.Left);

        // Assert

        Assert.Equal(new Point(3, 3), result.Position);
        Assert.Equal(Direction.North, result.Direction);
    }

    [Fact]
    public void TurnLeftFromSouth_ShouldHeadEast()
    {
        // Arrange

        World world = new(5, 7);
        Robot robot = new (world, new Point(3, 3), Direction.South);

        // Act

        var result = robot.ReceiveCommand(Instruction.Left);

        // Assert

        Assert.Equal(new Point(3, 3), result.Position);
        Assert.Equal(Direction.East, result.Direction);
    }

    [Fact]
    public void TurnLeftFromWest_ShouldHeadNorth()
    {
        // Arrange

        World world = new(5, 7);
        Robot robot = new (world, new Point(3, 3), Direction.East);

        // Act

        var result = robot.ReceiveCommand(Instruction.Left);

        // Assert

        Assert.Equal(new Point(3, 3), result.Position);
        Assert.Equal(Direction.North, result.Direction);
    }
}
