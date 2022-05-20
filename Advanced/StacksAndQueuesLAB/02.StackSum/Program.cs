using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(arr);
            string input;
            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                string[] tokens = input.Split(' ');
                if (tokens[0] == "add")
                {
                    int first = int.Parse(tokens[1]);
                    int second = int.Parse(tokens[2]);
                    stack.Push(first);
                    stack.Push(second);
                }
                else if (tokens[0] == "remove")
                {
                    int count = int.Parse(tokens[1]);
                    if (stack.Count >= count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }
            int sum = 0;
            foreach (var item in stack)
            {
                sum += item;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
