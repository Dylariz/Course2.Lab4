using System.Diagnostics;

namespace Lab4
{
    public static class TimeTests
    {
        public static long SimpleATest(int n)
        {
            var watch = Stopwatch.StartNew();
            ProgramA.SimpleA(n);
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
        
        public static long SimpleBTest(int n)
        {
            var watch = Stopwatch.StartNew();
            ProgramB.SimpleB(n);
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
        
        public static long StrongBTest(int n)
        {
            var watch = Stopwatch.StartNew();
            ProgramB.StrongB(n);
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}