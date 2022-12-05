using AdventOfCode;
using AdventOfCode.Common;

namespace AdventOfCode2022.Code
{
    internal class Day4 : IAdventOfCode
    {
        private List<(int elf1Start, int elf1End, int elf2Start, int elf2End)> _ranges = new();

        public Day4()
        {
            foreach (string line in File.ReadAllLines("Input/day4.txt"))
            {
                string[] splits = line.SplitOn("-", ",", "-");
                _ranges.Add((splits[0].ToInt(), splits[1].ToInt(), splits[2].ToInt(), splits[3].ToInt()));
            }
        }

        public string PartOne()
        {
            int total = 0;
            foreach ((int elf1Start, int elf1End, int elf2Start, int elf2End) in _ranges)
            {
                if ((elf1Start <= elf2Start && elf1End >= elf2End) || (elf2Start <= elf1Start && elf2End >= elf1End))
                {
                    total++;
                }
            }
            return $"{total}";
        }

        public string PartTwo()
        {
            int total = 0;
            foreach ((int elf1Start, int elf1End, int elf2Start, int elf2End) in _ranges)
            {
                if (elf1Start <= elf2End && elf1End >= elf2Start)
                {
                    total++;
                }
            }
            return $"{total}";
        }
    }
}
