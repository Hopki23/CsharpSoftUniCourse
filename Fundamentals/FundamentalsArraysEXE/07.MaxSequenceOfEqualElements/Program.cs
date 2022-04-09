
using System;
using System.Linq;

namespace MaxSequenceOfEqualElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            
            int lenght = 1;
            int maxSequence = 0;
            int start = 0;
            int bestStart = 0;
            //2 1 1 2 3 3 2 2 2 1
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == arr[i - 1])
                {
                    lenght++;
                }
                else
                {
                    lenght = 1;
                    start = i;
                }

                if (lenght > maxSequence)
                {
                    maxSequence = lenght;
                    bestStart = start;
                }
            }

            for (int i = bestStart; i < bestStart + maxSequence; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
