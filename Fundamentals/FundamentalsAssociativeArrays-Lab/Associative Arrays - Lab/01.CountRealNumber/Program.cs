using System;
using System.Collections.Generic;
using System.Linq;

namespace CountRealNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            SortedDictionary<double, int> dictionary = new SortedDictionary<double, int>();

            foreach (var number in numbers)
            {
                if (dictionary.ContainsKey(number))
                {
                    dictionary[number]++;
                }
                else
                {
                    dictionary.Add(number, 1);
                }
            }

            foreach (var number in dictionary)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}
