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

        private int _xselection;
        public int XSelection { get => _xselection; 
            set 
            {
                if (value < 0 || value >= ScreenWidth) return;
                _xselection = value;
            } }
        private int _yselection;
        public int YSelection { get=> _yselection;
            set
            {
                if (value < 0 || value >= ScreenHeight) return;
                _yselection = value;
            } }

        public bool Alive { get; set; }

        private char[] _clearscreen;

        private string _locationString;

        private Stopwatch _sw = new Stopwatch();

        private List<Star> _stars;

        public Universe(int width, int height)
        {
            ScreenWidth = width;
            ScreenHeight = height;
            Xpos = 0;
            Ypos = 0;
            XSelection = ScreenWidth / 2;
            YSelection = ScreenHeight / 2;
            Alive = true;
            _clearscreen = Enumerable.Repeat(' ', ScreenWidth * ScreenHeight).ToArray();
            _stars = new List<Star>();
        }

        private string cursorhor; // Horizontal line of the cursor;
        private Star selectedStar;
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
                    if (star.IsStar)
                    {
                        _stars.Add(star);
                    }

                }
            }

            int cursorwidth = 5;
            if (XSelection < 2) cursorwidth -= 2 - XSelection;
            if (XSelection > ScreenWidth - 3) cursorwidth -= 3 - (ScreenWidth - XSelection);

            Console.ForegroundColor = ConsoleColor.White;

            cursorhor = new string(' ', cursorwidth);

            _locationString = $"{Xpos} x {Ypos} ({renderTime}ms)";

            selectedStar = new Star(Xpos + XSelection, Ypos + YSelection, true); 
            _sw.Stop();
        }

        public void RenderFrame()
        {
            _sw.Start();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            // Clear Screen, this is faster than Console.Clear
            Console.SetCursorPosition(0, 0);
            Console.Write(_clearscreen);

            // Render selection
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(Math.Max(XSelection - 2, 0), YSelection);
            Console.Write(cursorhor);
            for(int i = Math.Max(YSelection - 2, 0); i <= Math.Min(YSelection + 2, ScreenHeight); i++)
            {
                Console.SetCursorPosition(XSelection, i);
                Console.Write(' ');
            }

            Console.BackgroundColor = ConsoleColor.Black;
            // Render stars stars
            foreach (var star in _stars)
            {
                Console.SetCursorPosition(star.CoordX - Xpos, star.CoordY - Ypos);
                Console.ForegroundColor = star.Color;


                Console.Write(star.Char);

            }

            Console.SetCursorPosition(0, 0);
            Console.Write(_locationString);

            Console.SetCursorPosition(0, ScreenHeight - 1);
            Console.Write(selectedStar.ToString());
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
