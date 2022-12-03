using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Input
{
    internal class ComputeName
    {
        internal static string Compute(string name)
        {
            string toBeSearched = "Day";
            return name.Substring(name.IndexOf("Day") + toBeSearched.Length);
        }
    }
}
