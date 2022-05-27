using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currArr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currArr[col];

                }
            }

            int primarySum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        primarySum += matrix[row, col];
                    }
                }
            }

            int secondarySum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                secondarySum += matrix[i, matrix.GetLength(1) -1 - i];
            }
            Console.WriteLine(Math.Abs(primarySum - secondarySum));
        }
    }
}
