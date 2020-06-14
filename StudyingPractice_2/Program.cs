using System;
using System.IO;

namespace StudyingPractice_2
{
    class Program
    {
        //массив карт
        public static string el = "6 7 8 9 T J Q K A";
        public static char[] mas = el.ToCharArray();

        //проверка карт с одинкаовой мастью
        public static bool Check(char a, char b)
        {
            int aNum = 0;
            int bNum = 0;
            for(int i = 0; i < mas.Length; i++)
            {
                if (a == mas[i]) aNum = i;
                if (b == mas[i]) bNum = i;
            }
            if (aNum < bNum) return true;
            else return false;

        }
        //проверка на возможность покрытия карты
        public static bool CanBeatIt(string a, string b)
        {
            if (a[1] == b[1] && Check(a[0],b[0])) return true;
            return false;
        }
        static void Main(string[] args)
        {

            int N, M;
            string[] Nmas;
            string[] Mmas;
            string R;
            string path = @"INPUT.TXT";
            StreamReader sr = new StreamReader(path);
            string buf = sr.ReadLine();
            string[] buffermass = buf.Split(new char[] { ' ' });
            buf = sr.ReadLine();
            Nmas = buf.Split(new char[] { ' ' });
            buf = sr.ReadLine();
            Mmas = buf.Split(new char[] { ' ' });
            N = Int32.Parse(buffermass[0]);
            M = Int32.Parse(buffermass[1]);
            R = buffermass[2];
            string[] bufN = new string[Nmas.Length];
            string temp;
            int counter = 0;
            #region 1st Mass sort

            if(Nmas.Length > 1)
            {
                for (int i = 0; i < Nmas.Length; i++)
                {

                    for (int j = 1; j < Nmas.Length - 1; j++)
                    {

                        if (Nmas[i][1] == Nmas[j][1] && Check(Nmas[i][0], Nmas[j][0]))
                        {
                            temp = Nmas[j];
                            Nmas[j] = Nmas[i];
                            Nmas[i] = temp;
                        }

                    }

                }
                for (int i = 0; i < Nmas.Length; i++)
                {
                    if (Nmas[i][1] != Convert.ToChar(R))
                    {
                        bufN[counter] = Nmas[i];
                        counter++;
                    }
                }
                for (int i = 0; i < Nmas.Length; i++)
                {
                    if (Nmas[i][1] == Convert.ToChar(R))
                    {
                        bufN[counter] = Nmas[i];
                        counter++;
                    }

                }
            }

            #endregion
            #region Beat cards
            for (int i = 0; i< Mmas.Length; i++)
            {
                for(int j = 0; j< bufN.Length; j++)
                {
                    if (CanBeatIt(Mmas[i], bufN[j]))
                    {
                        Mmas[i] = "ZZ";
                        bufN[j] = "TT";
                    }
                }
            }
            int CountBeaten = 0;
            foreach(var x in Mmas)
            {
                if (x == "ZZ") CountBeaten++;
            }
            string path2 = @"OUTPUT.TXT";

            using (StreamWriter sw = new StreamWriter(path2, false, System.Text.Encoding.Default))
            {
                if (CountBeaten == Mmas.Length) sw.Write("YES");
                else sw.Write("NO"); ;
            }
            

            #endregion
        }
    }
}
