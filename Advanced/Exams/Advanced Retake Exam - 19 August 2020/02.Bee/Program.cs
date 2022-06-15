using System;

namespace _02.Bee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int beeRow = 0;
            int beeCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currArr = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currArr[col];
                    if (matrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }
            int flowersCounter = 0;
            string direction;
            while ((direction = Console.ReadLine()) != "End")
            {
                matrix[beeRow, beeCol] = '.';
                if (direction == "up" && isValid(matrix, beeRow - 1, beeCol))
                {
                    beeRow--;
                }
                else if (direction == "down" && isValid(matrix, beeRow + 1, beeCol))
                {
                    beeRow++;
                }
                else if (direction == "left" && isValid(matrix, beeRow, beeCol - 1))
                {
                    beeCol--;
                }
                else if (direction == "right" && isValid(matrix, beeRow, beeCol + 1))
                {
                    beeCol++;
                }
                else
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }


                if (matrix[beeRow, beeCol] == 'O')
                {
                    matrix[beeRow, beeCol] = '.';
                    if (direction == "up" && isValid(matrix, beeRow - 1, beeCol))
                    {
                        beeRow--;
                    }
                    else if (direction == "down" && isValid(matrix, beeRow + 1, beeCol))
                    {
                        beeRow++;
                    }
                    else if (direction == "left" && isValid(matrix, beeRow, beeCol - 1))
                    {
                        beeCol--;
                    }
                    else if (direction == "right" && isValid(matrix, beeRow, beeCol + 1))
                    {
                        beeCol++;
                    }
                    else
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }
                }
                if (matrix[beeRow, beeCol] == 'f')
                {
                    flowersCounter++;
                }
                matrix[beeRow, beeCol] = 'B';
            }

            if (flowersCounter >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowersCounter} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowersCounter} flowers more");
            }

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
