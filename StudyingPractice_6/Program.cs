using System;
using System.Security.Cryptography;

namespace StudyingPractice_6
{
    class Program
    {
        public static double a1, a2, a3, M;
        public static int N;
        public static int J = 3;
        public static double AJ(double a1,double a2, double a3)
        {
            J++;
            double ak;
            ak = (3* a3)/2 - (2 * a2)/3 -  a1/3;
            Console.WriteLine("{0:0.000000}", ak);
            
            if (Math.Abs(ak) >= M && J <= N)
            {
                double a = a2;
                double b = a3;
                double c = ak;
                
                return AJ(a,b,c);
            }
            else return ak;
        }
        static void Main(string[] args)
        {
            bool ok = false;
            Console.Write("а1 = ");
            do
            {
                ok = double.TryParse(Console.ReadLine(), out a1);
                if (!ok) Console.WriteLine(@"a1 - должно быть числом
а1 = ");
            } while (!ok);

            Console.Write("а2 = ");
            do
            {
                ok = double.TryParse(Console.ReadLine(), out a2);
                if (!ok) Console.WriteLine(@"a2 - должно быть числом
а2 = ");
            } while (!ok);

            Console.Write("а3 = ");
            do
            {
                ok = double.TryParse(Console.ReadLine(), out a3);
                if (!ok) Console.WriteLine(@"a1 - должно быть числом
а2 = ");
            } while (!ok);

            Console.Write("М = ");
            do
            {
                ok = double.TryParse(Console.ReadLine(), out M);
                if (!ok) Console.WriteLine(@"М - должно быть числом
М = ");
                if(ok && M <= 0)
                {
                    ok = false;
                    Console.WriteLine("М - сравнивается с модулем элементов последовательности, не может быть <= 0");
                    Console.WriteLine("M = ");
                }
            } while (!ok);

            Console.Write("N = ");
            do
            {
                ok = Int32.TryParse(Console.ReadLine(), out N);
                if (!ok) Console.WriteLine(@"N - должно быть целым числом
N = ");
                if (ok && N < 4)
                {
                    ok = false;
                    Console.WriteLine("N - количество элементов последовательности, не может быть меньше 4");
                    Console.WriteLine("N = ");
                }
            } while (!ok);



            Console.WriteLine(a1);
            Console.WriteLine(a2);
            Console.WriteLine(a3);
            double result = AJ(a1, a2, a3);

            if (result == M) Console.WriteLine("параметр M и Aj равны");
            else Console.WriteLine("параметр M и Aj не равны");
            if (J < N) Console.WriteLine("J < N");
            if (J > N) Console.WriteLine("J < N");
            else Console.WriteLine("J = N");

        }
    }
}
