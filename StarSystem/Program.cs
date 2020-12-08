using System;
using System.Diagnostics;

namespace StarSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int width= Console.WindowWidth;
            int height = Console.WindowHeight;

            // Setup console
            Console.CursorVisible = false;

            var universe = new Universe(width, height);
            var controller = new Controller(universe);

            // Game loop
            while (universe.Alive)
            {

                universe.Update();
                universe.RenderFrame();
                controller.Update();
                if(Console.WindowWidth != width || Console.WindowHeight != height)
                {
                    width = Console.WindowWidth;
                    height = Console.WindowHeight;

                    universe.SetScreenSize(width, height);
                }
            }
            Console.Clear();
        }
    }
}
