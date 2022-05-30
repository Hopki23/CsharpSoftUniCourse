using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = arr[0];
            int m = arr[1];
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();          
            for (int i = 1; i <= n + m; i++)
            {
                int numbers = int.Parse(Console.ReadLine());
                if (i <= n)
                {
                    firstSet.Add(numbers);
                }
                else
                {
                    secondSet.Add(numbers);
                }
            }
            foreach (var item in firstSet)
            {
                foreach (var second in secondSet)
                {
                    if (item == second)
                    {
                        Console.Write(item + " ");
                    }
                }
            }
        }
    }
}
