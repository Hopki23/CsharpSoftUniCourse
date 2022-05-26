using System;
using System.Linq;

namespace _05.SquareWithMaxSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = tokens[0];
            int cols = tokens[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }
            int maxSum = int.MinValue;
            int biggestRowIndex = 0;
            int biggestColIndex = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row + 1 < rows && col + 1 < cols)
                    {
                        int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1 , col + 1];
                        if (sum > maxSum)
                        {
                            maxSum = sum;
                            biggestColIndex = col;
                            biggestRowIndex = row;
                        }
                    }
                }
            }

            for (int row = biggestRowIndex; row < biggestRowIndex + 2; row++)
            {
                for (int col = biggestColIndex; col < biggestColIndex + 2; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxSum);
        }
    }
}
