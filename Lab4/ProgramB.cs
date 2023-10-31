using System;
using System.Collections.Generic;

namespace Lab4
{
    public static class ProgramB
    {
        public static int SimpleB(int n)
        {
            int[] heights = new int[n];
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                heights[i] = random.Next(50, 1000);
            }

            int count = 0; // количество мячиков на одной высоте

            for (int i = 0; i < 7 * 24 * 60 * 60; i++) // симулируем неделю
            {
                Dictionary<int, int>
                    heightsCount =
                        new Dictionary<int, int>(); // словарь для подсчета количества мячиков на каждой высоте

                for (int j = 0; j < n; j++)
                {
                    heights[j]--; // падение мячика

                    if (heights[j] == 0) // отскок мячика
                    {
                        heights[j] = random.Next(5, 11);
                    }

                    if (!heightsCount.ContainsKey(heights[j]))
                    {
                        heightsCount[heights[j]] = 0;
                    }

                    heightsCount[heights[j]]++;

                    if (heightsCount[heights[j]] == n) // все мячики на одной высоте
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static int StrongB(int n)
        {
            int[] heights = new int[n];
            Random random = new Random();
            
            for (int i = 0; i < n; i++)
            {
                heights[i] = random.Next(50, 500);
            }
            
            int lcm = heights[0];
            for (int i = 1; i < n; i++)
            {
                lcm = lcm * heights[i] / Gcd(lcm, heights[i]);
            }
            
            int count = (int)Math.Ceiling(7.0 / lcm);

            return count;
        }

        static int Gcd(int a, int b)
        {
            while (b != 0)
                (a, b) = (b, a % b);
            
            return a;
        }
    }
}