using StreamReader reader = new("Input.txt");

Dir root = new(null);
var current = root;
await reader.ReadLineAsync();
while (await reader.ReadLineAsync() is { } line)
{
    switch (line[0])
    {
        case '$':
            if (line[2] == 'c')
                current = line[5..] switch {"/" => root, ".." => current!.Parent, { } name => current!.AddDir(name)};
            continue;
        case 'd': break;
        default:
            current!.AddSize(int.Parse(line[..line.IndexOf(' ')]));
            break;
    }
}

Console.WriteLine(root.TotalSmallSize);
Console.WriteLine(root.FindTargetSize(30000000 - (70000000 - root.Size)));

class Dir
{
    public Dir(Dir? parent) => this.Parent = parent;
    public Dir? Parent { get; }
    public Dictionary<string, Dir> Dirs { get; } = new();

    public Dir AddDir(string name)
    {
        Dir d = new(this);
        this.Dirs[name] = d;
        return d;
    }

    public long Size { get; private set; }

    public void AddSize(int size)
    {
        this.Size += size;
        this.Parent?.AddSize(size);
    }

    public long TotalSmallSize => (this.Size > 100000 ? 0 : this.Size) + this.Dirs.Values.Sum(d => d.TotalSmallSize);

    public long FindTargetSize(long target, long best = long.MaxValue)
    {
        if (this.Size > target && this.Size < best)
            best = this.Size;
        return long.Min(best, this.Dirs.Count > 0 ? this.Dirs.Values.Min(d => d.FindTargetSize(target, best)) : best);
    }
}