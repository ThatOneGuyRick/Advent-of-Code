using AdventOfCode2022;
using AdventOfCode2022.Input;
using System.Diagnostics;

var interfaceType = typeof(IAdventOfCode);
var objects = AppDomain.CurrentDomain.GetAssemblies()
    .SelectMany(s => s.GetTypes())
    .Where(x => interfaceType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
    .Select(x => Activator.CreateInstance(x));

var watch = new Stopwatch();

foreach (IAdventOfCode? instance in objects)
{
    if (Object.ReferenceEquals(instance, null))
        continue;

    Console.WriteLine($"*************** Solutions Day {ComputeName.Compute(instance.GetType().Name)} ***************");

    watch.Restart();
    var partOne = instance.PartOne();
    watch.Stop();
    Console.WriteLine($"Solutions part one: {partOne} ({watch.ElapsedMilliseconds} ms)");

    watch.Restart();
    var partTwo = instance.PartTwo();
    watch.Stop();
    Console.WriteLine($"Solutions part Two: {partTwo} ({watch.ElapsedMilliseconds} ms)");

    Console.WriteLine();
}