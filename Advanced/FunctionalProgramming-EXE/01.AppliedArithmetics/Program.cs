using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            Func<List<int>, List<int>> add = list => list.Select(number => number += 1).ToList();
            Func<List<int>, List<int>> multiply = list => list.Select(number => number *= 1).ToList();
            Func<List<int>, List<int>> subtract = list => list.Select(number => number -= 1).ToList();
            Action<List<int>> print = list => Console.WriteLine((string.Join(" ", list)));

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "add")
                {
                    numbers = add(numbers);
                }
                else if (input == "multiply")
                {
                    numbers = multiply(numbers);
                }
                else if (input == "subtract")
                {
                    numbers = subtract(numbers);
                }
                else if (input == "print")
                {
                    print(numbers);
                }
            }
        }
    }
}
