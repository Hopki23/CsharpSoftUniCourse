﻿using System;

namespace TownInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            long population = long.Parse(Console.ReadLine());
            int kilometers = int.Parse(Console.ReadLine());
            Console.WriteLine($"Town {town} has population of {population} and area {kilometers} square km."); 
        }
    }
}
