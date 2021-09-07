using System;
using System.Diagnostics;

namespace Launcher
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            p.MeasureExecutionTimeCharacteristics(1000, 10000, 1000);
        }

        private void MeasureExecutionTimeCharacteristics(int minSize, int maxSize, int step)
        {
            for(int n=minSize; n<=maxSize; n+=step)
            {
                RunSingleMeasurementAndShowTime(n);
            }
        }

        public void RunSingleMeasurementAndShowTime(int n)
        {
            var s = new SlowWorker();
            s.PreapreTask(n);
            var sw = new Stopwatch();
            sw.Start();
            s.PerformTask();
            long ms = sw.ElapsedMilliseconds;
            Console.WriteLine($"Elapsed time for n={n}: {ms} ms");
        }
    }
}
