using AdventOfCode;
using System.Diagnostics;

var interfaceType = typeof(IAdventOfCode);
var objects = AppDomain.CurrentDomain.GetAssemblies()
    .SelectMany(s => s.GetTypes())
    .Where(x => interfaceType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
    .Select(x => Activator.CreateInstance(x));

var watch = new Stopwatch();

if (!objects.Any())
{
    Console.WriteLine($"*************** No Code to run found ***************");
    Console.WriteLine($"Make sure your classes use the '{interfaceType.Name}' interface!");
}

foreach (IAdventOfCode? instance in objects)
{
    if (Object.ReferenceEquals(instance, null))
        continue;

    Console.WriteLine($"*************** Solutions Day {ComputeName.Compute(instance.GetType().Name)} ***************");

    watch.Restart();
    var partOne = instance.PartOne();
    watch.Stop();
    Console.WriteLine($"Solution part one: {partOne} ({watch.ElapsedMilliseconds} ms)");

    watch.Restart();
    var partTwo = instance.PartTwo();
    watch.Stop();
    Console.WriteLine($"Solution part Two: {partTwo} ({watch.ElapsedMilliseconds} ms)");

    Console.WriteLine();
}