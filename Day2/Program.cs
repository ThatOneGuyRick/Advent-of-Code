Dictionary<string, int> score = new() {
                { "A X", 1 + 3 }, { "A Y", 2 + 6 }, { "A Z", 3 + 0 },
                { "B X", 1 + 0 }, { "B Y", 2 + 3 }, { "B Z", 3 + 6 },
                { "C X", 1 + 6 }, { "C Y", 2 + 0 }, { "C Z", 3 + 3 }
            };

Dictionary<string, int> score2 = new() {
                { "A X", 3 + 0 }, { "A Y", 1 + 3 }, { "A Z", 2 + 6 },
                { "B X", 1 + 0 }, { "B Y", 2 + 3 }, { "B Z", 3 + 6 },
                { "C X", 2 + 0 }, { "C Y", 3 + 3 }, { "C Z", 1 + 6 }
            };

string[] input = File.ReadAllLines("input2.txt");
int totalScore = 0;
int totalScore2 = 0;
foreach (string line in input)
{
    totalScore += score[line];
    totalScore2 += score2[line];
}



Console.WriteLine($"Score first rount: {totalScore}");
Console.WriteLine($"Score second rount: {totalScore2}");
Console.ReadLine();
