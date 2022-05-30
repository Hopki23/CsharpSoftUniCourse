using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> set = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split(" ");
                for (int j = 0; j < elements.Length; j++)
                {
                    set.Add(elements[j]);
                }
            }
            Console.WriteLine(string.Join(" ",set));
        }
    }
}
