using System;
using System.Linq;

namespace TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < values.Length; i++)
            {
                bool isTopInteger = true;
                for (int k = i + 1; k < values.Length; k++)
                {
                    if (values[i] <= values[k])
                    {
                        isTopInteger = false;
                        break;
                    }
                }

                if (isTopInteger)
                {
                    Console.Write(values[i] + " ");
                }
            }
        }
    }
}