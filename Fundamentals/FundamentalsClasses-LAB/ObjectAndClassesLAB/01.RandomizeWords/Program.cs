using System;

namespace RandomizeWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Random random = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int index = random.Next(words.Length);

                string currentWord = words[i];
                words[i] = words[index];
                words[index] = currentWord;
            }

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
