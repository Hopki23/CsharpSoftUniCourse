using System;
using System.Linq;

namespace _03.MaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = arr[0];
            int cols = arr[1];
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currArr[col];
                }
            }
            int maxSum = int.MinValue;
            int biggestRowIndex = 0;
            int biggestColIndex = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row + 2 < rows && col + 2 < cols)
                    {
                        int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                            + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                            + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                        if (sum > maxSum)
                        {
                            maxSum = sum;
                            biggestRowIndex = row;
                            biggestColIndex = col;
                        }
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = biggestRowIndex; row < biggestRowIndex + 3; row++)
            {
                for (int col = biggestColIndex; col < biggestColIndex + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
