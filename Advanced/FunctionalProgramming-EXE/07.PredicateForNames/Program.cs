using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            foreach (var name in names)
            {
                if (name.Length <= length)
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
