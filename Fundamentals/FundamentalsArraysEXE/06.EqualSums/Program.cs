using System;
using System.Linq;

namespace EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < values.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;

                for (int j = 0; j < i; j++)
                {
                    leftSum += values[j];
                }

                for (int k = i + 1; k < values.Length; k++)
                {
                    rightSum += values[k];
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine("no");
        }
    }
}