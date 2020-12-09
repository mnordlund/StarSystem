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
            var key = Console.ReadKey(true);

            switch (key.Key)
            {
                // Quit
                case ConsoleKey.Escape:
                case ConsoleKey.Q:
                    Universe.Alive = false;
                    break;

                // Movement
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
                    Int16 x;
                    while(!Int16.TryParse(Console.ReadLine(), out x))
                    {
                        Console.Write($"X coordinate ({Int16.MinValue} - {Int16.MaxValue}): ");
                    }
                    Console.Write("Y coordinate: ");
                    Int16 y;
                    while(!Int16.TryParse(Console.ReadLine(),  out y))
                    {
                        Console.Write($"Y coordinate ({Int16.MinValue} - {Int16.MaxValue}): ");
                    }
                    Console.CursorVisible = false;
                    Universe.Goto(x, y);
                    break;

                case ConsoleKey.I:
                    Universe.YSelection--;
                    break;
                case ConsoleKey.K:
                    Universe.YSelection++;
                    break;
                case ConsoleKey.J:
                    Universe.XSelection--;
                    break;
                case ConsoleKey.L:
                    Universe.XSelection++;
                    break;
            }

        }
    }
}
