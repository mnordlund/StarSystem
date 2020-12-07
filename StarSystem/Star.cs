using System;
using Troschuetz.Random;
using Troschuetz.Random.Distributions.Continuous;
using Troschuetz.Random.Generators;


namespace StarSystem
{
    class Star
    {

        private static readonly char[] startypes = { '*', 'O', 'o', '¤' };
        private static readonly ConsoleColor[] colors = { ConsoleColor.Gray, ConsoleColor.DarkGray, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Magenta, ConsoleColor.Red };
        private NR3Generator _rnd;

        public int CoordX { get; }
        public int CoordY { get; }
        public bool IsStar { get; }
        public char Char { get; }
        public ConsoleColor Color { get; } = ConsoleColor.White;


        public static bool IsStarAt(int x, int y)
        {
            var rnd = new NR3Generator(x * y);

            return rnd.Next(1, 200) == 1; 
        }

        public Star(int x, int y)
        {
            _rnd = new NR3Generator(x * y);

            CoordX = x;
            CoordY = y;

            IsStar = _rnd.Next(1, 200) == 1;
            Char = startypes[_rnd.Next(0, 4)];
            var colorChance = _rnd.Next(0, 50);
            if(colorChance < colors.Length)
            {
                Color = colors[colorChance];
            }
        }

        public override string ToString()
        {
            return $"{CoordX} x {CoordY}";
        }

        public override bool Equals(object obj)
        {
            if(obj is Star)
            {
                var cmp = (Star)obj;
                return cmp.CoordX == CoordX && cmp.CoordY == CoordY;
            }

            return false;
        }

        public int Distance(Star star)
        {
            return Math.Abs(CoordX - star.CoordX) + Math.Abs(CoordY - star.CoordY);
        }
    }
}
