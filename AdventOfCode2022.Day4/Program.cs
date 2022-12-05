using System.Reflection;

await using var inputStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AdventOfCode2022.Day4.Input.txt")!;
using StreamReader reader = new(inputStream);
var coveredPairs = 0;
var overlappingPairs = 0;

while (await reader.ReadLineAsync() is { } line)
{
    var values = line.Split('-', ',').Select(int.Parse).ToArray();
    if (values[0] <= values[2] && values[1] >= values[3] || values[0] >= values[2] && values[1] <= values[3])
    {
        coveredPairs++;
        overlappingPairs++;
    }
    else if (values[1] >= values[2] && values[3] >= values[0])
        overlappingPairs++;
}
Console.WriteLine(coveredPairs);
Console.WriteLine(overlappingPairs);