using System.Reflection;

await using var inputStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AdventOfCode2022.Day3.Input.txt")!;
using StreamReader reader = new(inputStream);
var score = 0;
int ItemValue(char item) => item switch {>= 'a' => item - 'a', _ => item - 'A' + 26};
while (await reader.ReadLineAsync() is { } line)
{
    var flags = 0ul;
    var chars = line.Length >> 1;
    for (var i = 0; i < chars; i++)
        flags |= 1ul << ItemValue(line[i]);
    for (var i = 0; i < chars; i++)
    {
        var val = ItemValue(line[chars + i]);
        if ((flags & 1ul << val) != 0)
        {
            score += val + 1;
            break;
        }
    }
}
Console.WriteLine(score);