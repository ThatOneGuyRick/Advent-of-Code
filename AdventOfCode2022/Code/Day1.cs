using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Code
{
    public class Day1 : IAdventOfCode
    {
        List<int> amounts = new();

        public Day1()
        {
            int amount = 0;
            foreach (string line in File.ReadAllLines("Input/day1.txt").ToList())
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
        }

        public string PartOne()
        {
            return amounts[0].ToString();
        }

        public string PartTwo()
        {
            return (amounts[0] + amounts[1] + amounts[2]).ToString();
        }
    }
}
