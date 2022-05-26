using System;
using System.Linq;

namespace _06.JaggedArrModificator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] jagged = new int[n][];
            for (int i = 0; i < n; i++)
            {
                jagged[i] = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] arr = input.Split();
                int row = int.Parse(arr[1]);
                int col = int.Parse(arr[2]);
                int value = int.Parse(arr[3]);

                if (row < 0 || col < 0 ||row >= jagged.Length || col >= jagged[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else if (arr[0] == "Add")
                {
                    jagged[row][col] += value;
                }
                else if (arr[0] == "Subtract")
                {
                    jagged[row][col] -= value;
                }
            }

            for (int row = 0; row < jagged.Length; row++)
            {
                Console.WriteLine(string.Join(" ",jagged[row]));
            }
        }
    }
}
