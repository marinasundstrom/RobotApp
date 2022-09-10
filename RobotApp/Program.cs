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

var x = int.Parse(robotSetupParts[0]);
var y = int.Parse(robotSetupParts[1]);
if (robotSetupParts[2].Length != 1)
{
    Console.WriteLine("Expected one of (N)orth, (E)ast, (S)outh, (W)est");
}
var direction = Enum.GetValues<Direction>()
    .First(x => x.ToString().StartsWith(robotSetupParts[2].ToUpper()));

Robot robot = new Robot(world, new Point(x, y), direction);

while (true)
{
    Console.Write("Enter instruction(s) ([Direction]): ");
    var instructions = Console.ReadLine();

    if (instructions!.ToLower() == "exit")
    {
        return;
    }

    foreach (var instruction in instructions)
    {
        //if (instructionParts.Length != 1)
        //{
        //    Console.WriteLine("Expected a sequence of (F)orward, (L)eft, (R)ight - or EXIT");
        //}

        var walkingDirection = Enum.GetValues<Instruction>()
            .First(x => x.ToString().StartsWith(char.ToUpper(instruction)));

        var result = robot.ReceiveCommand(walkingDirection);
    }

    Console.WriteLine($"Report: {robot.Position.X} {robot.Position.Y} {robot.Direction.ToString().First()}");

    Console.WriteLine($"Done");
}
