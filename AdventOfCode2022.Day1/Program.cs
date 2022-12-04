using System.Reflection;

var input1Stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AdventOfCode2022.Day1.Input1.txt")!;
StreamReader reader = new(input1Stream);
var current = 0;
var max = 0;
var max2 = 0;
var max3 = 0;
while (reader.ReadLine() is { } line)
    if (line == string.Empty)
    {
        if (current > max)
        {
            max3 = max2;
            max2 = max;
            max = current;
        }

        current = 0;
    }
    else
        current += int.Parse(line);

Console.WriteLine(max);
Console.WriteLine(max + max2 + max3);

