using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split(new string[] { ",", " -> ", ", " }, StringSplitOptions.RemoveEmptyEntries);
                string color = cmd[0];

                if (clothes.ContainsKey(color) == false)
                {
                    clothes.Add(color, new Dictionary<string, int>());
                }

                foreach (var item in cmd)
                {
                    if (item == color)
                    {
                        continue;
                    }
                    else
                    {
                        if (clothes[color].ContainsKey(item) == false)
                        {
                            clothes[color].Add(item, 0);
                        }

                        clothes[color][item]++;
                    }
                }
            }
            string[] searched = Console.ReadLine().Split(' ');
            string color2 = searched[0];
            string dress = searched[1];

            foreach (var clothe in clothes)
            {
                Console.WriteLine($"{clothe.Key} clothes:");
                foreach (var item in clothe.Value)
                {
                    if (clothe.Key == color2 && item.Key == dress)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
