using System.Reflection;
using System.Text;

await using var inputStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AdventOfCode2022.Day5.Input.txt")!;
using StreamReader reader = new(inputStream);
string line = (await reader.ReadLineAsync())!;
var stackCount = (line!.Length >> 2) + 1;
var lists = new List<char>[stackCount];
var stacks = new Stack<char>[stackCount];
do
{
    for (var i = 0; i < stackCount; i++)
    {
        lists[i] ??= new();
        var c = line[1 + (i << 2)];
        if (c != ' ')
            lists[i].Add(c);
    }

    line = (await reader.ReadLineAsync())!;
} while (line[1] != '1');

for (var i = 0; i < stackCount; i++)
{
    lists[i].Reverse();
    stacks[i] = new(lists[i]);
}

await reader.ReadLineAsync();
while (await reader.ReadLineAsync() is { } move)
{
    var parts = move.Split(' ');
    var cnt = int.Parse(parts[1]);
    var src = int.Parse(parts[3]) - 1;
    var dst = int.Parse(parts[5]) - 1;

    lists[dst].AddRange(lists[src].GetRange(lists[src].Count - cnt, cnt));
    lists[src].RemoveRange(lists[src].Count - cnt, cnt);
    while (cnt-- > 0) 
        stacks[dst].Push(stacks[src].Pop());
}

StringBuilder tops = new(stackCount);
for (var i = 0; i < stackCount; i++)
    tops.Append(stacks[i].Peek());

Console.WriteLine(tops.ToString());
tops.Clear();
for (var i = 0; i < stackCount; i++)
    tops.Append(lists[i].Last());

Console.WriteLine(tops.ToString());
