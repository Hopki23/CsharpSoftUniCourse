using System;
using System.Collections.Generic;

namespace _07.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split(" ");
            int n = int.Parse(Console.ReadLine());
            Queue<string> names = new Queue<string>(arr);
            int counter = 1;

            while (names.Count > 1)
            {
                string currKid = names.Dequeue();
                if (counter != n)
                {
                   names.Enqueue(currKid);
                   counter++;
                }
                else
                {
                    Console.WriteLine($"Removed {currKid}");
                    counter = 1;
                }
            }
            Console.WriteLine($"Last is {names.Dequeue()}");
        }
    }
}
