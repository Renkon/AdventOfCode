using AdventOfCode;
using System.Reflection;

foreach (var type in Assembly.GetExecutingAssembly().GetExportedTypes().Where(t => t.FullName!.StartsWith("AdventOfCode.Problems.Problem")))
{
    var problem = Activator.CreateInstance(type) as dynamic;

    var (partA, elapsedA) = Utils.DoAndMeasure(() => problem!.DoPartA());
    var (partB, elapsedB) = Utils.DoAndMeasure(() => problem!.DoPartB());

    Console.WriteLine($"--------------------------------------------------------------------------------");
    Console.WriteLine($"                                   {type.Name.Replace("m", "m ").ToUpper()}");
    Console.WriteLine($"");
    Console.WriteLine($"    Part A: {partA} - Time elapsed: {elapsedA} ms");
    Console.WriteLine($"    Part B: {partB} - Time elapsed: {elapsedB} ms");
}

Console.WriteLine($"--------------------------------------------------------------------------------");