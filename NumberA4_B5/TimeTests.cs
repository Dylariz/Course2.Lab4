using System.Diagnostics;

namespace NumberA4_B5
{
    public static class TimeTests
    {
        public static long SlowATest(int n)
        {
            var watch = Stopwatch.StartNew();
            ProgramA.SlowA(n);
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
        
        public static long SlowBTest(int n)
        {
            var watch = Stopwatch.StartNew();
            ProgramB.SlowB(n);
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
        
        public static long FastBTest(int n)
        {
            var watch = Stopwatch.StartNew();
            ProgramB.FastB(n);
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}