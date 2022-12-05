using System.Reflection;

await using var inputStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AdventOfCode2022.Day5.Input.txt")!;
using StreamReader reader = new(inputStream);
var a = 0;
var b = 0;

while (await reader.ReadLineAsync() is { } line)
{

}
Console.WriteLine(a);
Console.WriteLine(b);