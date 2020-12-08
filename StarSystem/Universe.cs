using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace StarSystem
{
    class Universe
    {
        public int ScreenWidth { get; private set; }
        public int ScreenHeight { get; private set; }

        public Int16 Xpos { get; set; } = 0;
        public Int16 Ypos { get; set; } = 0;

        public bool Alive { get; set; }

        private char[] _clearscreen;

        private string locationString;

        private Stopwatch _sw = new Stopwatch();

        private List<Star> _stars;

        public Universe(int width, int height)
        {
            ScreenWidth = width;
            ScreenHeight = height;
            Xpos = 0;
            Ypos = 0;
            Alive = true;
            _clearscreen = Enumerable.Repeat(' ', ScreenWidth * ScreenHeight).ToArray();
            _stars = new List<Star>();
        }

        public void RenderFrame()
        {
            _sw.Start();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            // Clear Screen, this is faster than Console.Clear
            Console.SetCursorPosition(0, 0);
            Console.Write(_clearscreen);
            // Render stars stars
            foreach (var star in _stars)
            {
                Console.SetCursorPosition(star.CoordX - Xpos, star.CoordY - Ypos);
                Console.ForegroundColor = star.Color;


                Console.Write(star.Char);

            }

            Console.SetCursorPosition(0, 0);
            Console.Write(locationString);
            _sw.Stop();
        }

        public void Update()
        {
            var renderTime = _sw.ElapsedMilliseconds;
            _sw.Restart();
            _stars.Clear();
            for (var y = 0; y < ScreenHeight; y++)
            {
                for (var x = 0; x < ScreenWidth; x++)
                {
                    var star = new Star((x + Xpos), (y + Ypos));
                    if(star.IsStar)
                    {
                        _stars.Add(star);
                    }
                    
                }
            }

            locationString = $"{Xpos} x {Ypos} ({renderTime}ms)";
            _sw.Stop();
        }

        public void SetScreenSize(int width, int height)
        {
            ScreenWidth = width;
            ScreenHeight = height;

            _clearscreen = Enumerable.Repeat(' ', ScreenWidth * ScreenHeight).ToArray();
        }



        public void Goto(Int16 x, Int16 y)
        {
            Xpos = x;
            Ypos = y;
        }
    }
}
