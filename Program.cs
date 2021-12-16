using AdventOfCode;
using Pastel;
using System.Reflection;

foreach (var type in Assembly.GetExecutingAssembly().GetExportedTypes().Where(t => t.FullName!.StartsWith("AdventOfCode.Problems.Problem")).OrderBy(t => int.Parse(t.Name.Substring(7))))
{
    var problem = Activator.CreateInstance(type) as dynamic;
    var (partA, elapsedA) = Utils.DoAndMeasure(() => problem!.DoPartA());
    var (partB, elapsedB) = Utils.DoAndMeasure(() => problem!.DoPartB());

    Console.WriteLine($"--------------------------------------------------------------------------------".Pastel("#FF8900"));
    Console.WriteLine($"                                   {type.Name.Replace("m", "m ").ToUpper()}");
    Console.WriteLine($"");
    Console.WriteLine($"    {"Part A".Pastel("#F984E5")}: {Handle(Colorize(partA, "#83EEFF"))} - Time elapsed: {Colorize(elapsedA, "#77C66E")} ms");
    Console.WriteLine($"    {"Part B".Pastel("#F5EA92")}: {Handle(Colorize(partB, "#83EEFF"))} - Time elapsed: {Colorize(elapsedB, "#77C66E")} ms");
}

Console.WriteLine($"--------------------------------------------------------------------------------".Pastel("#FF8900"));


string Colorize(dynamic elem, string color)
    => ((object)elem).ToString().Pastel(color);

string Handle(string str)
{
    if (str.Contains(Environment.NewLine))
    {
        return string.Join(Environment.NewLine, str.Split(Environment.NewLine).Select(s => $"            {s}")).Substring(12);
    }

    return str;
}