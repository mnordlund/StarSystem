using System;
using Troschuetz.Random;
using Troschuetz.Random.Distributions.Continuous;
using Troschuetz.Random.Generators;


namespace StarSystem
{
    class Star
    {

        private static readonly char[] startypes = { 'O', '¤', '*', 'o', '.' };
        private static readonly ConsoleColor[] colors = { ConsoleColor.Yellow, ConsoleColor.Gray, ConsoleColor.DarkGray, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.Red };
        private NR3Generator _rnd;

        private int Seed => (CoordX & 0xFFFF) << 16 | (CoordY & 0xFFFF);
        public int CoordX { get; }
        public int CoordY { get; }
        public bool IsStar { get; }
        public char Char { get; }
        public ConsoleColor Color { get; } = ConsoleColor.White;

        public string Name { get;  }

        public Star(int x, int y, bool generateFullInfo = false)
        {

            CoordX = x;
            CoordY = y;

            _rnd = new NR3Generator(Seed);

            IsStar = _rnd.Next(1, 150) == 1;

            if (!IsStar) return;

            Char = startypes[_rnd.Next(0, startypes.Length)];
            var colorChance = _rnd.Next(0, 100);
            if(colorChance < colors.Length)
            {
                Color = colors[colorChance];
            }

            // If we should generate full info generate all information.
            if (!generateFullInfo) return;

            Name = new StarNameGenerator().GenerateStarName(Seed);
        }

        public override string ToString()
        {
            if (!IsStar) return "";
            
            return $"{Char} - {Name} ({CoordX}x{CoordY})";
        }

        public override bool Equals(object obj)
        {
            if(obj is Star)
            {
                var cmp = (Star)obj;
                return cmp.Seed == Seed;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Seed;
        }

        public int Distance(Star star)
        {
            return Math.Abs(CoordX - star.CoordX) + Math.Abs(CoordY - star.CoordY);
        }
    }
}
