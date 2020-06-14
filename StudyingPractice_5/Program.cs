using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace StudyingPractice_5
{
    class Program
    {
        static public int[,] Mas;
        static public List<int> B_Sum = new List<int>();
        
        //Count sum
        static int Sum(int i, int j)
        {
            int Sum=0;
            for(int k = j+1; k < Mas.GetLength(0); k++)
            {
                Sum += Mas[i, k];
            }
            return Sum;
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Введите N");
            bool ok = false; int n=0;
            while (!ok)
            {
                try
                {
                    ok = Int32.TryParse(Console.ReadLine(), out n);
                }
                catch
                {
                    Console.WriteLine("Некорректные данные");
                }
            }
            Mas = new int[n, n];
            Console.WriteLine("Вводите массив");
            //assign mass
            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Mas[i, j] = Int32.Parse(Console.ReadLine());
                }
            }
            //initialize answer List
            for (int i = 0; i < n; i++)
            {
                B_Sum.Add(100);
            }
            //sort through 
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Mas[i,j] < 0)
                    {
                        B_Sum[i] = Sum(i, j);
                        break;
                    }
                }
            }
            //write answer
            Console.WriteLine("Значения b1....bn");
            foreach(var x in B_Sum)
            {
                Console.Write($"{x} ");
            }

        }
    }
}
