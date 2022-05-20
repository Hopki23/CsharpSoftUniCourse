using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrienEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            Queue<int> numbers = new Queue<int>();

            foreach (var number in arr)
            {
                if (number % 2 == 0)
                {
                    numbers.Enqueue(number);
                }
            }
            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
