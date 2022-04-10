using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationBasic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = input.Split().ToArray();
                string command = cmdArgs[0];
                if (command == "Add")
                {
                    int number = int.Parse(cmdArgs[1]);
                    list.Add(number);
                }
                else if (command == "Remove")
                {
                    int number = int.Parse(cmdArgs[1]);
                    list.Remove(number);
                }
                else if (command == "RemoveAt")
                {
                    int number = int.Parse(cmdArgs[1]);
                    list.RemoveAt(number);
                }
                else if (command == "Insert")
                {
                    int number = int.Parse(cmdArgs[1]);
                    int index = int.Parse(cmdArgs[2]);
                    list.Insert(index, number);
                }
            }
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
