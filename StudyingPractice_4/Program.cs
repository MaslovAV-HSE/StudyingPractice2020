using System;
using System.Security.Cryptography.X509Certificates;

namespace StudyingPractice_4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ok = false;
            double x0 = 1.2;
            double x1 = 1.3;
            double e = 0.001;
            //input e
            do
            {
                try
                {
                    ok = double.TryParse(Console.ReadLine(), out e);
                }
                catch
                {
                    Console.WriteLine("Некорректное значение параметра e");
                }
            } while (!ok);

            double x = method_chord(x0, x1, e);
            Console.WriteLine(x);
            Console.ReadLine();
        }
        //method chord
        public static double method_chord(double x_prev, double x_curr, double e)
        {
            double x_next = 0;
            double tmp;

            do
            {
                tmp = x_next;
                x_next = x_curr - f(x_curr) * (x_prev - x_curr) / (f(x_prev) - f(x_curr));
                x_prev = x_curr;
                x_curr = tmp;
            } while (Math.Abs(x_next - x_curr) > e);

            return x_next;
        }
        //function 
        public static double f(double x)
        {
            return (4+ x*x)*(Math.Exp(x)- Math.Exp(-x))- 18;
        }
    }
}
