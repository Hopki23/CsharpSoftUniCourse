using System;

namespace _3.Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            if (command == "add")
            {
                PrintAdd(firstNum, secondNum);
            }
            else if (command == "multiply")
            {
                PrintMultiply(firstNum, secondNum);
            }
            else if (command == "subtract")
            {
                PrintSubtract(firstNum, secondNum);
            }
            else if (command == "divide")
            {
                PrintDivide(firstNum, secondNum);
            }
        }

        static void PrintDivide(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum / secondNum);
        }

        static void PrintSubtract(int firstNum, int secondNum)
        {
            Console.WriteLine(firstNum - secondNum);
        }

        static void PrintMultiply(int first, int second)
        {
            Console.WriteLine(first * second);
        }

        static void PrintAdd(int first, int second)
        {
            Console.WriteLine(first + second);
        }
    }
}
