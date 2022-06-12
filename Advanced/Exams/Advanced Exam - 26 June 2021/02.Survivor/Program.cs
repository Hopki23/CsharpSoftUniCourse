using System;
using System.Linq;

namespace _02.Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] jagged = new char[rows][];
            ReadJaggedArray(rows, jagged);

            int collectedTokens = 0;
            int opponentTokens = 0;

            string input;
            while ((input = Console.ReadLine()) != "Gong")
            {
                string[] arr = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = arr[0];
                int row = int.Parse(arr[1]);
                int col = int.Parse(arr[2]);

                if (command == "Find")
                {
                    if (isValid(rows, jagged, row, col))
                    {
                        if (jagged[row][col] == 'T')
                        {
                            collectedTokens++;
                            jagged[row][col] = '-';
                        }
                    }
                }
                else if (command == "Opponent")
                {
                    string direction = arr[3];
                    if (isValid(rows, jagged, row, col))
                    {
                        if (jagged[row][col] == 'T')
                        {
                            opponentTokens++;
                            jagged[row][col] = '-';
                        }

                        if (direction == "up")
                        {
                            MovingUp(rows, jagged, ref opponentTokens, ref row, col);
                        }
                        else if (direction == "down")
                        {
                            MovingDown(rows, jagged, ref opponentTokens, ref row, col);
                        }
                        else if (direction == "left")
                        {
                            MoveLeft(rows, jagged, ref opponentTokens, row, ref col);
                        }
                        else if (direction == "right")
                        {
                            MoveRight(rows, jagged, ref opponentTokens, row, ref col);
                        }
                    }
                }
            }

            PrintJagged(rows, jagged);
            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        public static void MoveLeft(int rows, char[][] jagged, ref int opponentTokens, int row, ref int col)
        {
            for (int i = 1; i <= 3; i++)
            {
                col--;
                if (isValid(rows, jagged, row, col))
                {
                    if (jagged[row][col] == 'T')
                    {
                        opponentTokens++;
                        jagged[row][col] = '-';
                    }
                }
                else
                {
                    break;
                }
            }
        }

        public static void MoveRight(int rows, char[][] jagged, ref int opponentTokens, int row, ref int col)
        {
            for (int i = 1; i <= 3; i++)
            {
                col++;
                if (isValid(rows, jagged, row, col))
                {
                    if (jagged[row][col] == 'T')
                    {
                        opponentTokens++;
                        jagged[row][col] = '-';
                    }
                }
                else
                {
                    break;
                }
            }
        }

        public static void PrintJagged(int rows, char[][] jagged)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    if (col >= jagged[row].Length)
                    {
                        Console.Write(jagged[row][col]);
                    }
                    else
                    {
                        Console.Write(jagged[row][col] + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void MovingDown(int rows, char[][] jagged, ref int opponentTokens, ref int row, int col)
        {
            for (int i = 1; i <= 3; i++)
            {
                row++;
                if (isValid(rows, jagged, row, col))
                {
                    if (jagged[row][col] == 'T')
                    {
                        opponentTokens++;
                        jagged[row][col] = '-';
                    }
                }
                else
                {
                    break;
                }
            }
        }

        public static void MovingUp(int rows, char[][] jagged, ref int opponentTokens, ref int row, int col)
        {
            for (int i = 1; i <= 3; i++)
            {
                row--;
                if (isValid(rows, jagged, row, col))
                {
                    if (jagged[row][col] == 'T')
                    {
                        opponentTokens++;
                        jagged[row][col] = '-';
                    }
                }
                else
                {
                    break;
                }
            }
        }

        public static void ReadJaggedArray(int rows, char[][] jagged)
        {
            for (int i = 0; i < rows; i++)
            {
                jagged[i] = Console.ReadLine().Split(" ").Select(char.Parse).ToArray();
            }
        }

        public static bool isValid(int rows, char[][] jagged, int row, int col)
        {
            if (row >= 0 && row < rows && col < jagged[row].Length && col >= 0)
            {
                return true;
            }
            return false;
        }
    }
}
