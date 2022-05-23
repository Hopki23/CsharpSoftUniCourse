using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(arr);
            int capacity = int.Parse(Console.ReadLine());
            int counter = 1;
            int sum = 0;

            while (stack.Count > 0)
            {
                int currValue = stack.Peek();
                sum += currValue;
                if (sum > capacity)
                {
                    counter++;
                    sum = 0;
                }
                else if (sum == capacity)
                {
                    counter++;
                    sum = 0;
                    stack.Pop();
                }
                else
                {
                    stack.Pop();
                }
            }
            Console.WriteLine(counter);
        }
    }
}
