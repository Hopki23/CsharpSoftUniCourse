using System;
using System.Linq;

namespace _04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
           decimal[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse).ToArray();

            foreach (var number in numbers)
            {
                Console.WriteLine($"{number * 1.20m:F2}");
            }
        }
    }
}
