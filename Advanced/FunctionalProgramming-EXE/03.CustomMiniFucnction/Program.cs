using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CustomMiniFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            Func<List<int>, int> minNumber = number => numbers.Min();

            Console.WriteLine(minNumber(numbers));
        }
    }
}
