using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                 .Split(" ")
                 .Select(int.Parse)
                 .ToList();
            int number = int.Parse(Console.ReadLine());

            numbers.Reverse();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % number == 0)
                {
                    numbers.Remove(numbers[i]);
                    i--;
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
