using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jagged = new double[rows][];

            for (int i = 0; i < rows; i++)
            {
                jagged[i] = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (jagged[row].Length == jagged[row + 1].Length)
                {
                    for (int rowCurrent = row; rowCurrent <= row + 1; rowCurrent++)
                    {
                        for (int col = 0; col < jagged[rowCurrent].Length; col++)
                        {
                            jagged[rowCurrent][col] *= 2;
                        }
                    }
                }
                else
                {
                    for (int rowCurrent = row; rowCurrent <= row + 1; rowCurrent++)
                    {
                        for (int col = 0; col < jagged[rowCurrent].Length; col++)
                        {
                            jagged[rowCurrent][col] /= 2;
                        }
                    }
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (tokens[0] == "Add")
                {
                    if (isValid(rows, jagged, row, col))
                    {
                        jagged[row][col] += value;
                    } 
                }
                else if (tokens[0] == "Subtract")
                {
                    if (isValid(rows, jagged, row, col))
                    {
                        jagged[row][col] -= value;
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write(jagged[row][col] + " ");
                }
                Console.WriteLine();
            }
        }

         static bool isValid(int rows, double[][] jagged, int row, int col)
        {
            if (row >= 0 && row < rows && col < jagged[row].Length && col >= 0)
            {
                return true;
            }
            return false;
        }
    }
}
