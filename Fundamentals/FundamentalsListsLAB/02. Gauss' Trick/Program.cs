using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Gauss__Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                int sum = numbers[i] + numbers[numbers.Count - i - 1];
                Console.Write($"{sum} ");
            }

            if (numbers.Count % 2 == 1)
            {
                Console.Write($"{numbers[numbers.Count / 2]}");
            }
        }
    }
}
