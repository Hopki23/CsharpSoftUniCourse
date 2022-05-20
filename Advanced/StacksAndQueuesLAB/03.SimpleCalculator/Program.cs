using System;
using System.Collections.Generic;

namespace _03.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    stack.Push(i);
                }
                if (expression[i] == ')')
                {
                    int first = stack.Pop();
                    int second = i;
                    string substring = expression.Substring(first, second - first + 1);
                    Console.WriteLine(substring);
                }
            }
        }
    }
}
