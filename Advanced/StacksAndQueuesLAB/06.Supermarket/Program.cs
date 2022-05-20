using System;
using System.Collections.Generic;

namespace _06.Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> names = new Queue<string>();
            Queue<string> paidNames = new Queue<string>();
            string input;
            int counter = 0;
            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid")
                {
                    while (counter != 0)
                    {
                        Console.WriteLine(names.Dequeue());
                        counter--;
                    }
                }
                else
                {
                    names.Enqueue(input);
                    counter++;
                }
            }
            Console.WriteLine($"{counter} people remaining.");
        }
    }
}
