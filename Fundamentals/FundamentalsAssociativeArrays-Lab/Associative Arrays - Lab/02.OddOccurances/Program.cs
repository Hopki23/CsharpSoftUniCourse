using System;
using System.Collections.Generic;
using System.Linq;

namespace OddOccurances
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach (var item in words)
            {
                string wordsInLower = item.ToLower();

                if (dictionary.ContainsKey(wordsInLower))
                {
                    dictionary[wordsInLower]++;
                }
                else
                {
                    dictionary.Add(wordsInLower, 1);
                }
            }

            foreach (var word in dictionary)
            {
                if (word.Value % 2 != 0)
                {
                    Console.Write(word.Key + " ");
                }
            }
        }
    }
}
