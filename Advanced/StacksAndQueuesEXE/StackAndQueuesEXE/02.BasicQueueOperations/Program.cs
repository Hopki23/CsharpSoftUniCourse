using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
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
            Queue<int> queue = new Queue<int>(numbers);

            int countToEnqueue = arr[0];
            int countToDequeue = arr[1];
            int numToLook = arr[2];

            for (int i = 0; i < countToDequeue; i++)
            {
                queue.Dequeue();
            }

            bool isFound = false;
            foreach (var number in queue)
            {
                if (number == numToLook)
                {
                    isFound = true;
                    Console.WriteLine("true");
                }
            }
            if (!isFound)
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    int min = int.MaxValue;
                    foreach (var item in queue)
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
