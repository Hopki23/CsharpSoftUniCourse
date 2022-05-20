using System;
using System.Collections.Generic;

namespace _08.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            string input;
            int counter = 0;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        counter++;                       
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
