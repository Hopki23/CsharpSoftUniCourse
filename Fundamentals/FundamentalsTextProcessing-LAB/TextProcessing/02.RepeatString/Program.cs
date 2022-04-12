using System;
using System.Text;

namespace RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var word in words)
            {
                int lenght = word.Length;

                for (int i = 0; i < lenght; i++)
                {
                    stringBuilder.Append(word);
                }
            }
            Console.WriteLine(stringBuilder);
        }
    }
}
