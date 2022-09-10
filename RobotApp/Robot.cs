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

    public (Point Position, Direction Direction) ReceiveCommand(Instruction instruction)
    {
        InterpretInstruction(instruction);

        return (position, direction);
    }

    public (Point Position, Direction Direction) ReceiveCommands(params Instruction[] instructions)
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
                RotateRight();
                break;

            case Instruction.Left:
                RotateLeft();
                break;

            case Instruction.Forward:
                MoveForward();
                break;
        }
    }

    private void RotateRight()
    {
        var currentDirection = direction;

        direction = (currentDirection) switch
        {
            Direction.North => Direction.East,
            Direction.East => Direction.South,
            Direction.South => Direction.West,
            Direction.West => Direction.North,
            _ => throw new InvalidOperationException("Invalid direction")
        };
    }

    private void RotateLeft()
    {
        var currentDirection = direction;

        direction = (currentDirection) switch
        {
            Direction.North => Direction.West,
            Direction.West => Direction.South,
            Direction.South => Direction.East,
            Direction.East => Direction.North,
            _ => throw new InvalidOperationException("Invalid direction")
        };
    }

    private void MoveForward()
    {
        var currentDirection = direction;
        var currentPosition = position;

        switch (currentDirection)
        {
            case Direction.North:
                if (currentPosition.Y - 1 < 0)
                {
                    throw new InvalidOperationException();
                }
                position = currentPosition with { Y = currentPosition.Y - 1 };
                break;

            case Direction.East:
                if (currentPosition.X + 1 >= world.Width)
                {
                    throw new InvalidOperationException();
                }
                position = currentPosition with { X = currentPosition.X + 1 };
                break;

            case Direction.South:
                if (currentPosition.Y + 1 >= world.Depth)
                {
                    throw new InvalidOperationException();
                }
                position = currentPosition with { Y = currentPosition.Y + 1 };
                break;

            case Direction.West:
                if (currentPosition.X - 1 < 0)
                {
                    throw new InvalidOperationException();
                }
                position = currentPosition with { X = currentPosition.X - 1 };
                break;
        }
    }
}
