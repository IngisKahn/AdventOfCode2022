using System.Reflection;

await using var input1Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AdventOfCode2022.Day2.Input1.txt")!;
using StreamReader reader = new(input1Stream);
var score = 0;
while (await reader.ReadLineAsync() is { } line)
{
    var player2 = line[2] - 'X';
    var dif = (line[0] - 'A' - player2 + 3) % 3;
    score += player2 + 4 + (int)(dif * -7.5f + dif * dif * 4.5f);
}
Console.WriteLine(score);
input1Stream.Seek(3, SeekOrigin.Begin);
score = 0;
while (await reader.ReadLineAsync() is { } line)
{
    var dif = line[2] - 'Y';
    var player2 = (line[0] - 'A' + dif + 3) % 3;
    dif = (-dif + 3) % 3;
    score += player2 + 4 + (int)(dif * -7.5f + dif * dif * 4.5f);
}
Console.WriteLine(score);