using Microsoft.VisualBasic.CompilerServices;
using System;
using System.IO;
using System.Linq;

namespace StudyingPractice_1
{

    class Program
    {
        public static int x1, x2, y1, y2, x3, y3, r;

        static void Main(string[] args)
        {
            
            string path = @"C:\Users\Maslov Alexander\Studying\Программирование\Учебная практика\Тесты\1 задача\INPUT.txt";
            StreamReader sr = new StreamReader(path);
            string buf = sr.ReadLine();
            int[] arr = buf.Split(new Char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).
Select(x => int.Parse(x)).ToArray();
            x1 = arr[0];
            y1 = arr[1];
            x2 = arr[2];
            y2 = arr[3];
            buf = sr.ReadLine();
            arr = buf.Split(new Char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).
Select(x => int.Parse(x)).ToArray();
            x3 = arr[0];
            y3 = arr[1];
            
            r = arr[2];
            int count = 0;

            int square_x1 = x3 - r - 1;
            int square_y1 = y3 - r - 1;
            int square_x2 = x3 + r + 1;
            int square_y2 = y3 + r + 1;


            for (int i = square_x1; i <= square_x2; i++)
            {
                for (int j = square_y1; j <= square_y2; j++)
                {
                    if ((Math.Sqrt((i - x3) * (i - x3) + (j - y3) * (j - y3)) <= r) && (i >= x1 && i <= x2 && j >= y1 && y1 <= y2)) count++;
                }
            }
            string path2 = @"C:\Users\Maslov Alexander\Studying\Программирование\Учебная практика\Тесты\1 задача\OUTPUT.txt";
            using (StreamWriter sw = new StreamWriter(path2, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(count);
            }
            Console.WriteLine(count);


        }
    }
}
