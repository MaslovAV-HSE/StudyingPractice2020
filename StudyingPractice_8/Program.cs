using System;
using System.Collections.Generic;

namespace StudyingPractice_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количестов вершин");
            int N = 0; bool ok = false;
            while (!ok)
            {
                try
                {
                    ok = Int32.TryParse(Console.ReadLine(), out N);
                }
                catch
                {
                    Console.WriteLine("Некорректное значение количества вершин");
                }
            }
            byte[,] Matrix = new byte[N, N];
            Console.WriteLine("Введиете матрицу(1 - есть ребро, 0 - нет ребра)");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    do
                    {
                        ok = byte.TryParse(Console.ReadLine(), out Matrix[i, j]);
                        if (!ok) Console.WriteLine("Некорректное значение вершины");
                    } while (!ok);

                }
            }
            List<int> V_List = new List<int>();
            for (int i = 0; i < N; i++)
            {
                int counter = 0;
                for (int j = 0; j < N; j++)
                {
                    if (Matrix[i, j] == 1) counter = -1;
                }
                if (counter == 0) V_List.Add(i+1);
                counter = 0;
            }
            Console.Write("Пустой граф состоит из вершин: ");
            foreach(var x in V_List)
            {
                Console.Write($"{x} ");
            }

        }
    }
}
