  using System;

namespace StudyingPractice_3
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 0, y = 0;
            bool ok = false;
            
            //check x
            do
            {
                try
                {
                    Console.WriteLine("Введите х");
                    ok = double.TryParse(Console.ReadLine(), out x);
                }
                catch
                {
                    Console.WriteLine("х должен быть числом!");
                }
            } while (!ok);

            //check y
            do
            {
                try
                {
                    Console.WriteLine("Введите y");
                    ok = double.TryParse(Console.ReadLine(), out y);
                }
                catch
                {
                    Console.WriteLine("y должен быть числом");
                }
            } while (!ok);


            //find answer
            ok = (y >= 0) && (x*x + y*y >=1) && (x*x + y*y<=4) ;

            //output
            if (ok)
            {
                Console.WriteLine(0);
            }
            else Console.WriteLine(x);

        }
    }
}
