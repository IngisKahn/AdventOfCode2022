using System.Reflection;

await using var inputStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AdventOfCode2022.Day3.Input.txt")!;
using StreamReader reader = new(inputStream);
var duplicateItemScore = 0;
var badgeScore = 0;
int ItemValue(char item) => item switch {>= 'a' => item - 'a', _ => item - 'A' + 26};
var bagFields = new ulong[3];
var elfIndex = 0;
while (await reader.ReadLineAsync() is { } line)
{
    var flags = bagFields[elfIndex] = 0;
    var chars = line.Length >> 1;
    var i = 0;
    for (i = 0; i < chars; i++)
        flags |= 1ul << ItemValue(line[i]);
    for (i = 0; i < chars; i++)
    {
        var val = ItemValue(line[chars + i]);
        if ((flags & 1ul << val) != 0)
        {
            duplicateItemScore += val + 1;
            break;
        }
        bagFields[elfIndex] |= 1ul << val;
    }
    for (; i < chars; i++)
        flags |= 1ul << ItemValue(line[chars + i]);

    bagFields[elfIndex] |= flags;

    if (elfIndex++ == 2)
    {
        badgeScore += (int) ulong.Log2(bagFields[0] & bagFields[1] & bagFields[2]) + 1;
        elfIndex = 0;
    }
}
Console.WriteLine(duplicateItemScore);
Console.WriteLine(badgeScore);