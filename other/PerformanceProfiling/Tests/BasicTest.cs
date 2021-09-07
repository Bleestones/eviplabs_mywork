using Launcher;
using System;
using Xunit;

namespace Tests
{
    public class BasicTest
    {
        [Fact]
        public void BenchmarkingTest()
        {
            var w = new SlowWorker();
            w.PreapreTask(10000);
            w.PerformTask();
        }
    }
}
