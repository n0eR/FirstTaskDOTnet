using System;

namespace MainNamespace
{
    public class main
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Создадим односвязный список. \nДобавим шесть слов (от одного до шести). Выведем список:");

            LinkedList linked_list = new LinkedList();
            linked_list.Add("Один");
            linked_list.Add("Два");
            linked_list.Add("Три");
            linked_list.Add("Четыре");
            linked_list.Add("Пять");
            linked_list.Add("Шесть");

            foreach (var item in linked_list)
                Console.WriteLine(item);

            Console.WriteLine(new String('-', 20));
            Console.WriteLine("Удаляем элемент \"один\". Выводим список заново:");
            linked_list.Remove("Один");
            foreach (var item in linked_list)
                Console.WriteLine(item);

            Console.WriteLine(new String('-', 20));
            Console.WriteLine("Делаем реверс:");
            linked_list.Revers();
            foreach (var item in linked_list)
                Console.WriteLine(item);

            Console.WriteLine(new String('-', 20));
            Console.WriteLine("Создадим бинарное дерево. \nДобавим в него 9 элементов (цифры от 1 до 9, заданные случайным образом). Выведем дерево:");

            var binary_tree = new BinaryTree();

            binary_tree.AddNode(1);
            binary_tree.AddNode(4);
            binary_tree.AddNode(7);
            binary_tree.AddNode(3);
            binary_tree.AddNode(5);
            binary_tree.AddNode(2);
            binary_tree.AddNode(8);
            binary_tree.AddNode(6);
            binary_tree.AddNode(9);

            binary_tree.PrintTree();
            Console.WriteLine(new String('-', 20));

            Console.WriteLine("Удалим элементы 6 и 8. Выведем дерево снова:");

            binary_tree.Remove(6);
            binary_tree.Remove(8);

            binary_tree.PrintTree();
            Console.WriteLine(new String('-', 20));

            Console.WriteLine("Создадим массив из 10ти элементов, заполним его случайными числами. Выведем массив:");
            int[] array = new int[10];
            for (int i = 0; i < 10; i++)
            {
                array[i] = new Random().Next(0, 1000);
                Console.Write($"{ array[i] } ");
            }
            Console.WriteLine("\n" + new String('-', 20));
            Console.WriteLine("Отсортируем массив и выведем его снова:");

            InsertionSort(array); 
            for (int i = 0; i < 10; i++) Console.Write($"{ array[i] } ");
            Console.WriteLine("\n" + new String('-', 20));

            Console.ReadKey();
        }

        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j;
                int buf = array[i];
                for (j = i - 1; j >= 0; j--)
                {
                    if (array[j] < buf)
                        break;

                    array[j + 1] = array[j];
                }
                array[j + 1] = buf;
            }
        }
    }
}
