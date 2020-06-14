using System;
using System.Collections.Generic;
using System.Linq;

namespace Task7
{
    class Node
    {
        public int Number { get; set; }
        public Node Left { get; set; } //0
        public Node Middle { get; set; } //1
        public Node Right { get; set; } //2
        public bool IsEnd { get; set; } //занято ли

        public Node(int number)
        {
            Number = number;
            Left = Middle = Right = null;
            IsEnd = false;
        }
    }
    class Tree
    {
        public Tree()
        {
            root = new Node(-1);
        }
        public Node root { get; set; }
        public static List<string> words;

        public static void ShowTree(Node p, int l)
        {
            if (p != null)
            {
                ShowTree(p.Right, l + 5);
                for (int i = 0; i < l; i++)
                    Console.Write(" ");
                Console.WriteLine("{0,10:F4}", p.Number);
                ShowTree(p.Middle, l + 5);
                ShowTree(p.Left, l + 5);
            }
        }

        public static void GenerateEndpoints(Node p, int currentLength, int length)
        {
            if (currentLength != length - 1)
            {
                if (p.Left != null && p.Left.IsEnd == false)
                    GenerateEndpoints(p.Left, currentLength + 1, length);
                else if (p.Left == null)
                {
                    p.Left = new Node(0);
                    GenerateEndpoints(p.Left, currentLength + 1, length);
                }

                else if (p.Middle != null && p.Middle.IsEnd == false)
                    GenerateEndpoints(p.Middle, currentLength + 1, length);
                else if (p.Middle == null)
                {
                    p.Middle = new Node(1);
                    GenerateEndpoints(p.Middle, currentLength + 1, length);
                }

                else if (p.Right != null && p.Right.IsEnd == false)
                    GenerateEndpoints(p.Right, currentLength + 1, length);
                else if (p.Right == null)
                {
                    p.Right = new Node(2);
                    GenerateEndpoints(p.Right, currentLength + 1, length);
                }
            }
            else
            {
                if (p.Left == null || p.Left.IsEnd == false)
                {
                    p.Left = new Node(0);
                    p.Left.IsEnd = true;
                }
                else if (p.Middle == null || p.Middle.IsEnd == false)
                {
                    p.Middle = new Node(1);
                    p.Middle.IsEnd = true;
                }
                else if (p.Right == null || p.Right.IsEnd == false)
                {
                    p.Right = new Node(2);
                    p.Right.IsEnd = true;
                }
            }
        }

        public static void GenerateWords(Node p, string word)
        {
            if (p != null && p.IsEnd == false)
            {
                word += p.Number;
                GenerateWords(p.Left, word);
                GenerateWords(p.Middle, word);
                GenerateWords(p.Right, word);
            }
            else if (p != null && p.IsEnd == true)
            {
                word += p.Number;
                word = word.Remove(0, 2);//удалить -1
                words.Add(word);
            }
        }
    }

        class Program
    {
        //проверка длин кодовых слов по неравенству Макмиллана
        static bool CheckLengths(int[] lengths)
        {
            double sum = 0;
            foreach (int num in lengths)
                sum += 1 / Math.Pow(3, num);

            if (sum <= 1)
                return true;
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 7\n=================");
            Console.WriteLine("Условие задачи:\nПостроить префиксный троичный код с заданными длинами кодовых слов.\n" +
                              "Кодовые слова выписать в лексикографическом порядке.\n" +
                              "=================");
            bool ok;
            int[] lengthsOfWords = null;
            do
            {
                do
                {
                    try
                    {
                        Console.WriteLine("Введите длины кодовых слов, разделяя их пробелом:");
                        lengthsOfWords = Console.ReadLine().
                        Split(new Char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).
                        Select(x => int.Parse(x)).ToArray();
                        ok = true;
                    }
                    catch
                    {
                        ok = false;
                        Console.WriteLine("Некорректный ввод");
                    }
                } while (!ok);
                ok = CheckLengths(lengthsOfWords);
                if (!ok)
                    Console.WriteLine("Ошибка! Введенные длины кодовых слов не прошли проверку по неравенству Макмиллана. Повторите ввод.");
            } while (!ok);

            lengthsOfWords = lengthsOfWords.OrderBy(num => num).ToArray();

            Tree tree = new Tree();

            foreach (int length in lengthsOfWords)
                Tree.GenerateEndpoints(tree.root, 0, length);

            Tree.words = new List<string>(lengthsOfWords.Length);
            Tree.GenerateWords(tree.root, string.Empty);

            Console.Write("Построенный префиксный троичный код: ");
            foreach (string word in Tree.words)
                Console.Write($"{word} ");
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
