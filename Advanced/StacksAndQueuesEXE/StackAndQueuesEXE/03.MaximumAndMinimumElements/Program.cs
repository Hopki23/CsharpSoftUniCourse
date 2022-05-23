using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElements
{
     class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] arr = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

                if (arr[0] == 1)
                {
                    int numToPush = arr[1];
                    stack.Push(numToPush);
                }
                else if (arr[0] == 2)
                {
                    stack.Pop();
                }
                else if (arr[0] == 3)
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                else if (arr[0] == 4)
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }
            Console.WriteLine(string.Join(", ",stack));
        }
    }
}
