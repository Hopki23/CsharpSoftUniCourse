using System;
using System.Linq;

namespace _02.BattleOfFiveArmies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[][] jagged = new char[n][];
            int armyRow = 0;
            int armyCol = 0;
            for (int i = 0; i < n; i++)
            {
                jagged[i] = Console.ReadLine().ToCharArray();
            }
            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    if (jagged[row][col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }

            while (true)
            {
                string[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = arr[0];
                int row = int.Parse(arr[1]);
                int col = int.Parse(arr[2]);

                jagged[row][col] = 'O';
                jagged[armyRow][armyCol] = '-';
                armor--;

                if (direction == "up" && isValid(n, jagged, armyRow - 1, armyCol))
                {
                    armyRow--;
                }
                else if (direction == "down" && isValid(n, jagged, armyRow + 1, armyCol))
                {
                    armyRow++;
                }
                else if (direction == "left" && isValid(n, jagged, armyRow, armyCol - 1))
                {
                    armyCol--;
                }
                else if (direction == "right" && isValid(n, jagged, armyRow, armyCol + 1))
                {
                    armyCol++;
                }


                if (jagged[armyRow][armyCol] == 'M')
                {
                    jagged[armyRow][armyCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    break;
                }

                if (armor <= 0)
                {
                    break;
                }

                if (jagged[armyRow][armyCol] == 'O')
                {
                    armor -= 2;
                    if (armor <= 0)
                    {
                        break;
                    }
                    jagged[armyRow][armyCol] = 'A';
                }
                else
                {
                    jagged[armyRow][armyCol] = 'A';
                }
            }

            if (armor <= 0)
            {
                jagged[armyRow][armyCol] = 'X';
                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write(jagged[row][col]);
                }
                Console.WriteLine();
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
