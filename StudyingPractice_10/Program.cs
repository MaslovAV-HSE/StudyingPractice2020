using System;

namespace StudyingPractice_10
{
    public class Tree // Класс дерева
    {
        public int data { get; set; } // Информационное поле
        public Tree left { get; set; } // Адрес левого поддерева
        public Tree right { get; set; } // Адрес правого поддерева

        public Tree(int value = 0) // Конструктор
        {
            data = value;
            left = null;
            right = null;
        }

        public static Tree MakeRoot(int value) // Создание элемента дерева
        {
            Tree nPoint = new Tree(value);
            return nPoint;
        }

        public static Tree IdealTree(int size, Random rnd) // Создание случайного дерева
        {
            if (size == 0)
                return null;
            Tree root = MakeRoot(rnd.Next(0, 10));
            int numL = size / 2, numR = size - numL - 1;
            root.left = IdealTree(numL, rnd);
            root.right = IdealTree(numR, rnd);
            return root;
        }

        public static void ShowTree(Tree root, int x, int y, int length = 20) // Красивейший вывод дерева
        {
            if (root == null)
                return;

            Console.SetCursorPosition(x, y);
            Console.Write(root.data);

            if (root.left != null)
            {
                int lengthleft = length;
                Console.SetCursorPosition(x, y + 1);
                Console.WriteLine('┘');
                Console.SetCursorPosition(x - lengthleft, y + 1);
                Console.Write("┌");
                while (lengthleft > 1)
                {
                    Console.SetCursorPosition(x - lengthleft + 1, y + 1);
                    Console.Write("─");
                    lengthleft--;
                }
            }

            if (root.right != null)
            {
                int lengthright = length;
                Console.SetCursorPosition(x, y + 1);
                Console.WriteLine('└');
                Console.SetCursorPosition(x + lengthright, y + 1);
                Console.Write("┐");
                while (lengthright > 1)
                {
                    Console.SetCursorPosition(x + lengthright - 1, y + 1);
                    Console.Write("─");
                    lengthright--;
                }
            }

            if (root.left != null && root.right != null)
            {
                Console.SetCursorPosition(x, y + 1);
                Console.WriteLine('┴');
            }

            length /= 2;
            ShowTree(root.left, x - length * 2, y + 2, length);
            ShowTree(root.right, x + length * 2, y + 2, length);
        }

        public static Tree Merger(Tree root) // Слияние деревьев 
        {
            if (root.left != null)
                Merger(root.left);
            if (root.right != null)
                Merger(root.right);
            root.left = null;
            root.right = null;
            root = null;
            return root;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
