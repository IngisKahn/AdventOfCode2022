using System.Runtime.ExceptionServices;

using StreamReader reader = new("Input.txt");
var xs = new int[10];
var ys = new int[10];
Array.Fill(xs, 10000);
Array.Fill(ys, 10000);
int hx = 10000, hy = 10000, tx = 10000, ty = 10000;
HashSet<int> tailPoints = new() { tx * 100000 + ty };
HashSet<int> tailPoints2 = new() { tx * 100000 + ty };
while (await reader.ReadLineAsync() is { } line)
{
    var cnt = int.Parse(line[2..]);
    switch (line[0])
    {
        case 'U':
            hy += cnt;
            break;
        case 'D':
            hy -= cnt;
            break;
        case 'L':
            hx -= cnt;
            break;
        default:
            hx += cnt;
            break;
    }

    var dx = hx - tx;
    var dy = hy - ty;
    if (dx != 0 && dy != 0 && (int.Abs(dx) > 1 || int.Abs(dy) > 1))
    {
        tx += int.Sign(hx - tx);
        ty += int.Sign(hy - ty);

        tailPoints.Add(tx * 100000 + ty);
    }

    for (; ; )
    {
        dx = hx - tx;
        dy = hy - ty;

        if (int.Abs(dx) > 1)
            tx += int.Sign(hx - tx);
        else if (int.Abs(dy) > 1)
            ty += int.Sign(hy - ty);
        else break;

        tailPoints.Add(tx * 100000 + ty);
    }
    while (cnt-- > 0)
    {
        switch (line[0])
        {
            case 'U':
                ys[0] += 1;
                break;
            case 'D':
                ys[0] -= 1;
                break;
            case 'L':
                xs[0] -= 1;
                break;
            default:
                xs[0] += 1;
                break;
        }
        for (var i = 1; i < 9; i++)
        {
            dx = xs[i - 1] - xs[i];
            dy = ys[i - 1] - ys[i];
            while (dx != 0 && dy != 0 && (int.Abs(dx) > 1 || int.Abs(dy) > 1))
            {
                xs[i] += int.Sign(xs[i - 1] - xs[i]);
                ys[i] += int.Sign(ys[i - 1] - ys[i]);
                dx = xs[i - 1] - xs[i];
                dy = ys[i - 1] - ys[i];
            }

            for (; ; )
            {
                dx = xs[i - 1] - xs[i];
                dy = ys[i - 1] - ys[i];

                if (int.Abs(dx) > 1)
                    xs[i] += int.Sign(xs[i - 1] - xs[i]);
                else if (int.Abs(dy) > 1)
                    ys[i] += int.Sign(ys[i - 1] - ys[i]);
                else break;
            }
        }
        dx = xs[8] - xs[9];
        dy = ys[8] - ys[9];
        while (dx != 0 && dy != 0 && (int.Abs(dx) > 1 || int.Abs(dy) > 1))
        {
            xs[9] += int.Sign(xs[8] - xs[9]);
            ys[9] += int.Sign(ys[8] - ys[9]);
            tailPoints2.Add(xs[9] * 100000 + ys[9]);
            dx = xs[8] - xs[9];
            dy = ys[8] - ys[9];
        }

        for (; ; )
        {
            dx = xs[8] - xs[9];
            dy = ys[8] - ys[9];

            if (int.Abs(dx) > 1)
                xs[9] += int.Sign(xs[8] - xs[9]);
            else if (int.Abs(dy) > 1)
                ys[9] += int.Sign(ys[8] - ys[9]);
            else break;
            tailPoints2.Add(xs[9] * 100000 + ys[9]);
        }
    }
}
Console.WriteLine(tailPoints.Count);
Console.WriteLine(tailPoints2.Count);