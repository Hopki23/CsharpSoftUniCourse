using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string input = Console.ReadLine();

            while (input != "Craft!")
            {
                string[] commands = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                if (command == "Collect")
                {
                    string item = commands[1];
                    if (list.Contains(item))
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        list.Add(item);
                    }
                }
                else if (command == "Drop")
                {
                    string item = commands[1];
                    if (list.Contains(item))
                    {
                        list.Remove(item);
                    }
                }
                else if (command == "Combine Items")
                {
                    string[] arr = commands[1].Split(":", StringSplitOptions.RemoveEmptyEntries);
                    string oldItem = arr[0];
                    string newItem = arr[1];
                    int index = list.IndexOf(oldItem);
                    if (list.Contains(oldItem))
                    {
                        list.Insert(index + 1, newItem);
                    }
                    else
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                }
                else if (command == "Renew")
                {
                    string item = commands[1];
                    if (list.Contains(item))
                    {
                        var temp = item;
                        list.Remove(item);
                        list.Add(temp);
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ",list));
        }
    }
}
