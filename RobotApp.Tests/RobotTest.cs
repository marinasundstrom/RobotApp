namespace RobotApp.Tests;

public class RobotTest
{
    [Fact]
    public void HeadingNorth_MovingForward()
    {
        World world = new(5, 5);
        Robot robot = new Robot(world, new Point(3, 3), Direction.North);

        var result = robot.Command(Instruction.Forward);

        Assert.Equal(new Point(3, 2), result.Position);
        Assert.Equal(Direction.North, result.Direction);
    }

    [Fact]
    public void HeadingNorth_MovingForward_OutOfBounds()
    {
        World world = new(5, 5);
        Robot robot = new Robot(world, new Point(3, 3), Direction.North);

        Assert.Throws<InvalidOperationException>(() =>
        {
            robot.Command(Instruction.Forward, Instruction.Forward, Instruction.Forward, Instruction.Forward);
        });
    }

    [Fact]
    public void HeadingSouth_MovingForward()
    {
        World world = new(5, 5);
        Robot robot = new Robot(world, new Point(3, 3), Direction.South);

        var result = robot.Command(Instruction.Forward);

        Assert.Equal(new Point(3, 4), result.Position);
        Assert.Equal(Direction.South, result.Direction);
    }

    [Fact]
    public void HeadingSouth_MovingForward_OutOfBounds()
    {
        World world = new(5, 5);
        Robot robot = new Robot(world, new Point(3, 3), Direction.South);

        Assert.Throws<InvalidOperationException>(() =>
        {
            robot.Command(Instruction.Forward, Instruction.Forward, Instruction.Forward, Instruction.Forward);
        });
    }

    [Fact]
    public void HeadingWest_MovingForward()
    {
        World world = new(5, 5);
        Robot robot = new Robot(world, new Point(3, 3), Direction.West);

        var result = robot.Command(Instruction.Forward);

        Assert.Equal(new Point(2, 3), result.Position);
        Assert.Equal(Direction.West, result.Direction);
    }

    [Fact]
    public void HeadingWest_MovingForward_OutOfBounds()
    {
        World world = new(5, 5);
        Robot robot = new Robot(world, new Point(3, 3), Direction.West);

        Assert.Throws<InvalidOperationException>(() =>
        {
            robot.Command(Instruction.Forward, Instruction.Forward, Instruction.Forward, Instruction.Forward);
        });
    }

    [Fact]
    public void HeadingEast_MovingForward()
    {
        World world = new(5, 5);
        Robot robot = new Robot(world, new Point(3, 3), Direction.East);

        var result = robot.Command(Instruction.Forward);

        Assert.Equal(new Point(4, 3), result.Position);
        Assert.Equal(Direction.East, result.Direction);
    }

    [Fact]
    public void HeadingEast_MovingForward_OutOfBounds()
    {
        World world = new(5, 5);
        Robot robot = new Robot(world, new Point(3, 3), Direction.East);

        Assert.Throws<InvalidOperationException>(() =>
        {
            robot.Command(Instruction.Forward, Instruction.Forward, Instruction.Forward, Instruction.Forward);
        });
    }

    [Fact]
    public void TurnRightFromNorth_ShouldHeadEast()
    {
        World world = new(5, 7);
        Robot robot = new Robot(world, new Point(3, 3), Direction.North);

        var result = robot.Command(Instruction.Right);

        Assert.Equal(new Point(3, 3), result.Position);
        Assert.Equal(Direction.East, result.Direction);
    }

    [Fact]
    public void TurnRightFromEast_ShouldHeadSouth()
    {
        World world = new(5, 7);
        Robot robot = new Robot(world, new Point(3, 3), Direction.East);

        var result = robot.Command(Instruction.Right);

        Assert.Equal(new Point(3, 3), result.Position);
        Assert.Equal(Direction.South, result.Direction);
    }

    [Fact]
    public void TurnRightFromSouth_ShouldHeadWest()
    {
        World world = new(5, 7);
        Robot robot = new Robot(world, new Point(3, 3), Direction.South);

        var result = robot.Command(Instruction.Right);

        Assert.Equal(new Point(3, 3), result.Position);
        Assert.Equal(Direction.West, result.Direction);
    }

    [Fact]
    public void TurnRightFromWest_ShouldHeadNorth()
    {
        World world = new(5, 7);
        Robot robot = new Robot(world, new Point(3, 3), Direction.West);

        var result = robot.Command(Instruction.Right);

        Assert.Equal(new Point(3, 3), result.Position);
        Assert.Equal(Direction.North, result.Direction);
    }

    [Fact]
    public void TurnLeftFromNorth_ShouldHeadWest()
    {
        World world = new(5, 7);
        Robot robot = new Robot(world, new Point(3, 3), Direction.North);

        var result = robot.Command(Instruction.Left);

        Assert.Equal(new Point(3, 3), result.Position);
        Assert.Equal(Direction.West, result.Direction);
    }

    [Fact]
    public void TurnLeftFromEast_ShouldHeadNorth()
    {
        World world = new(5, 7);
        Robot robot = new Robot(world, new Point(3, 3), Direction.East);

        var result = robot.Command(Instruction.Left);

        Assert.Equal(new Point(3, 3), result.Position);
        Assert.Equal(Direction.North, result.Direction);
    }

    [Fact]
    public void TurnLeftFromSouth_ShouldHeadEast()
    {
        World world = new(5, 7);
        Robot robot = new Robot(world, new Point(3, 3), Direction.South);

        var result = robot.Command(Instruction.Left);

        Assert.Equal(new Point(3, 3), result.Position);
        Assert.Equal(Direction.East, result.Direction);
    }

    [Fact]
    public void TurnLeftFromWest_ShouldHeadNorth()
    {
        World world = new(5, 7);
        Robot robot = new Robot(world, new Point(3, 3), Direction.East);

        var result = robot.Command(Instruction.Left);

        Assert.Equal(new Point(3, 3), result.Position);
        Assert.Equal(Direction.North, result.Direction);
    }
}
