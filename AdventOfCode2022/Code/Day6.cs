using AdventOfCode;

namespace AdventOfCode2022.Code
{
    internal class Day6 : IAdventOfCode
    {
        private readonly string _input;
        public Day6()
        {
            _input = File.ReadAllText("Input/day6.txt");
        }
        public string PartOne()
        {
            return FindDistinct(_input, 4);
        }

        public string PartTwo()
        {
            return FindDistinct(_input, 14);
        }

        private string FindDistinct(string data, int amount)
        {
            char[] letters = new char[amount];

            int i = 0;
            while (i < data.Length)
            {
                letters = data.Skip(i).Take(amount).ToArray();
                if (letters.Length == letters.Distinct().Count())
                {
                    break;
                }
                i++;
            }

            return $"{i + amount}";
        }
    }
}
