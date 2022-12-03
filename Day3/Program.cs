using System.Linq;

List<string> input = File.ReadAllLines("input3.txt").ToList();
List<string[]> input2 = input.Chunk(3).ToList();
int total = 0;
int total2 = 0;

foreach (string sack in input)
{
    var first = sack.Substring(0, (sack.Length / 2)).ToArray();
    var last = sack.Substring((sack.Length / 2), (sack.Length / 2)).ToArray();

    var letter = first.Intersect(last).First();

    total += CalculateScore(letter);
}

foreach (var group in input2)
{
    var letter2 = group
    .Skip(1)
    .Aggregate(
        new HashSet<char>(group.First()),
        (h, e) => { h.IntersectWith(e); return h; }
    );

    total2 += CalculateScore(letter2.First());
}

int CalculateScore(char input)
{
    int score = input % 32;

    if (char.IsUpper(input))
    {
        score += 26;
    }

    return score;
}

Console.WriteLine(total);
Console.WriteLine(total2);