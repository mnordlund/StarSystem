using System;
using System.Diagnostics;

namespace StarSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            const int WIDTH = 160;
            const int HEIGHT = 40;

            // Setup console
            Console.WindowWidth = WIDTH;
            Console.WindowHeight = HEIGHT;
            Console.CursorVisible = false;

            var universe = new Universe(WIDTH, HEIGHT);
            var controller = new Controller(universe);

            // Game loop
            while (universe.Alive)
            {
                universe.Update();
                universe.RenderFrame();
                controller.Update();

            }
            Console.Clear();
        }
    }
}
