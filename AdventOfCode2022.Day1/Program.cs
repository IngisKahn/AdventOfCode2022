var input = new StreamReader("Input1.txt").ReadToEnd().Split("\r\n\r\n").Select(s => s.Split("\r\n").Select(int.Parse).Sum());
Console.WriteLine(input.Max()); 
Console.WriteLine(input.Order().TakeLast(3).Sum());

