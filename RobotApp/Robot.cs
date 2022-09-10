using System;

namespace RobotApp;

public class Robot
{
    private readonly World world;
    private Point position;
    private Direction direction;

    public Robot(World world, Point point, Direction direction)
    {
        this.world = world;
        this.position = point;
        this.direction = direction;
    }

    public Point Position => position;
    public Direction Direction => direction;

    public (Point Position, Direction Direction) Command(Instruction walkingDirection)
    {
        InterpretInstruction(walkingDirection);

        return (position, direction);
    }

    public (Point Position, Direction Direction) Command(params Instruction[] instructions)
    {
        foreach (var instruction in instructions)
        {
            InterpretInstruction(instruction);
        }

        return (position, direction);
    }

    private void InterpretInstruction(Instruction instruction)
    {
        switch (instruction)
        {
            case Instruction.Right:
                direction = RotateRight();
                break;

            case Instruction.Left:
                direction = RotateLeft();
                break;

            default:
                MoveOneStep();
                break;
        }
    }

    private Direction RotateRight()
    {
        var currentDirection = direction;

        return (currentDirection) switch
        {
            Direction.North => Direction.East,
            Direction.East => Direction.South,
            Direction.South => Direction.West,
            Direction.West => Direction.North,
            _ => throw new InvalidOperationException("Invalid direction")
        };
    }

    private Direction RotateLeft()
    {
        var currentDirection = direction;

        return (currentDirection) switch
        {
            Direction.North => Direction.West,
            Direction.West => Direction.South,
            Direction.South => Direction.East,
            Direction.East => Direction.North,
            _ => throw new InvalidOperationException("Invalid direction")
        };
    }

    private void MoveOneStep()
    {
        var currentDirection = direction;
        var currentPosition = position;

        switch (currentDirection)
        {
            case Direction.North:
                if (position.Y - 1 < 0)
                {
                    throw new InvalidOperationException();
                }
                position = currentPosition with { Y = currentPosition.Y - 1 };
                break;

            case Direction.East:
                if (position.X >= world.Width)
                {
                    throw new InvalidOperationException();
                }
                position = currentPosition with { X = currentPosition.X + 1 };
                break;

            case Direction.South:
                if (position.Y >= world.Depth)
                {
                    throw new InvalidOperationException();
                }
                position = currentPosition with { Y = currentPosition.Y + 1 };
                break;

            case Direction.West:
                if (position.X - 1 < 0)
                {
                    throw new InvalidOperationException();
                }
                position = currentPosition with { X = currentPosition.X - 1 };
                break;
        }
    }
}
