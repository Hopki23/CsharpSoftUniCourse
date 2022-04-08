
using System;

namespace SumOfChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int interval = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < interval; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                sum += symbol;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
