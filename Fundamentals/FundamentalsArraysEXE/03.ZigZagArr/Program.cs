using System;
using System.Linq;

namespace ZigZagArr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            int[] arr2 = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();    
                int firstNum = input[0];
                int secondNum = input[1];

                if (i % 2 == 0)
                {
                    arr[i] = firstNum;
                    arr2[i] = secondNum;
                }
                else
                {
                    arr[i] = secondNum;
                    arr2[i] = firstNum;
                }
            }
            Console.WriteLine(string.Join(" ", arr));
            Console.WriteLine(string.Join(" ", arr2));
        }
    }
}
