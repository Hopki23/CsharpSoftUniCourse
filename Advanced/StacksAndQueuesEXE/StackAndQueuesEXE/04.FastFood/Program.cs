using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int qty = int.Parse(Console.ReadLine());
            int[] arr = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            Queue<int> orders = new Queue<int>(arr);
            Console.WriteLine(orders.Max());
            
            while (true)
            {
                if (orders.Count == 0)
                {
                    Console.WriteLine($"Orders complete");
                    break;
                }

                int currentOrderValue = orders.Peek();
                if (qty >= currentOrderValue)
                {
                    qty -= currentOrderValue;
                    orders.Dequeue();
                }
                else
                {  
                    Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
                    break;
                }
            }
        }
    }
}
