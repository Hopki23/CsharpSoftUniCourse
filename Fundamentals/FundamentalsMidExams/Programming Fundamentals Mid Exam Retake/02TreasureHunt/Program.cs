using System;
using System.Collections.Generic;
using System.Linq;

namespace TreasureHunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();
            while (input != "Yohoho!")
            {
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                if (command == "Loot")
                {
                    for (int i = 1; i < commands.Length; i++)
                    {
                        if (!items.Contains(commands[i]))
                        {
                            items.Insert(0, commands[i]);
                        }
                    }
                }
                else if (command == "Drop")
                {
                    int index = int.Parse(commands[1]);
                    if (index < 0 || index > items.Count)
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        var temp = items[index];
                        items.RemoveAt(index);
                        items.Add(temp);
                    }
                }
                else if (command == "Steal")
                {
                    int count = int.Parse(commands[1]);
                    int counter = 0;
                    List<string> list = new List<string>();
                    for (int i = items.Count - 1; i >= 0; i--)
                    {
                        list.Add(items[i]);
                        items.Remove(items[i]);
                        counter++;
                        if (counter == count)
                        {
                            break;
                        }
                    }
                    list.Reverse();
                    Console.WriteLine(string.Join(", ", list));
                }
                input = Console.ReadLine();
            }
            double sum = 0;
            for (int i = 0; i < items.Count; i++)
            {
               string currentItem = items[i];
                sum += currentItem.Length;
            }
            if (sum > 0)
            {
                Console.WriteLine($"Average treasure gain: {sum / items.Count:F2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }
    }
}
