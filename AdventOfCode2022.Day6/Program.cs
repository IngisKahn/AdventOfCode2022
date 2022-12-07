using StreamReader reader = new("Input.txt");
string data = reader.ReadToEnd();

void FindUnique(int length)
{
    for (var i = length; i < data.Length; i++)
    {
        int? dupe = null;
        for (var j = i - length; j < i; j++)
        {
            for (var k = j + 1; k <= i; k++)
                if (data[k] == data[j])
                {
                    dupe = j;
                    break;
                }

            if (dupe != null)
                break;
        }

        if (dupe == null)
        {
            Console.WriteLine(i + 1);
            break;
        }

        i = dupe.Value + length;
    }
}
FindUnique(3);
FindUnique(13);