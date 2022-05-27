using System;
using System.Linq;

namespace _09.Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] comands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            char[,] matrix = new char[n, n];
            ReadMatrix(matrix);

            int startingPointRowIndex = 0;
            int startingPointColIndex = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        startingPointRowIndex = row;
                        startingPointColIndex = col;
                    }
                }
            }
            int currRow = startingPointRowIndex;
            int currCol = startingPointColIndex;
            for (int i = 0; i < comands.Length; i++)
            {
                if (comands[i] == "left")
                {
                    if (isValid(matrix, currRow, currCol - 1))
                    {
                        if (matrix[currRow, currCol - 1] == 'e')
                        {
                            Console.WriteLine($"Game over! ({currRow}, {currCol - 1})");
                            return;
                        }
                        currCol--;
                        if (matrix[currRow, currCol] == 'c')
                        {
                            matrix[currRow, currCol] = '*';
                        }
                    }
                }
                else if (comands[i] == "right")
                {
                    if (isValid(matrix, currRow, currCol + 1))
                    {
                        if (matrix[currRow, currCol + 1] == 'e')
                        {
                            Console.WriteLine($"Game over! ({currRow}, {currCol + 1})");
                            return;
                        }

                        currCol++;
                        if (matrix[currRow, currCol] == 'c')
                        {
                            matrix[currRow, currCol] = '*';
                        }
                    }
                }
                else if (comands[i] == "up")
                {
                    if (isValid(matrix, currRow - 1, currCol))
                    {
                        if (matrix[currRow - 1, currCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({currRow - 1}, {currCol})");
                            return;
                        }

                        currRow--;
                        if (matrix[currRow, currCol] == 'c')
                        {
                            matrix[currRow, currCol] = '*';
                        }
                    }
                }
                else if (comands[i] == "down")
                {
                    if (isValid(matrix, currRow + 1, currCol))
                    {
                        if (matrix[currRow + 1, currCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({currRow + 1}, {currCol})");
                            return;
                        }

                        currRow++;
                        if (matrix[currRow, currCol] == 'c')
                        {
                            matrix[currRow, currCol] = '*';
                        }
                    }
                }
            }

            int coalCounter = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'c')
                    {
                        coalCounter++;
                    }
                }
            }
            if (coalCounter == 0)
            {
                Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
            }
            else
            {
                Console.WriteLine($"{coalCounter} coals left. ({currRow}, {currCol})");
            }
        }

         static void ReadMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currArr[col];
                }
            }
        }

        static bool isValid(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
