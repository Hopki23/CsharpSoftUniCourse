using System;
using System.Collections.Generic;
using System.Linq;
namespace WordSynonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string words = Console.ReadLine();
            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            foreach (var ch in words)
            {
                if (dictionary.ContainsKey(ch))
                {
                    dictionary[ch]++;
                }
                else
                {
                    dictionary.Add(ch, 1);
                }
            }

            foreach (var item in dictionary.Where(a => a.Key != ' '))
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}