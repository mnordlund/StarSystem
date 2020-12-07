using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StarSystem
{
    class Universe
    {
        public int ScreenWidth { get; }
        public int ScreenHeight { get; }

        public int Xpos { get; set; } = 0;
        public int Ypos { get; set; } = 0;

        public bool Alive { get; set; }

        private char[] screenbuffer;
        private Stopwatch _sw = new Stopwatch();

        private List<Star> _stars;

        public Universe(int width, int height)
        {
            ScreenWidth = width;
            ScreenHeight = height;
            Alive = true;
            screenbuffer = new char[ScreenWidth * ScreenHeight];
            _stars = new List<Star>();
        }

        public void RenderFrame()
        {
            _sw.Start();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            // Render screenbuffer.
            Console.Write(screenbuffer);

            // Render colored stars
            foreach(var star in _stars)
            {
                if(star.Color != ConsoleColor.White)
                {
                    Console.SetCursorPosition(star.CoordX - Xpos, star.CoordY - Ypos);
                    Console.ForegroundColor = star.Color;


                    Console.Write(star.Char);

                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }

            _sw.Stop();
        }

        public void Update()
        {
            var renderTime = _sw.ElapsedMilliseconds;
            _sw.Restart();
            _stars.Clear();
            Console.SetCursorPosition(0, 0);
            for (var y = 0; y < ScreenHeight; y++)
            {
                for (var x = 0; x < ScreenWidth; x++)
                {
                    var star = new Star(x + Xpos, y + Ypos);
                    if(star.IsStar)
                    {
                        screenbuffer[x + y * ScreenWidth] = star.Char;
                        _stars.Add(star);
                    }
                    else
                    {
                        screenbuffer[x + y * ScreenWidth] = ' ';
                    }
                    
                }
            }

            var statusString = $"{Xpos} x {Ypos} ({renderTime}ms)";

            statusString.CopyTo(0, screenbuffer, 0, statusString.Length);
            _sw.Stop();
        }
    }
}
