namespace Lab4
{
    public static class ProgramA
    {
        public static int SimpleA(int n)
        {
            int count = 0; // счетчик количества магических квадратов

            for (int a = 1; a <= n; a++)
            {
                for (int b = 1; b <= n; b++)
                {
                    if (b == a) continue;
                    for (int c = 1; c <= n; c++)
                    {
                        if (c == a || c == b) continue;
                        for (int d = 1; d <= n; d++)
                        {
                            if (d == a || d == b || d == c) continue;
                            for (int e = 1; e <= n; e++)
                            {
                                if (e == a || e == b || e == c || e == d) continue;
                                for (int f = 1; f <= n; f++)
                                {
                                    if (f == a || f == b || f == c || f == d || f == e) continue;
                                    for (int g = 1; g <= n; g++)
                                    {
                                        if (g == a || g == b || g == c || g == d || g == e || g == f) continue;
                                        for (int h = 1; h <= n; h++)
                                        {
                                            if (h == a || h == b || h == c || h == d || h == e || h == f || h == g)
                                                continue;
                                            for (int i = 1; i <= n; i++)
                                            {
                                                if (i == a || i == b || i == c || i == d || i == e || i == f ||
                                                    i == g || i == h) continue;
                                                if (a + b + c == d + e + f && d + e + f == g + h + i &&
                                                    g + h + i == a + d + g && a + d + g == b + e + h &&
                                                    b + e + h == c + f + i)
                                                {
                                                    count++;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return count;
        }
    }
}