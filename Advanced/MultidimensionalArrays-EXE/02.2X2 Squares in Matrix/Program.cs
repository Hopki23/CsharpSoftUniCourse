using System;
using System.Linq;

namespace _02._2X2_Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = arr[0];
            int cols = arr[1];
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currArr = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currArr[col];
                }
            }
            int counter = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row + 1 < rows && col + 1 < cols)
                    {
                        if (matrix[row, col] == matrix[row , col + 1]
                            && matrix[row , col] == matrix[row + 1 , col]
                            && matrix[row, col] == matrix[row + 1 , col + 1]
                            && matrix[row, col + 1] == matrix[row + 1 , col]
                            && matrix[row, col + 1] == matrix[row + 1 , col + 1]
                             && matrix[row + 1, col] == matrix[row + 1, col + 1])
                        {
                            counter++;
                        }
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
