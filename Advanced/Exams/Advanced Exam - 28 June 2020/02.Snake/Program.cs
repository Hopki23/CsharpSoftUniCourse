using System;
using System.Linq;

namespace _02.Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int snakeRow = 0;
            int snakeCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currArr = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currArr[col];
                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }

                }
            }
            int foodCounter = 0;
            while (true)
            {
                string direction = Console.ReadLine();
                matrix[snakeRow, snakeCol] = '.';

                if (direction == "up" && isValid(matrix, snakeRow - 1, snakeCol))
                {
                    snakeRow--;
                }
                else if (direction == "down" && isValid(matrix, snakeRow + 1, snakeCol))
                {
                    snakeRow++;
                }
                else if (direction == "left" && isValid(matrix, snakeRow, snakeCol - 1))
                {
                    snakeCol--;
                }
                else if (direction == "right" && isValid(matrix, snakeRow, snakeCol + 1))
                {
                    snakeCol++;
                }
                else
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                if (matrix[snakeRow, snakeCol] == '*')
                {
                    foodCounter++;
                }
                else if (matrix[snakeRow, snakeCol] == 'B')
                {
                    matrix[snakeRow, snakeCol] = '.';
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (matrix[row, col] == 'B')
                            {
                                snakeRow = row;
                                snakeCol = col;
                            }
                        }
                    }
                }
                matrix[snakeRow, snakeCol] = 'S';
                if (foodCounter >= 10)
                {
                    Console.WriteLine("You won! You fed the snake.");
                    break;
                }
            }
            Console.WriteLine($"Food eaten: {foodCounter}");
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        public static bool isValid(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
