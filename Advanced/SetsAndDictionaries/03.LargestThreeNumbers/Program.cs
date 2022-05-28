﻿using System;
using System.Linq;

namespace _03.LargestThreeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).OrderByDescending(x => x).Take(3).ToArray();
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
