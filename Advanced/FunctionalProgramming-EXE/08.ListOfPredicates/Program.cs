using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            List<int> list = new List<int>();

            for (int i = 1; i <= end; i++)
            {
                bool isValid = false;
                foreach (var num in numbers)
                {
                    if (i % num == 0)
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                        break;
                    }
                }
                if (isValid)
                {
                    list.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ",list));
        }
    }
}
