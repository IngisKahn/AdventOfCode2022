using StreamReader reader = new("Input1.txt");
var score1 = 0;
var score2 = 0;
while (await reader.ReadLineAsync() is { } line)
{
    var p1 = line[0] - '@'; 
    var p2 = line[2] - 'W';
    score1 += (p2 - p1 + 4) % 3 * 3 + p2;

    var dif = line[2] - 'Y';
    var player2 = (line[0] - 'A' + dif + 3) % 3;
    dif = (-dif + 3) % 3;
    score2 += player2 + 4 + (int)(dif * -7.5f + dif * dif * 4.5f);
    score2 -= (p1 + p2) % 3 + 1 + (p2 - 1) * 3;
}
Console.WriteLine(score1);
Console.WriteLine(score2);