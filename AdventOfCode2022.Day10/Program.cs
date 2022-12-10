using System.Security.Cryptography.X509Certificates;
using System.Text;

using StreamReader reader = new("Input.txt");
var x = 1;
var clock = 0;
var sum = 0L;
StringBuilder output = new();
while (await reader.ReadLineAsync() is { } line)
{
    var count = 0;
    var op = 0;
    var add = 0;
    switch (line[0])
    {
        case 'a':
            op = 1;
            count = 2;
            add = int.Parse(line[5..]);
            break;
        default:
            op = 0;
            count = 1;
            break;
    }

    while (count-- > 0)
    {
        var pos = clock % 40;
        output.Append(int.Abs(pos - x) < 2 ? '#' : '.');
        if ((++clock + 20) % 40 == 0)
            sum += clock * x;
        if (clock % 40 == 0)
            output.AppendLine();
    }

    if (op == 1)
        x += add;
}
Console.WriteLine(sum);
Console.WriteLine(output.ToString());