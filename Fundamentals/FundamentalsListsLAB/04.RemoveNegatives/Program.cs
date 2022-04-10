using System;
using System.Collections.Generic;
using System.Linq;

namespace SumofArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers2 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x >= 0)
                .Reverse()
                .ToList();

            if (numbers2.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                Console.WriteLine(string.Join(" ", numbers2));
            }
        }
    }
}