using StreamReader reader = new("Input.txt");
string line = (await reader.ReadLineAsync())!;
var gridWidth = line.Length;
var gridLines = new List<int[]>();
do
{
    var gridLine = new int[gridWidth];
    for (var i = 0; i < gridWidth; i++)
        gridLine[i] = line[i] - '0' + 1;
    gridLines.Add(gridLine);
}
while ((line = (await reader.ReadLineAsync())!) is { });
var visible = new bool[gridWidth, gridLines.Count];
var tallestRow = new int[gridWidth];
for (var x = 0; x < gridWidth; x++)
    for (var y = 0; y < gridLines.Count - 1; y++)
        if (gridLines[y][x] > tallestRow[x])
        {
            tallestRow[x] = gridLines[y][x];
            visible[x, y] = true;
        }
tallestRow = new int[gridWidth];
for (var x = 0; x < gridWidth; x++)
    for (var y = gridLines.Count - 1; y > 0; y--)
        if (gridLines[y][x] > tallestRow[x])
        {
            tallestRow[x] = gridLines[y][x];
            visible[x, y] = true;
        }

var tallestColumn = new int[gridLines.Count];
for (var y = 0; y < gridLines.Count; y++)
    for (var x = gridWidth - 1; x > 0; x--)
        if (gridLines[y][x] > tallestColumn[y])
        {
            tallestColumn[y] = gridLines[y][x];
            visible[x, y] = true;
        }
tallestColumn = new int[gridLines.Count];
for (var y = 0; y < gridLines.Count; y++)
    for (var x = 0; x < gridWidth - 1; x++)
        if (gridLines[y][x] > tallestColumn[y])
        {
            tallestColumn[y] = gridLines[y][x];
            visible[x, y] = true;
        }

var count = 0;
for (var x = 0; x < gridWidth; x++)
    for (var y = 0; y < gridLines.Count; y++)
        if (visible[x, y])
            count++;
Console.WriteLine(count);
List<int> scores = new();
for (var y = 1; y < gridLines.Count - 1; y++)
    for (var x = 1; x < gridWidth - 1; x++)
    {
        var scoreTotal = 0;
        var score = 0;
        var height = gridLines[y][x];
        for (var yy = y - 1; yy >= 0; yy--)
        {
            scoreTotal++;

            if (gridLines[yy][x] >= height)
                break;
        }
        for (var yy = y + 1; yy < gridLines.Count; yy++)
        {
            score++;

            if (gridLines[yy][x] >= height)
                break;
        }

        scoreTotal *= score;
        score = 0;
        for (var xx = x - 1; xx >= 0; xx--)
        {
            score++;

            if (gridLines[y][xx] >= height)
                break;
        }
        scoreTotal *= score;
        score = 0;
        for (var xx = x + 1; xx < gridWidth; xx++)
        {
            score++;

            if (gridLines[y][xx] >= height)
                break;
        }
        scoreTotal *= score;
        scores.Add(scoreTotal);
    }
Console.WriteLine(scores.Max());