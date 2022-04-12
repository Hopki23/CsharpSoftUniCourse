using System;

namespace Substrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wordToRemove = Console.ReadLine();
            string words = Console.ReadLine();
            int index = words.IndexOf(wordToRemove);

            while (index != -1)
            {
                words = words.Remove(index, wordToRemove.Length);
                index = words.IndexOf(wordToRemove);
            }
            Console.WriteLine(words);
        }
    }
}
