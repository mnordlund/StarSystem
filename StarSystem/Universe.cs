using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StarSystem
{
    class Universe
    {
        public int ScreenWidth { get; private set; }
        public int ScreenHeight { get; private set; }

        public Int16 Xpos { get; set; } = 0;
        public Int16 Ypos { get; set; } = 0;

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
            for (Int16 y = 0; y < ScreenHeight; y++)
            {
                for (Int16 x = 0; x < ScreenWidth; x++)
                {
                    var star = new Star((Int16)(x + Xpos), (Int16)(y + Ypos));
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

        public void SetScreenSize(int width, int height)
        {
            ScreenWidth = width;
            ScreenHeight = height;

            screenbuffer = new char[ScreenWidth * ScreenHeight];
        }



        public void Goto(Int16 x, Int16 y)
        {
            Xpos = x;
            Ypos = y;
        }
    }
}
