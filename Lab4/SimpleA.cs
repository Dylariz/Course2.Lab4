using System;

namespace Lab4
{
    // Назовем магическим квадратом матрицу 3х3, заполненную натуральными числами, в которой:
    // 1. числа не повторяются
    // 2. суммы чисел в каждом ряду, каждом столбце и на обеих диагоналях совпадают.
    public class SimpleA
    {
        public int Start(int n)
        {
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = i + 1;
            }

            int count = 0;
            int[] rowSums = new int[3];
            int[] colSums = new int[3];

            // перебор всех возможных перестановок
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        int[][] square = new int[3][];

                        int[][] rows = new int[3][];
                        rows[0] = new[] { numbers[i], numbers[j], numbers[k] };
                        rows[1] = new[] { numbers[n - 1 - i], numbers[n - 1 - j], numbers[n - 1 - k] };
                        rows[2] = new[] { numbers[n / 2], numbers[n / 2 + 1], numbers[n / 2 - 1] };

                        int[][][] ints = new int[3][][];
                        // перебор всех возможных вариантов заполнения квадрата строками
                        for (int l = 0; l < 3; l++)
                        {
                            for (int m = 0; m < 3; m++)
                            {
                                square[l % 3] = rows[m % 3];
                                square[(l + 1) % 3] = rows[(m + 1) % 3];
                                square[(l + 2) % 3] = rows[(m + 2) % 3];
                                ints[l + m] = square;

                                for (int r = 0; r < 3; r++)
                                {
                                    rowSums[r] = square[r][0] + square[r][1] + square[r][2];
                                }

                                for (int c = 0; c < 3; c++)
                                {
                                    colSums[c] = square[0][c] + square[1][c] + square[2][c];
                                }

                                var diag1Sum = square[0][0] + square[1][1] + square[2][2];
                                var diag2Sum = square[0][2] + square[1][1] + square[2][0];

                                // проверка, является ли квадрат магическим
                                if (rowSums[0] == rowSums[1] && rowSums[1] == rowSums[2] && colSums[0] == colSums[1] &&
                                    colSums[1] == colSums[2] && diag1Sum == diag2Sum && rowSums[0] == colSums[0] &&
                                    colSums[0] == diag1Sum)
                                {
                                    count++;
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