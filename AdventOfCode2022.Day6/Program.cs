using StreamReader reader = new("Input.txt");
var data = reader.ReadToEnd();
for (var i = 3; i < data.Length; i++)
{
    int? dupe = null;
    for (var j = i - 3; j < i; j++)
    {
        for (var k = j + 1; k <= i; k++)
            if (data[k] == data[j])
            {
                dupe = j;
                break;
            }

        if (dupe != null)
        {
            break;
        }
    }

    if (dupe == null)
    {
        Console.WriteLine(i + 1);
        break;
    }

    i = dupe.Value + 3;
}
for (var i = 13; i < data.Length; i++)
{
    int? dupe = null;
    for (var j = i - 13; j < i; j++)
    {
        for (var k = j + 1; k <= i; k++)
            if (data[k] == data[j])
            {
                dupe = j;
                break;
            }

        if (dupe != null)
        {
            break;
        }
    }

    if (dupe == null)
    {
        Console.WriteLine(i + 1);
        break;
    }

    i = dupe.Value + 13;
}