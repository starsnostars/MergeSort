using System;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 38, 27, 43, 3, 9, 82, 10 };
            var sorter = new MergeSort();

            var sorted = sorter.Sort(arr);

            Console.ReadKey();
        }
    }
}
