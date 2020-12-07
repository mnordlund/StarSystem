using System;
using System.Collections.Generic;
using System.Text;

namespace StarSystem
{
    class Universe
    {
        public int ScreenWidth { get; }
        public int ScreenHeight { get; }

        private int _xpos = 0;
        private int _ypos = 0;

        public bool Alive { get; private set; }

        private char[] screenbuffer;

        public Universe(int width, int height)
        {
            ScreenWidth = width;
            ScreenHeight = height;
            Alive = true;
            screenbuffer = new char[ScreenWidth * ScreenHeight];
        }

        public void RenderFrame()
        {
            Console.SetCursorPosition(0, 0);
            for (var y = 0; y < ScreenHeight; y++)
            {
                for (var x = 0; x < ScreenWidth; x++)
                {
                    screenbuffer[x + y * ScreenWidth] = Star.GetStarChar(x + _xpos, y + _ypos);
                }
            }

            var statusString = $"{_xpos}x{_ypos}";

            statusString.CopyTo(0, screenbuffer, 0, statusString.Length);

            Console.Write(screenbuffer);
        }

        public void Update()
        {
            var key = Console.ReadKey();

            switch(key.Key)
            {
                case ConsoleKey.Escape:
                    Alive = false;
                    break;
                case ConsoleKey.UpArrow:
                    _ypos--;
                    break;
                case ConsoleKey.DownArrow:
                    _ypos++;
                    break;
                case ConsoleKey.LeftArrow:
                    _xpos--;
                    break;
                case ConsoleKey.RightArrow:
                    _xpos++;
                    break;
            }
            if(key.Key == ConsoleKey.Escape)
            { Alive = false; }


        }
    }
}
