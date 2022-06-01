using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvenOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int[] numbers = Console.ReadLine()
               .Split(" ")
               .Select(int.Parse)
               .ToArray();
            int starting = numbers[0];
            int end = numbers[1];

            List<int> list = new List<int>();
            for (int i = starting; i <= end; i++)
            {
                list.Add(i);
            }

            Predicate<int> predicate = null;

            string input = Console.ReadLine();
            if (input == "even")
            {
                predicate = number => number % 2 == 0;
            }
            else if (input == "odd")
            {
                predicate = number => number % 2 != 0;
            }

            Console.WriteLine(string.Join(" ", list.FindAll(predicate)));
        }
    }
}
