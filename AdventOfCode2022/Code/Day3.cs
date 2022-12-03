using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Code
{
    public class Day3 : IAdventOfCode
    {
        private List<string> _input;
        private List<string[]> _input2;
        private int total = 0;
        private int total2 = 0;

        public Day3()
        {
            _input = File.ReadAllLines("Input/day3.txt").ToList();
            _input2 = _input.Chunk(3).ToList();

        }

        public string PartOne()
        {
            foreach (string sack in _input)
            {
                var first = sack.Substring(0, (sack.Length / 2)).ToArray();
                var last = sack.Substring((sack.Length / 2), (sack.Length / 2)).ToArray();

                var letter = first.Intersect(last).First();

                total += CalculateScore(letter);
            }
            return total.ToString();
        }

        public string PartTwo()
        {
            foreach (var group in _input2)
            {
                var letter2 = group
                .Skip(1)
                .Aggregate(
                    new HashSet<char>(group.First()),
                    (h, e) => { h.IntersectWith(e); return h; }
                );

                total2 += CalculateScore(letter2.First());
            }
            return total2.ToString();
        }

        private int CalculateScore(char input)
        {
            int score = input % 32;

            if (char.IsUpper(input))
            {
                score += 26;
            }

            return score;
        }
    }
}
