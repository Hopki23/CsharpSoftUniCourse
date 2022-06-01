using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ActionPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ").ToList();
            Action<string> action = name => Console.WriteLine(name);

            names.ForEach(action);
        }
    }
}
