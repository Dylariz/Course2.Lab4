using System;
using System.Collections.Generic;

namespace NumberA6_B4
{
    /// <summary>
    /// Электронный прибор оснащен 10 коммутационными разъемами, каждый разъем имеет по 100 выводов.
    /// В исправном приборе при подаче питания на каждом выводе образуется некоторый электрический потенциал.
    /// В приборе обнаруживается «обрыв», если на каком-либо выводе включенного прибора потенциал равен нулю.
    /// В приборе обнаруживается «пробой», если разность потенциалов между любыми двумя выводами включенного прибора равна нулю.
    /// Найти все «обрывы» и «пробои» в n приборах.
    /// </summary>
    public static class AlgorithmB
    {
        // Медленный алгоритм
        public static int SlowB(int n)
        {
            const int connectorCount = 10;
            const int pinCount = 100;
            var random = new Random();

            var pins = new int[connectorCount, pinCount]; // Потенциалы выводов
            int breakCount = 0; // Обрывы
            int breakdownCount = 0; // Пробои

            for (int i = 0; i < n; i++) // Перебор приборов
            {
                var potentials = new HashSet<int>(); // Множество потенциалов

                // Заполнение массива случайными значениями и проверка на обрывы
                for (int j = 0; j < connectorCount; j++)
                {
                    for (int k = 0; k < pinCount; k++)
                    {
                        pins[j, k] = random.Next(-100, 100); // Потенциалы от -100 до 100
                        if (pins[j, k] == 0)
                        {
                            breakCount++;
                        }
                        else
                        {
                            potentials.Add(pins[j, k]);
                        }
                    }
                }

                // Проверка на пробои
                for (int j = 0; j < connectorCount; j++)
                {
                    for (int k = 0; k < pinCount; k++)
                    {
                        if (pins[j, k] != 0 && potentials.Contains(-pins[j, k]))
                        {
                            breakdownCount++;
                        }
                    }
                }
            }

            return breakCount + breakdownCount;
        }
    }
}