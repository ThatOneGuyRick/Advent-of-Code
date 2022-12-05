using AdventOfCode;
using AdventOfCode.Common;

namespace AdventOfCode2022.Code
{
    internal class Day5 : IAdventOfCode
    {
        private List<(int amount, int from, int to)> _moves = new();
        private CrateStack[] _stacks;
        private int _lastCrateLine;

        private string[] _lines;

        public Day5()
        {
            _lines = File.ReadAllLines("Input/day5.txt");
            Setup();
        }

        private void Setup()
        {
            _stacks = new CrateStack[(_lines[0].Length + 1) / 4];

            _lastCrateLine = 0;
            for (int i = 0; i < _lines.Length; i++)
            {
                string line = _lines[i];
                if (line[1] == '1')
                {
                    _lastCrateLine = i;
                    break;
                }
            }

            for (int i = 0; i < _lastCrateLine; i++)
            {
                string line = _lines[i];
                for (int j = 1; j < line.Length; j += 4)
                {
                    if (line[j] != ' ')
                    {
                        CrateStack stack = _stacks[j / 4];
                        if (stack == null)
                        {
                            stack = new CrateStack(_lastCrateLine * _stacks.Length);
                            _stacks[j / 4] = stack;
                            stack.Size = _lastCrateLine - i;
                        }

                        stack.Stack[_lastCrateLine - i - 1] = line[j];
                    }
                }
            }



            if (_moves.Count == 0)
            {
                for (int i = 10; i < _lines.Length; i++)
                {
                    string line = _lines[i];
                    string[] splits = line.SplitOn("move ", " from ", " to ");
                    int amount = splits[1].ToInt();
                    int from = splits[2].ToInt() - 1;
                    int to = splits[3].ToInt() - 1;

                    _moves.Add((amount, from, to));
                }
            }
        }


        public string PartOne()
        {
            for (int i = 0; i < _moves.Count; i++)
            {
                (int amount, int from, int to) = _moves[i];
                _stacks[from].MoveTo(_stacks[to], amount);
            }

            return TopOfStacks();
        }

        public string PartTwo()
        {
            Setup();
            for (int i = 0; i < _moves.Count; i++)
            {
                (int amount, int from, int to) = _moves[i];
                _stacks[from].MoveToAtOnce(_stacks[to], amount);
            }

            return TopOfStacks();
        }
        private string TopOfStacks()
        {
            char[] result = new char[_stacks.Length];
            for (int i = 0; i < _stacks.Length; i++)
            {
                result[i] = _stacks[i].Top;
            }
            return new string(result);
        }

        private class CrateStack
        {
            public char[] Stack;
            public int Size;

            public CrateStack(int maxSize)
            {
                Stack = new char[maxSize];
            }
            public char Top { get { return Stack[Size - 1]; } }
            public void MoveTo(CrateStack target, int amount)
            {
                Size -= amount;
                for (int i = Size + amount - 1; i >= Size; i--)
                {
                    target.Stack[target.Size++] = Stack[i];
                }
            }
            public void MoveToAtOnce(CrateStack target, int amount)
            {
                for (int i = Size - amount; i < Size; i++)
                {
                    target.Stack[target.Size++] = Stack[i];
                }
                Size -= amount;
            }
            public override string ToString()
            {
                return $"Size={Size} Top={Top}";
            }
        }
    }
}
