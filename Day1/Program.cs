List<string> lines = File.ReadAllLines("input1.txt").ToList();
List<int> amounts = new();

int amount = 0;
foreach (string line in lines)
{
    if (string.IsNullOrEmpty(line))
    {
        amounts.Add(amount);
        amount = 0;
        continue;
    }

    amount += int.Parse(line);
}

amounts.Sort((x, y) => y.CompareTo(x));

Console.WriteLine(amounts[0]);
Console.WriteLine(amounts[0] + amounts[1] + amounts[2]);
Console.ReadLine();
