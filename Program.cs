using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution__1_List_
{
    class Program
    {
        static void Main(string[] args)
        {
                bool removed;
                DynamicArray<int> Array = new DynamicArray<int>(new int[6] { 1, 2, 3, 4, 5, 6});

                Array.Add(7);
                Array.Add(25);
                Array.Add(23);
                Array.Add(22);
                Array.Add(28);

                Array.Insert(44, 0);
                Array.Insert(44, 4);
                Array.Insert(44, 10);

                removed = Array.Remove(22);
                Console.WriteLine($"Удаление элемента присутствующего в коллекции: {removed}");

                removed = Array.Remove(100);
                Console.WriteLine($"Удаление элемента отсутствующего в коллекции: {removed}");
                Console.WriteLine();

                OutputArray(Array);

                Console.ReadKey();
        }



        public static void OutputArray(DynamicArray<int> dynamic)
        {
            Console.WriteLine("Массив");
            for (int i = 0; i < dynamic.Length; i++)
            {
                Console.Write($"{dynamic[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Длина массива: {dynamic.Length}");
            Console.WriteLine($"Емкость массива: {dynamic.Capacity}");
            }
    }
}
