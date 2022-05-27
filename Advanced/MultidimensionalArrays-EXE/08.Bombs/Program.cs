using System;
using System.Linq;

namespace _08.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
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

            int[] arr = Console.ReadLine().Split(new char[] { ' ', ',' }).Select(int.Parse).ToArray();

            for (int i = 0; i < arr.Length; i += 2)
            {
                int bombRow = arr[i];
                int bombCol = arr[i + 1];

                if (matrix[bombRow, bombCol] <= 0)
                {
                    continue;
                }
                else
                {
                    int value = matrix[bombRow, bombCol];
                    if (isValid(matrix, bombRow - 1, bombCol - 1) && matrix[bombRow - 1, bombCol - 1] > 0)
                    {
                        matrix[bombRow - 1, bombCol - 1] -= value;
                    }

                    if (isValid(matrix, bombRow - 1, bombCol) && matrix[bombRow - 1, bombCol] > 0)
                    {
                        matrix[bombRow - 1, bombCol] -= value;
                    }

                    if (isValid(matrix, bombRow - 1, bombCol + 1) && matrix[bombRow - 1, bombCol + 1] > 0)
                    {
                        matrix[bombRow - 1, bombCol + 1] -= value;
                    }

                    if (isValid(matrix, bombRow, bombCol - 1) && matrix[bombRow, bombCol - 1] > 0)
                    {
                        matrix[bombRow, bombCol - 1] -= value;
                    }

                    if (isValid(matrix, bombRow, bombCol + 1) && matrix[bombRow, bombCol + 1] > 0)
                    {
                        matrix[bombRow, bombCol + 1] -= value;
                    }

                    if (isValid(matrix, bombRow + 1, bombCol - 1) && matrix[bombRow + 1, bombCol - 1] > 0)
                    {
                        matrix[bombRow + 1, bombCol - 1] -= value;
                    }

                    if (isValid(matrix, bombRow + 1, bombCol) && matrix[bombRow + 1, bombCol] > 0)
                    {
                        matrix[bombRow + 1, bombCol] -= value;
                    }

                    if (isValid(matrix, bombRow + 1, bombCol + 1) && matrix[bombRow + 1, bombCol + 1] > 0)
                    {
                        matrix[bombRow + 1, bombCol + 1] -= value;
                    }

                    matrix[bombRow, bombCol] = 0;
                }
            }
            int counter = 0;
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        counter++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {counter}");
            Console.WriteLine($"Sum: {sum}");

            PrintMatrix(matrix);
        }

         static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        static bool isValid(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
