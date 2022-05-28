using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValues
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            Dictionary<double, int> count = new Dictionary<double, int>();

            foreach (var number in arr)
            {
                if (count.ContainsKey(number) == false)
                {
                    count.Add(number, 0);
                }
                count[number]++;
            }

            foreach (var pair in count)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }
        }
    }
}
