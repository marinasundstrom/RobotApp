using RobotApp;

Console.Write("World ([Width] [Depth]): ");
var init = Console.ReadLine();

var initParts = init?.Split() ?? Array.Empty<string>();

if (initParts.Length != 2)
{
    Console.WriteLine("Expected [Width] [Depth]");

    return;
}

var width = int.Parse(initParts[0]);
var depth = int.Parse(initParts[1]);

World world = new(width, depth);

Console.Write("Start position ([X] [Y] [Direction]): ");
var robotSetup = Console.ReadLine();

var robotSetupParts = robotSetup?.Split() ?? Array.Empty<string>();

if (robotSetupParts.Length != 3)
{
    Console.WriteLine("Expected [X] [Y] [Direction]");

    return;
}

if(!int.TryParse(robotSetupParts[0], out var x))
{
    Console.WriteLine("[X] expected to be an integer");

    return;
}

if(!int.TryParse(robotSetupParts[1], out var y))
{
    Console.WriteLine("[Y] expected to be an integer");

    return;
}

var directionPart = robotSetupParts[2];
if (directionPart.Length != 1 && char.IsUpper(directionPart[0]))
{
    Console.WriteLine("Expected one of (N)orth, (E)ast, (S)outh, (W)est");
}

var direction = Enum.GetValues<Direction>()
    .First(x => x.ToString().StartsWith(directionPart.ToUpper()));

Robot robot = new (world, new Point(x, y), direction);

char[] validInstructionChars = new[] { 'F', 'L', 'R' };

while (true)
{
    Console.Write("Enter instruction(s) ([Direction]): ");
    var instructions = Console.ReadLine();

    if (instructions!.ToLower() == "exit")
    {
        return;
    }

    if (!instructions.All(c => validInstructionChars.Any(x => x == c)))
    {
        Console.WriteLine("Expected a sequence of (F)orward, (L)eft, (R)ight - or EXIT");
        continue;
    }

    foreach (var instruction in instructions)
    {
        var walkingDirection = Enum.GetValues<Instruction>()
            .First(x => x.ToString().StartsWith(char.ToUpper(instruction)));

        try
        {
            var result = robot.ReceiveCommand(walkingDirection);
        }
        catch(InvalidOperationException)
        {
            Console.WriteLine("You were going out of the bounds of the world.");
            break;
        }
    }

    Console.WriteLine($"Report: {robot.Position.X} {robot.Position.Y} {robot.Direction.ToString().First()}");
}
