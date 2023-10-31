using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4
{
    public static class ProgramB
    {

        public static int SimpleB(int n)
        {
            Ball[] balls = new Ball[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                balls[i] = new Ball(random.Next(4, 30));
            }

            int count = 0;

            for (int i = 0; i < 7; i++) // симулируем неделю
            {
                for (int j = 0; j < 24; j++)
                {
                    for (int k = 0; k < 60; k++)
                    {
                        for (int l = 0; l < 60; l++)
                        {
                            List<int> heights = new List<int>();

                            for (int t = 0; t < n; t++)
                            {
                                if (balls[t].Direction == -1) // падение мячика
                                {
                                    balls[t].Height--;
                                }
                                else
                                {
                                    balls[t].Height++;
                                }
                     

                                if (balls[t].Height == 0) // отскок мячика
                                {
                                    balls[t].Direction = 1;
                                }
                                else if(balls[t].Height == balls[t].StartHeight) // мячик вернулся на исходную высоту
                                {
                                    balls[t].Direction = -1;
                                }

                                if (!heights.Contains(balls[t].Height))
                                {
                                    heights.Add(balls[t].Height);
                                }
                            }

                            if (heights.Count == 1)
                            {
                                count++;
                            }
                        }
                    }
                }
                
            }

            return count;
        }
        

        public static int StrongB(int n)
        {
            Ball[] balls = new Ball[n];
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                balls[i] = new Ball(random.Next(4, 30));
            }
            
            int count = 0;

            for (int i = 0; i < 7 * 24 * 60 * 60; i++) // симулируем неделю
            {
                for (int j = 0; j < n; j++)
                {
                    if (balls[j].Direction == -1) // падение мячика
                    {
                        balls[j].Height--;
                    }
                    else
                    {
                        balls[j].Height++;
                    }
                     

                    if (balls[j].Height == 0) // отскок мячика
                    {
                        balls[j].Direction = 1;
                    }
                    else if(balls[j].Height == balls[j].StartHeight) // мячик вернулся на исходную высоту
                    {
                        balls[j].Direction = -1;
                    }
                }
                
                int prevHeight = balls[0].Height;
                for (int j = 0; j < n; j++)
                {
                    if (j != 0)
                    {
                        if (balls[j].Height == prevHeight) // мячик на той же высоте, что и предыдущий
                        {
                            if (j == n - 1)
                            {
                                count++;
                            }
                        }
                        else
                        {
                            break;
                        }
                        prevHeight = balls[j].Height;
                    }
                }
            }

            return count;
        }

        public class Ball
        {
            public int StartHeight { get; }
            public int Height { get; set; }
            public int Direction { get; set; } // 1 - вверх, -1 - вниз
            
            public Ball(int startHeight)
            {
                StartHeight = startHeight;
                Height = startHeight;
                Direction = -1;
            }
        }
    }
}