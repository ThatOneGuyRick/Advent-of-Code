using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Code
{
    public class Day2 : IAdventOfCode
    {
        private Dictionary<string, int> _score = new() {
                { "A X", 1 + 3 }, { "A Y", 2 + 6 }, { "A Z", 3 + 0 },
                { "B X", 1 + 0 }, { "B Y", 2 + 3 }, { "B Z", 3 + 6 },
                { "C X", 1 + 6 }, { "C Y", 2 + 0 }, { "C Z", 3 + 3 }
            };

        private Dictionary<string, int> _score2 = new() {
                { "A X", 3 + 0 }, { "A Y", 1 + 3 }, { "A Z", 2 + 6 },
                { "B X", 1 + 0 }, { "B Y", 2 + 3 }, { "B Z", 3 + 6 },
                { "C X", 2 + 0 }, { "C Y", 3 + 3 }, { "C Z", 1 + 6 }
            };

        private string[] _input;

        public Day2()
        {
            _input = File.ReadAllLines("Input/day2.txt");
        }

        public string PartOne()
        {
            int totalScore = 0;
            foreach (string line in _input)
            {
                totalScore += _score[line];
            }

            return totalScore.ToString();
        }

        public string PartTwo()
        {
            int totalScore = 0;
            foreach (string line in _input)
            {
                totalScore += _score2[line];
            }

            return totalScore.ToString();
        }
    }
}
