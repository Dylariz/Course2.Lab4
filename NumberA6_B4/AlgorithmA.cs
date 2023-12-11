using System;
using System.Collections.Generic;

namespace NumberA6_B4
{
    /// <summary>
    /// На книжном стеллаже с шириной полок 100 см необходимо расставить n книг толщиной от 10 до 50 мм так, чтобы они занимали минимальное количество полок.
    /// </summary>
    public static class AlgorithmA
    {
        const int ShelfWidth = 1000;
        
        // Медленный алгоритм
        public static int SlowA(int n)
        {
            var random = new Random();

            int shelfCount = 0;
            var books = new List<int>(); // Толщины книг
            var placed = new List<bool>(); // Флаги размещения книг

            // Заполнение списков
            for (int i = 0; i < n; i++)
            {
                books.Add(random.Next(10, 50));
                placed.Add(false);
            }

            while (books.Count > 0)
            {
                int shelfWidthLeft = ShelfWidth;
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i] <= shelfWidthLeft && !placed[i])
                    {
                        // Цикл для проверки каждой книги с каждой другой книгой
                        for (int j = 0; j < books.Count; j++)
                        {
                            // Если книга не размещена и ее толщина меньше или равна оставшейся ширине полки
                            if (i != j && books[j] <= shelfWidthLeft && !placed[j])
                            {
                                shelfWidthLeft -= books[j];
                                placed[j] = true;
                            }
                        }

                        shelfWidthLeft -= books[i];
                        placed[i] = true;
                    }
                }

                shelfCount++;

                // Создание нового списка неразмещенных книг
                var newBooks = new List<int>();
                var newPlaced = new List<bool>();
                for (int i = 0; i < books.Count; i++)
                {
                    if (!placed[i])
                    {
                        newBooks.Add(books[i]);
                        newPlaced.Add(false);
                    }
                }

                books = newBooks;
                placed = newPlaced;
            }

            return shelfCount;
        }

        // Быстрый алгоритм
        public static int FastA(int n)
        {
            var random = new Random();

            int shelfCount = 0;
            var books = new List<int>(); // Толщины книг

            // Заполнение списка
            for (int i = 0; i < n; i++)
            {
                books.Add(random.Next(10, 50));
            }

            books.Sort();
            books.Reverse(); // Сортировка в обратном порядке
            
            // Размещение книг
            while (books.Count > 0)
            {
                int shelfWidthLeft = ShelfWidth;
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i] <= shelfWidthLeft)
                    {
                        shelfWidthLeft -= books[i];
                        books.RemoveAt(i);
                        i--;
                    }
                }

                shelfCount++;
            }

            return shelfCount;
        }
    }
}