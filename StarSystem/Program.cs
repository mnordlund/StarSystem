using System;
using System.Diagnostics;

namespace StarSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 160;
            Console.WindowHeight = 40;

            var universe = new Universe(160, 40);
            var frameTimes = new long[5];
            var frameCount = 0;
            var sw = new Stopwatch();
            while (universe.Alive)
            {
                sw.Restart();
                universe.RenderFrame();
                sw.Stop();
                frameTimes[frameCount % 5] = sw.ElapsedMilliseconds;
                frameCount++;
                universe.Update();
            }

            Console.WriteLine($"Frametimes: {frameTimes[0]}, {frameTimes[1]}, {frameTimes[2]}, {frameTimes[3]}, {frameTimes[4]}");
            

        }
    }
}
