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
                case ConsoleKey.W:
                    Universe.Ypos -= YVelocity;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    Universe.Ypos += YVelocity;
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    Universe.Xpos -= XVelocity;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    Universe.Xpos += XVelocity;
                    break;

                case ConsoleKey.G:
                    Console.SetCursorPosition(0, 0);
                    Console.CursorVisible = true;
                    Console.WriteLine("Goto poition:");
                    Console.Write("X coordinate: ");
                    var x = Int16.Parse(Console.ReadLine());
                    Console.Write("Y coordinate: ");
                    var y = Int16.Parse(Console.ReadLine());
                    Console.CursorVisible = true;
                    Universe.Goto(x, y);
                    break;
            }

        }
    }
}
