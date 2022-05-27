using System;
using System.Linq;

namespace _04.MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = arr[0];
            int cols = arr[1];
            string[,] matrix = new string[rows, cols];
            ReadMatrix(matrix);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split();
                if (tokens[0] == "swap" && tokens.Length == 5)
                {
                    int row = int.Parse(tokens[1]);
                    int col = int.Parse(tokens[2]);
                    int row1 = int.Parse(tokens[3]);
                    int col2 = int.Parse(tokens[4]);

                    if (row < 0 || row > rows || col < 0 || col > cols || row1 < 0 || row1 > rows || col2 < 0 || col2 > cols)
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        string toReplace = matrix[row, col];
                        string toReplace2 = matrix[row1, col2];
                        matrix[row, col] = toReplace2;
                        matrix[row1, col2] = toReplace;

                        PrintMatrix(matrix);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
         static void ReadMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] currArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currArr[col];
                }
            }
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
