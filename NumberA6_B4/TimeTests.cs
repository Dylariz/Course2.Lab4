using System.Diagnostics;

namespace NumberA6_B4
{
    public static class TimeTests
    {
        public static long SlowATest(int n)
        {
            var watch = Stopwatch.StartNew();
            AlgorithmA.SlowA(n);
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
        
        public static long FastATest(int n)
        {
            var watch = Stopwatch.StartNew();
            AlgorithmA.FastA(n);
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
        
        public static long SlowBTest(int n)
        {
            var watch = Stopwatch.StartNew();
            AlgorithmB.SlowB(n);
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}