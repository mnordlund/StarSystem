using System;

namespace StarSystem
{
    class Controller
    {
        public Universe Universe { get; }

        private const int XVelocity = 3;
        private const int YVelocity = 1;

        public Controller(Universe universe)
        {
            Universe = universe;
        }

        public void Update()
        {
            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.Escape:
                case ConsoleKey.Q:
                    Universe.Alive = false;
                    break;
                case ConsoleKey.UpArrow:
                    Universe.Ypos -= YVelocity;
                    break;
                case ConsoleKey.DownArrow:
                    Universe.Ypos += YVelocity;
                    break;
                case ConsoleKey.LeftArrow:
                    Universe.Xpos -= XVelocity;
                    break;
                case ConsoleKey.RightArrow:
                    Universe.Xpos += XVelocity;
                    break;
            }

        }
    }
}
