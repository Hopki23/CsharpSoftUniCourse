
using System;

namespace ReverseArrayOfStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            for (int i = 0; i < input.Length / 2; i++)
            {
                var temp = input[i];
                input[i] = input[input.Length - 1 - i];
                input[input.Length - 1 - i] = temp;
            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
