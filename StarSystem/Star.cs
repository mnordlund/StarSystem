using System;
using Troschuetz.Random;
using Troschuetz.Random.Distributions.Continuous;
using Troschuetz.Random.Generators;


namespace StarSystem
{
    class Star
    {
        private static readonly char[] startypes = { '*', 'O', 'o', '¤' };
        public static bool IsStar(int x, int y)
        {
            var rnd = new TRandom(x * y);

            return rnd.Next(1, 20) == 1; 
        }

        public static char GetStarChar(int x, int y)
        {
            var rnd = new NR3Generator(x*y);
            if (rnd.Next(1, 100) == 1)
            {
                return startypes[rnd.Next(0, 4)];
            }
            else
            {
                return ' ';
            }
        }
    }
}
