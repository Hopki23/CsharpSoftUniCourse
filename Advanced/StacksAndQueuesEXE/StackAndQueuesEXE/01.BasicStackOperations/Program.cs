using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(numbers);

            int countToPush = arr[0];
            int countToPop = arr[1];
            int numToLook = arr[2];

            for (int i = 0; i < countToPop; i++)
            {
                stack.Pop();
            }

            bool isFound = false;
            foreach (var number in stack)
            {
                if (number == numToLook)
                {
                    isFound = true;
                    Console.WriteLine("true");
                }
            }     
            if (!isFound)
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    int min = int.MaxValue;
                    foreach (var item in stack)
                    {
                        if (item < min)
                        {
                            min = item;
                        }
                    }
                    Console.WriteLine(min);
                }
            }
        }
    }
}
