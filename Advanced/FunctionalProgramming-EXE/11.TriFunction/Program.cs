using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> list = new List<string>();

            for (int i = 0; i < names.Count; i++)
            {
                int sum = 0;
                string currName = names[i];

                for (int j = 0; j < currName.Length; j++)
                {
                    sum += currName[j];
                }
                if (sum >= num)
                {
                    list.Add(currName);
                    break;
                }
            }
            Console.WriteLine(string.Join(" ",list));
        }
    }
}
